using DiscStore.Infrastructure.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.Services.Abstract
{
    public interface ICategoryService
    {
        bool Create(CategoryViewModel category);
        bool Edit(CategoryViewModel category);
        bool Delete(Guid categoryId);
        CategoryViewModel GetById(Guid categoryId);
        List<CategoryViewModel> GetList();
    }
}
