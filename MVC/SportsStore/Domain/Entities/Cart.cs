using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var line = _lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                _lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartLine> CartLines {
            get { return _lineCollection;  }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
