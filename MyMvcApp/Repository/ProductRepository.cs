using MyMvcApp.Models;
using MyMvcApp.ViewModel;

namespace MyMvcApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductModel> _products = new List<ProductModel>();

        public void Create(CreateProductViewModel viewModel)
        {
            var productCount = _products.Count != 0 ? _products.Count + 1 : 1;

            var product = new ProductModel
            {
                Id = productCount,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description
            };
            _products.Add(product);
        }

        public List<ProductViewModel>? GetAll()
        {
            return _products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = $"${p.Price}"
                })
                .ToList();
        }

        public ProductDetailViewModel? GetByName(string name)
        {
            ProductModel? product = _products.FirstOrDefault(p => p.Name == name);

            if (product is null)
            {
                return null;
            }
            var model = new ProductDetailViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = $"${product.Price:F2}",
                Description = product.Description ?? "Not available"
            };
            return model;
        }

        public ProductDetailViewModel? GetById(int id)
        {
            ProductModel? product = _products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return null;
            }
            var model = new ProductDetailViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = $"{product.Price:F2}",
                Description = product.Description ?? "Not available"
            };
            return model;
        }

        public void Update(UpdateProductViewModel viewModel, int id)
        {
            ProductModel? product = _products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                product.Id = viewModel.Id;
                product.Price = viewModel.Price;
                product.Description = viewModel.Description;
            }
        }
    }
}
