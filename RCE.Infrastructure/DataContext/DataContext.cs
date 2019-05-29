using RCE.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCE.Infrastructure
{
    public static class DataContext
    {
        static DataContext()
        {
            //initialize
            Products = new List<Product>();
            Users = new List<User>();
            PaymentTypes = new List<PaymentType>();
            ProductTypes = new List<ProductType>();
            UserToProducts = new List<UserToProduct>();
        }

        public static List<Product> Products { get; set; }
        public static List<User> Users { get; set; }
        public static List<PaymentType> PaymentTypes { get; set; }
        public static List<ProductType> ProductTypes { get; set; }
        public static List<UserToProduct> UserToProducts { get; set; }
    }
}
