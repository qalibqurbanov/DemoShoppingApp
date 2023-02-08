using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoShoppingApp.DataAccess.Models;

namespace DemoShoppingApp.DataAccess.Repositories.Abstract
{
    /// <summary>
    /// Kateqoriya ile elaqeli metodlarin imzasini saxlayir.
    /// </summary>
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        void Update(Category entity);
    }
}
