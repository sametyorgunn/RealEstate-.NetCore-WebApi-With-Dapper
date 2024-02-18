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

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (categoryName,categoryStatus) values(@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.categoryName);
            parameters.Add("@categoryStatus", true);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "delete from Category where categoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using(var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query,parameters);
            }
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

        public async Task<GetCategoryById> GetCategoryById(int id)
        {
            string query = "select * from Category where categoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using(var connection = _context.CreateConnection())
            {
                var data =  connection.QueryFirstOrDefault<GetCategoryById>(query, parameters);
               return data;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "update Category set categoryName=@categoryName,categoryStatus=@categoryStatus where categoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", categoryDto.categoryId);
            parameters.Add("@categoryName", categoryDto.categoryName);
            parameters.Add("@categoryStatus", categoryDto.categoryStatus);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
