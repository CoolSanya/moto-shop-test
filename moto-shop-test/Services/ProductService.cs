using moto_shop_test.DAL;
using moto_shop_test.DTO.ProductDTO;
using moto_shop_test.Models;
using moto_shop_test.Models.ViewModels;

namespace moto_shop_test.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _db.Products.ToList<Product>();
            return products;
        }

        public Product AddProduct(ProductDTO productDTO)
        {
            var _product = new Product
            {
                Title = productDTO.Title,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Image = productDTO.Image
            };
            _db.Products.Add(_product);
            _db.SaveChanges();

            return _product;
        }

        public void DeleteProduct(int? id)
        {
            var deleteProduct = _db.Products.FirstOrDefault(p => p.Id == id);
            _db.Products.Remove(deleteProduct);
            _db.SaveChanges();
        }
    }
}
