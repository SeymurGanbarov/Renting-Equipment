using RCE.Infrastructure.DAOs;
using System.Collections.Generic;

namespace RCE.Infrastructure
{
    public static class DataContext
    {
        static DataContext()
        {
            //initialize
            Products = new List<ProductDAO>();
            Users = new List<UserDAO>();
            PaymentTypes = new List<PaymentTypeDAO>();
            ProductTypes = new List<ProductTypeDAO>();
            UserToProducts = new List<UserToProductDAO>();
        }

        public static List<ProductDAO> Products { get; set; }
        public static List<UserDAO> Users { get; set; }
        public static List<PaymentTypeDAO> PaymentTypes { get; set; }
        public static List<ProductTypeDAO> ProductTypes { get; set; }
        public static List<UserToProductDAO> UserToProducts { get; set; }
    }
}
