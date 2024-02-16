using RealEstateApi.Dtos.CategoryDtos;
using RealEstateApi.Models.DapperContext;
using Dapper;
namespace RealEstateApi.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            string query = "select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }

        }
    }
}
