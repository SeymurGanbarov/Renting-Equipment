using RCE.Application.App;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCE.UI.Models
{
    public class ProductCartModel
    {
        public Guid Id { get; set; }
        [Display(ResourceType =typeof(UI.Resources.UI),Name =nameof(UI.Resources.UI.ProductName))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(UI.Resources.UI), Name = nameof(UI.Resources.UI.ProductType))]
        public string Type { get; set; }
        [Display(ResourceType = typeof(UI.Resources.UI), Name = nameof(UI.Resources.UI.DayQuantity))]
        [Required(ErrorMessageResourceType = typeof(UI.Resources.UI), ErrorMessageResourceName = nameof(UI.Resources.UI.DayQuantity))]
        public int Day { get; set; }
        [Display(ResourceType = typeof(UI.Resources.UI), Name = nameof(UI.Resources.UI.EarnedPoint))]
        public byte Point { get; set; }
        public Guid UserId { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
    }
}