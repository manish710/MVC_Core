using System.Collections.Generic;

namespace Core_DemoApp.Services
{
    public class ProductService : IProductService
    {
        public Dictionary<int,Product> Products
        {
            get {
                return new Dictionary<int, Product>()
                {
                    {1,new Product{ ProductID=1,ProductName="Prod 1", UnitPrice=1000 } },
                    {2,new Product{ ProductID=2,ProductName="Prod 2", UnitPrice=2000 } },
                    {3,new Product{ ProductID=3,ProductName="Prod 3", UnitPrice=3000 } },
                    {4,new Product{ ProductID=4,ProductName="Prod 4", UnitPrice=4000 } }
                };
            }
        }
    }
}
