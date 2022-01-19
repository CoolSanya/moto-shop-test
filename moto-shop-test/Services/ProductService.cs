using moto_shop_test.DAL;
using moto_shop_test.DTO.ProductDTO;
using moto_shop_test.Models;
using moto_shop_test.Models.ViewModels;

namespace moto_shop_test.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Product> GetAllProducts()
        {
            var products = _db.Products.ToList<Product>();
            return products;
        }

        public Product GetInfoProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            return product;
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

            string upload = _webHostEnvironment.ApplicationName + ENV.ImagePath;
            var oldFile = Path.Combine(upload, deleteProduct.Image);
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }

            _db.Products.Remove(deleteProduct);
            _db.SaveChanges();
        }
    }
}
