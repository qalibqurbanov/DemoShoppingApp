using System.Linq;
using DemoShoppingApp.DataAccess.DbContext;
using DemoShoppingApp.DataAccess.Models;
using DemoShoppingApp.DataAccess.Repositories.Abstract;

namespace DemoShoppingApp.DataAccess.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            this.dbContext = _dbContext;
        }

        public void Update(Category category)
        {
            Category cat = dbContext.Categories.FirstOrDefault(c => c.ID == category.ID);

            if(cat != null)
            {
                cat.CategoryName = category.CategoryName;
                cat.CategoryDisplayOrder = category.CategoryDisplayOrder;
            }
        }
    }
}