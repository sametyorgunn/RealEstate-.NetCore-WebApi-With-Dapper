namespace RealEstateApi.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public bool categoryStatus { get; set; }
    }
}
