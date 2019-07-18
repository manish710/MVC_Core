using System.Collections.Generic;

namespace Core_DemoApp.Services
{
    public interface IProductService
    {
        Dictionary<int, Product> Products { get; }
    }
}