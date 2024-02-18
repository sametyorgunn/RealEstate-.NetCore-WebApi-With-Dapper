namespace RealEstateApi.Dtos.ProductDtos
{
    public class ResultProductsWithCategoryDto
    {
        public int productId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string coverImage { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string adress { get; set; }
        public string Description { get; set; }
        public string categoryName { get; set; }
        public bool categoryStatus { get; set; }
    }
}
