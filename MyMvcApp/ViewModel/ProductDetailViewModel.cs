namespace MyMvcApp.ViewModel
{
        public class ProductDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string Price { get; set; } = default!;
            public string? Description { get; set; }
        }
}
