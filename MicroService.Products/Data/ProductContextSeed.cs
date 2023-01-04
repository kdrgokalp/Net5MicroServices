using MicroService.Products.Entities;

using MongoDB.Driver;

using System;
using System.Collections.Generic;

namespace MicroService.Products.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool exitsProduct = productCollection.Find(p => true).Any();
            if (!exitsProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone 12",
                    Summary ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageFie = "product-1.png",
                    Price = 599.00M,
                    Category = "Iphone"
                },
                new Product()
                {
                    Name = "Sony Z5",
                    Summary ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageFie = "product-2.png",
                    Price = 239.00M,
                    Category = "Sony"
                },
                new Product()
                {
                    Name = "Xiami Mi 9",
                    Summary ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageFie = "product-3.png",
                    Price = 199.00M,
                    Category = "Xiami"
                },
                new Product()
                {
                    Name = "Huawei Pro 5",
                    Summary ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageFie = "product-4.png",
                    Price = 259.00M,
                    Category = "Huawei"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Summary ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageFie = "product-5.png",
                    Price = 369.00M,
                    Category = "Samsung"
                },
                new Product()
                {
                    Name = "Oppo 1",
                    Summary ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageFie = "product-6.png",
                    Price = 159.00M,
                    Category = "Oppo"
                }
            };
        }
    }
}
