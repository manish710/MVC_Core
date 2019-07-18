using System.Collections.Generic;

namespace Core_DemoApp.Services
{
    public interface IOrderProcessingService
    {
        void PlaceOrder(List<int> orderedProductIds);
    }
}