namespace MyMvcApp.ViewModel
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public Decimal Price { get; set; } = default!;
        public string? Description { get; set; }
    }
}
