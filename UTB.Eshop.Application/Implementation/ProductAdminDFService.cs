using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class ProductAdminDFService : IProductAdminService
    {
        public IList<Product> Select()
        {
            return DatabaseFake.Products;
        }

        public void Create(Product product)
        {
            if (DatabaseFake.Products != null &&
                DatabaseFake.Products.Count > 0)
            {
                product.Id = DatabaseFake.Products.Last().Id + 1;
            }
            else
                product.Id = 1;

            if(DatabaseFake.Products != null)
                DatabaseFake.Products.Add(product);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Product? product =
                DatabaseFake.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                deleted = DatabaseFake.Products.Remove(product);
            }

            return deleted;
        }
        public void Edit(Product std)
        {
            var student = DatabaseFake.Products.Where(s => s.Id == std.Id).FirstOrDefault();
            DatabaseFake.Products.Remove(student);
            DatabaseFake.Products.Add(std);
        }
        public Product GetProductById(int id)
        {
            // Implementace metody pro získání produktu dle ID
            // Tato metoda by měla komunikovat s databází nebo úložištěm dat a vrátit produkt dle zadaného ID
            return null; // V případě, že implementaci sami dokončíte
        }
        public interface IProductAdminService
        {
            IList<Product> Select();
            void Create(Product product);
            bool Delete(int id);
            void Edit(Product product);
            Product GetProductById(int id); // Přidejte tuto metodu
        }
    }
}
