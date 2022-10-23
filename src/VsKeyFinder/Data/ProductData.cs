﻿using System.Collections.Generic;

namespace VsKeyFinder.Data
{
    internal static class ProductData
    {
        internal static List<Product> GetProducts()
        {
            var Products = new List<Product>()
            {
                new Product()
                {
                    Name = $"Visual Studio 2013 {Properties.Resources.TxtUltimate}",
                    Guid = "E79B3F9C-6543-4897-BBA5-5BFB0A02BB5C",
                    Code = "06181",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2013 {Properties.Resources.TxtProfessional}",
                    Guid = "E79B3F9C-6543-4897-BBA5-5BFB0A02BB5C",
                    Code = "06177",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2013 {Properties.Resources.TxtPremium}",
                    Guid = "E79B3F9C-6543-4897-BBA5-5BFB0A02BB5C",
                    Code = "06191",
                    Key = ""
                },

                new Product()
                {
                    Name = $"Visual Studio 2015 {Properties.Resources.TxtEnterprise}",
                    Guid = "4D8CFBCB-2F6A-4AD2-BABF-10E28F6F2C8F",
                    Code = "07060",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2015 {Properties.Resources.TxtProfessional}",
                    Guid = "4D8CFBCB-2F6A-4AD2-BABF-10E28F6F2C8F",
                    Code = "07062",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2017 {Properties.Resources.TxtEnterprise}",
                    Guid = "5C505A59-E312-4B89-9508-E162F8150517",
                    Code = "08860",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2017 {Properties.Resources.TxtProfessional}",
                    Guid = "5C505A59-E312-4B89-9508-E162F8150517",
                    Code = "08862",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2019 {Properties.Resources.TxtEnterprise}",
                    Guid = "41717607-F34E-432C-A138-A3CFD7E25CDA",
                    Code = "09260",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2019 {Properties.Resources.TxtProfessional}",
                    Guid = "41717607-F34E-432C-A138-A3CFD7E25CDA",
                    Code = "09262",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2022 {Properties.Resources.TxtEnterprise}",
                    Guid = "1299B4B9-DFCC-476D-98F0-F65A2B46C96D",
                    Code = "09660",
                    Key = ""
                },
                new Product()
                {
                    Name = $"Visual Studio 2022 {Properties.Resources.TxtProfessional}",
                    Guid = "1299B4B9-DFCC-476D-98F0-F65A2B46C96D",
                    Code = "09662",
                    Key = ""
                }

            };

            return Products;
        }
    }
}
