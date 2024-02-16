namespace RealEstateApi.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public bool Status { get; set; }
    }
}
