using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace MVCDemo_10Apr2019.Models
{
    public partial class Categories
    {
        public Categories(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ILazyLoader LazyLoader { get; }

        ICollection<Products> _products;
        public virtual ICollection<Products> Products
        {
            get => LazyLoader.Load(this,ref _products);
            set => _products = value;
        }
    }
}
