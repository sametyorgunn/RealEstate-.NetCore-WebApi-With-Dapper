using RealEstateApi.Dtos.CategoryDtos;

namespace RealEstateApi.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
    }
}
