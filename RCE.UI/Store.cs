using RCE.UI.Models;
using System.Collections.Generic;

namespace RCE.UI
{
    public static class Store
    {
        static Store()
        {
            CartProducts = new List<ProductCartModel>();
        }
        public static List<ProductCartModel> CartProducts { get; set; }
    }
}