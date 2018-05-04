using AutoMapper;
using DiscStore.Core.Entities;
using DiscStore.Infrastructure.DAL;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.Services.Concentre
{
    public class CategoryService : ICategoryService
    {
        private DSDbContext db = new DSDbContext();
        public bool Create(CategoryViewModel category)
        {
            try
            {
                Category cat = new Category();
                cat.CategoryID = category.CategoryID;
                cat.Name = category.Name;
                cat.Description = category.Description;
                db.Categories.Add(cat);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Failed creating category!");
            }
        }

        public bool Delete(Guid categoryId)
        {
            try
            {
                var category = db.Categories.Find(categoryId);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Failed deleting category!");
            }
        }

        public bool Edit(CategoryViewModel category)
        {
            try
            {
                Category cat = new Category();
                cat.CategoryID = category.CategoryID;
                cat.Name = category.Name;
                cat.Description = category.Description;
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Failed editing category!");
            }
        }

        public CategoryViewModel GetById(Guid categoryId)
        {
            var category = db.Categories.Find(categoryId);
            var model = Mapper.Map<CategoryViewModel>(category);
            return model;
        }

        public List<CategoryViewModel> GetCategoryList()
        {
            var categories = db.Categories.ToList();
            var model = Mapper.Map<List<CategoryViewModel>>(categories);
            if (categories == null)
            {
                model = new List<CategoryViewModel>();
            }
            return model;
        }
    }
}
