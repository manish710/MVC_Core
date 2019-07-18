using System.Collections.Generic;

namespace Core_DemoApp.Services
{
    public interface IBillingService
    {
        decimal TotalAmount { get; set; }
        void CalculateBill(List<int> orderedProductIds);
    }
}