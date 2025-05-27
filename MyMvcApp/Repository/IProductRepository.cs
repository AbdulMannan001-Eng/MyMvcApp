using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MyMvcApp.ViewModel;

namespace MyMvcApp.Repository
{
    public interface IProductRepository
    {
        void Create(CreateProductViewModel viewModel);
        List<ProductViewModel>? GetAll();
        ProductDetailViewModel? GetById(int id);
        ProductDetailViewModel? GetByName(string name);
        public void Update(UpdateProductViewModel viewModel, int id);
    }
}
