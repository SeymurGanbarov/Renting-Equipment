using iTextSharp.text;
using iTextSharp.text.pdf;
using RCE.UI.Models;
using RCE.UI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    [UI.Helpers.Authorize]
    public class CabinetController : BaseController
    {
        private readonly CabinetServiceFacade _cabinetServiceFacade;
        public CabinetController(CabinetServiceFacade cabinetServiceFacade)
        {
            _cabinetServiceFacade = cabinetServiceFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _cabinetServiceFacade.GetProductsByUser(CurrentUser.Id);
            if (result.IsSucceed)
                return View(result.Data);
            else
                return View(new List<ProductCartModel>());
        }

        [HttpGet]
        public ActionResult DownloadInvoice(Guid productId)
        {
            var result = _cabinetServiceFacade.GetInvoiceForDownload(productId,CurrentUser.Id);
            if (result.IsSucceed)
            {
                var invoice = result.Data;
                var response = _cabinetServiceFacade.GenerateInvoicePdf(invoice);
                if (response.IsSucceed)
                {
                    //file name to be created   
                    DateTime dTime = DateTime.Now;
                    string strPDFFileName = string.Format(Resources.UI.Invoice + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
                    return File(response.Data, "application/pdf", strPDFFileName);
                }
                else return AjaxFailureResult(response);

            }
            else return AjaxFailureResult(result);
        }
    }
}