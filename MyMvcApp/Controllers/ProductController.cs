using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Repository;
using MyMvcApp.ViewModel;

namespace MyMvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ActionResult Index()
        {
            var product = _productRepository.GetAll();
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel viewModel)
        {
            var product = _productRepository.GetByName(viewModel.Name);

            if (product is not null)
            {
                ViewBag.ErrorMessage = "Product already exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                _productRepository.Create(viewModel);
                return Redirect("Index");
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            var product = _productRepository.GetById(id);
            return View(product);
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var product = _productRepository.GetById(id);

            if (product is null)
            {
                ViewBag.ErrorMessage = "No product found";
            }
            var toUpdateView = new UpdateProductViewModel()
            {
                Id = product!.Id,
                Description = product.Description,
                Name = product.Name,
                Price = decimal.Parse(product.Price)
            };
            return View(toUpdateView);
        }


        [HttpPost]
        public ActionResult Update(UpdateProductViewModel viewModel)
        {

            _productRepository.Update(viewModel, viewModel!.Id);
            return RedirectToAction("Index");
        }
    }
}
