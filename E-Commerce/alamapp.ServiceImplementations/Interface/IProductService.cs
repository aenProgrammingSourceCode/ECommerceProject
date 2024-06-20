using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IProductService
    {
       GetProductTitleDetailsResponse GetProductDetails(GetProductTitleDetailsRequest request);
        GetPackageByCategoryResponse GetPackageByCategory(GetPackageByCategoryRequest request);
        GetPackageDetailsResponse GetPackageDetailsByPackage(GetPackageDetailsRequest request);
        CreateProductTitleResponse CreateProductTitle(CreateProductTitleRequest request);
        void ModifyProductImage(ModifyProductTitleImageRequest request);
        void AssignProductTitleToProduct(CreateProductRequest request);
        void ModifyProductTitle(ModifyProductTitleRequest request);
        int CountLastProductImage();
        void DeleteProductByProductTitle(DeleteProductTitleRequest request);
        void DeleteProductByProduct(DeleteProductRequest request);
        GetAllProductTitleResponse GetAll();
        GetProductTitleResponse GetProductTitle(GetProductTitleRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
        GetAllSizeResponse GetAllSize();
        GetAllColorResponse GetAllColor();
        GetAllFabricsResponse GetAllFabric();
        GetAllSubCategoryResponse GetAllSubCategory();
        void AddProductSampleImage(CreateProductImageRequest request);
        //IEnumerable<ProductView> GetProductCountStockByBrand();
        IEnumerable<ProductTitleView> GetProductCountStockByColor();

     
        GetProductsByCategoryResponse GetProductsByCategory(
                                         GetProductsByCategoryRequest request);
        IEnumerable<ProductView> GetProductByTitle(int TitleId);
       

     
    }
}
