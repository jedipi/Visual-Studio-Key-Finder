using System.Collections.Generic;

namespace VsKeyFinder
{
    internal static class ProductData
    {
        internal static List<Product> GetProducts()
        {
            var Products = new List<Product>()
            {
                new Product()
                {
                    Name = "Visual Studio 2019 Enterprise",
                    Guid = "41717607-F34E-432C-A138-A3CFD7E25CDA",
                    Code = "09260",
                    Key = ""
                },
                new Product()
                {
                    Name = "Visual Studio 2019 Professional",
                    Guid = "41717607-F34E-432C-A138-A3CFD7E25CDA",
                    Code = "09262",
                    Key = ""
                },
                new Product()
                {
                    Name = "Visual Studio 2022 Enterprise",
                    Guid = "1299B4B9-DFCC-476D-98F0-F65A2B46C96D",
                    Code = "09660",
                    Key = ""
                },
                new Product()
                {
                    Name = "Visual Studio 2022 Professional",
                    Guid = "1299B4B9-DFCC-476D-98F0-F65A2B46C96D",
                    Code = "09662",
                    Key = ""
                }

            };

            return Products;
        }
    }
}
