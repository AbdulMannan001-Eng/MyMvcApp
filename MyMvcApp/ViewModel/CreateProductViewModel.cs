using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.ViewModel
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Invalid price value")]
        public Decimal Price { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
