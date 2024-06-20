using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Category;
using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPIApplication.Models;
using WebAPIApplication.Models.JsonDto;

namespace WebAPIApplication.Controllers
{
   
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;
        IList<string> _getString=new List<string>();
        public string UploadedImage { get; set; }
        public string BaseImageId
        {
            get { return string.Concat(Guid.NewGuid().ToString(), ".jpg");}
        }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public void Delete(JsonCategoryRequests jsonCategoryRequest)
        {
            DeleteCategoryRequest request=new DeleteCategoryRequest();
            request.DeleteRequestId = jsonCategoryRequest.ConvertToCategoryRequests();
            _categoryService.DeleteCategoryByCategories(request);
        }

        [HttpPost]
        public Guid Save(CreateCategoryRequest request)
        {
             request.ImageId = Guid.NewGuid();
             _categoryService.Save(request);
             return request.ImageId;
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Create(CreateCategoryRequest request)
        {
            CreateCategoryRequest cRequest = new CreateCategoryRequest();
            cRequest.Name = request.Name;
            cRequest.Description = request.Description;
            cRequest.ImageId = request.ImageId;
            CreateCategoryResponse response = _categoryService.Create(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
        public int GetLastCategory()
        {
            return _categoryService.GetLastCategoryFromAllCategory();
        }
        
        [HttpPost]
        public string UploadPic()
        {
            string imgId = Guid.NewGuid().ToString();
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var httpFileUpload = HttpContext.Current.Request.Files["UploadImage"];
                if (httpFileUpload != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/CategoryImage"), imgId +".jpg");
                    httpFileUpload.SaveAs(fileSavePath);
                }
            }
           return imgId;
        }
        
        [HttpPost]
        public HttpResponseMessage ModifyCategory(int id, CategoryView categoryView)
        {
            ModifyCategoryRequest request = new ModifyCategoryRequest();
            request.Id = id;
            request.Name = categoryView.Name;
            request.Description = categoryView.Description;
            request.ImageId = categoryView.ImageId;
            _categoryService.ModifyCategory(request);
            ModifyCategoryResponse response = _categoryService.ModifyCategory(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
 
        }
        public void ModifyUploadedFile(string Id)
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpFileUpload = HttpContext.Current.Request.Files["EditUploadedImage"];
                if (httpFileUpload != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/CategoryImage"),Id + ".jpg");
                    httpFileUpload.SaveAs(fileSavePath);
                }
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            GetAllCategoryResponse response = _categoryService.GetAll();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Categories);
            return httpResponse;
        }


        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            GetCategoryRequest request = new GetCategoryRequest() { CategoryId = id };
            GetCategoryResponse response = _categoryService.Get(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
       
    }
}
