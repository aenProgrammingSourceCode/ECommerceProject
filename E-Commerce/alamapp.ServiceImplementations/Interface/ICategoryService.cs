using alamapp.ServiceImplementations.Messaging.Category;
using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface ICategoryService
   {
       void Save(CreateCategoryRequest request);
       CreateCategoryResponse Create(CreateCategoryRequest request);
       ModifyCategoryResponse ModifyCategory(ModifyCategoryRequest request);
       GetCategoryResponse Get(GetCategoryRequest request);
       GetAllCategoryResponse GetAll();
       int GetLastCategoryFromAllCategory();
       void DeleteCategoryByCategories(DeleteCategoryRequest request);
    
    }
}
