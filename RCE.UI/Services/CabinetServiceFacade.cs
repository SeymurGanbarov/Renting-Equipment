using Common.Util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using RCE.Application.App;
using RCE.Application.QueryServices;
using RCE.Application.Services;
using RCE.Commons;
using RCE.UI.Models;
using RCE.UI.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RCE.UI.Services
{
    public class CabinetServiceFacade
    {
        private readonly IUserToProductQueryService _userToProductQueryService;
        private readonly ProductTypeServiceFacade _productTypeServiceFacade;
        private readonly IProductQueryService _productQueryService;
        public CabinetServiceFacade(IUserToProductQueryService userToProductQueryService, ProductTypeServiceFacade productTypeServiceFacade,
                                     IProductQueryService productQueryService)
        {
            _userToProductQueryService = userToProductQueryService;
            _productTypeServiceFacade = productTypeServiceFacade;
            _productQueryService = productQueryService;
        }

        public LogicResult<ProductInvoiceModel> GetInvoiceForDownload(Guid productId,Guid userId)
        {
            try
            {
                var invoice = (from userToProduct in _userToProductQueryService.GetAll()
                                   join product in _productQueryService.GetAll() on userToProduct.ProductId equals product.Id
                                   join productType in _productTypeServiceFacade.Data on product.TypeId equals productType.Id
                                   where userToProduct.UserId == userId && userToProduct.ProductId==productId
                                   select new ProductInvoiceModel
                                   {
                                       Day = userToProduct.Day,
                                       UserId = userToProduct.UserId,
                                       Point = userToProduct.Point,
                                       Id = userToProduct.ProductId,
                                       PaymentDetail = SerializerHelper.DeserializeObject<PaymentDetail>(userToProduct.PaymentDetail),
                                       Name = product.Name,
                                       Type = productType.Type
                                   }).FirstOrDefault();
                return LogicResult<ProductInvoiceModel>.Succeed(invoice);
            }
            catch
            {
                return LogicResult<ProductInvoiceModel>.Failure(Validation.UnSuccessfullOperation);
            }
        }

        public LogicResult<IEnumerable<ProductCartModel>> GetProductsByUser(Guid userId)
        {
            try
            {
                var userProducts =  from userToProduct in _userToProductQueryService.GetAll()
                                    join product in _productQueryService.GetAll() on userToProduct.ProductId equals product.Id
                                    join productType in _productTypeServiceFacade.Data on product.TypeId equals productType.Id
                                    where userToProduct.UserId == userId select new ProductCartModel
                                    {
                                        Day = userToProduct.Day,
                                        UserId = userToProduct.UserId,
                                        Point = userToProduct.Point,
                                        Id = userToProduct.ProductId,
                                        PaymentDetail = SerializerHelper.DeserializeObject<PaymentDetail>(userToProduct.PaymentDetail),
                                        Name = product.Name,
                                        Type = productType.Type
                                    };
                return LogicResult<IEnumerable<ProductCartModel>>.Succeed(userProducts);
            }
            catch
            {
                return LogicResult<IEnumerable<ProductCartModel>>.Failure(Validation.UnSuccessfullOperation);
            }
        }

        public LogicResult<MemoryStream> GenerateInvoicePdf(ProductInvoiceModel invoice)
        {
            try
            {
                MemoryStream workStream = new MemoryStream();

                Document doc = new Document();
                doc.SetMargins(0f, 0f, 0f, 0f);
                //Create PDF Table with 5 columns  
                PdfPTable tableLayout = new PdfPTable(8);
                doc.SetMargins(0f, 0f, 0f, 0f);
                //Create PDF Table  

                PdfWriter.GetInstance(doc, workStream).CloseStream = false;
                doc.Open();

                //Add Content to PDF   
                doc.Add(AddContentToPDF(tableLayout, invoice));

                // Closing the document  
                doc.Close();

                byte[] byteInfo = workStream.ToArray();
                workStream.Write(byteInfo, 0, byteInfo.Length);
                workStream.Position = 0;
                return LogicResult<MemoryStream>.Succeed(workStream);
            }
            catch
            {
                return LogicResult<MemoryStream>.Failure(Validation.UnSuccessfullOperation);
            }
        }


        #region helper methods
        protected PdfPTable AddContentToPDF(PdfPTable tableLayout, ProductInvoiceModel invoice)
        {

            float[] headers = { 40, 30, 20, 20, 20, 20, 20, 20 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  


            tableLayout.AddCell(new PdfPCell(new Phrase(UI.Resources.UI.Invoice, new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            ////Add header  
            AddCellToHeader(tableLayout, UI.Resources.UI.ProductName);
            AddCellToHeader(tableLayout, Resources.UI.ProductType);
            AddCellToHeader(tableLayout, Resources.UI.DayQuantity);
            AddCellToHeader(tableLayout, Resources.UI.OneTime);
            AddCellToHeader(tableLayout, Resources.UI.Premium);
            AddCellToHeader(tableLayout, Resources.UI.Regular);
            AddCellToHeader(tableLayout, Resources.UI.TotalPrice);
            AddCellToHeader(tableLayout, Resources.UI.EarnedPoint);

            ////Add body  

            AddCellToBody(tableLayout, invoice.Name);
            AddCellToBody(tableLayout, invoice.Type);
            AddCellToBody(tableLayout, invoice.Day.ToString());
            AddCellToBody(tableLayout, invoice.PaymentDetail.OneTime.ToString() + " €");
            AddCellToBody(tableLayout, invoice.PaymentDetail.Premium.ToString() + " €");
            AddCellToBody(tableLayout, invoice.PaymentDetail.Regular.ToString() + " €");
            AddCellToBody(tableLayout, invoice.PaymentDetail.TotalPrice.ToString() + " €");
            AddCellToBody(tableLayout, invoice.Point.ToString());


            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }
        #endregion 
    }
}