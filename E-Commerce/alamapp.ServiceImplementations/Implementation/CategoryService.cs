using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Categories;
using alamapp.Model.RepositoryInterface;
using alamapp.ServiceImplementations.Messaging.Category;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.ViewModel;
using alamapp.Model.RepositoryInterface.Products;


namespace alamapp.ServiceImplementations.Implementation
{
   public class CategoryService :ICategoryService
    {
       private ICategoryRepository _categoryRepository;
       private IUnitOfWork _uow;
     
       public CategoryService(
           ICategoryRepository categoryRepository,
           IUnitOfWork uow)
       {
           _categoryRepository = categoryRepository;
           _uow = uow;
        
       }

       public void Save(CreateCategoryRequest request)
       {
           Category category = new Category();
           category.Name = request.Name;
           category.ImageId = request.ImageId;
           category.Description = request.Description;
           _categoryRepository.Add(category);
           _uow.Commit();
       }
       public CreateCategoryResponse Create(CreateCategoryRequest request)
       {
           CreateCategoryResponse response = new CreateCategoryResponse();
           Category category = new Category();
          
           category.Name = request.Name;
           category.ImageId = request.ImageId;
           category.Description = request.Description;
           response.Category = category.ConvertToCategoryView();
           _categoryRepository.Add(category);
           _uow.Commit();
           return response;
       }
       public GetAllCategoryResponse GetAll()
       {
           IEnumerable<Category> Categories = _categoryRepository.FindAll();
           GetAllCategoryResponse response = new GetAllCategoryResponse();
           response.Categories = Categories.ConvertToCategoryViews();

           return response;
       }
        
       public ModifyCategoryResponse ModifyCategory(ModifyCategoryRequest request)
       {
           ModifyCategoryResponse response = new ModifyCategoryResponse();
           Category category = _categoryRepository.FindBy(request.Id);
           category.Name = request.Name;
           category.Description = request.Description;
           response.Category = category.ConvertToCategoryView();
           _categoryRepository.Save(category);
           _uow.Commit();
           return response;
       }
       public GetCategoryResponse Get(GetCategoryRequest request)
       {
           GetCategoryResponse response = new GetCategoryResponse();
           Category category = _categoryRepository.FindBy(request.CategoryId);
           response.Category = category.ConvertToCategoryView();
           return response;
       }

       // return int
       // from model view
       public int GetLastCategoryFromAllCategory()
       {
           IEnumerable<Category> categories = _categoryRepository.FindAll();
           GetAllCategoryResponse response = new GetAllCategoryResponse();
           response.Categories = categories.ConvertToCategoryViews();
           return response.Categories.Last().Id;
       }


       public void DeleteCategoryByCategories(DeleteCategoryRequest request)
       {
           CategoryForDeleting(request.DeleteRequestId);
       }

       private void CategoryForDeleting(IList<DeleteCategoryRequestId> requestCategoryId)
       {
           foreach (DeleteCategoryRequestId categories in requestCategoryId)
           {
               Category category = _categoryRepository.FindBy(categories.NewCategoryId);
               _categoryRepository.Delete(category);
               _uow.Commit();
           }

       }


       
    }
}
