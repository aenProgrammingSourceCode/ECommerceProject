using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Categories;
using alamapp.Model.Packages;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Packages;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Mapping;
using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
    public class ProductService : IProductService
    {
        private ISubCategoryRepository _subCategoryRepository;
        private ISizeRepository _sizeRepository;
        private IColorRepository _colorRepository;
        private IFabricRepository _fabricRepository;

        private IProductRepository _productRepository;
        private IProductTitleRepository _productTitleRepository;
        private IManufactureRepository _manufactureRepository;
        private IBrandRepository _brandRepository;
        private IProductModelRepository _productModelRepository;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _uow;
        private IPackageRepository _packageRepository;
        private IProductImageRepository _productImageRepository;
        public ProductService(IProductRepository productRepository,
            IProductTitleRepository productTitleRepository,
            IProductModelRepository productModelRepository,
            IBrandRepository brandRepository,
            IManufactureRepository manufactureRepository,
            ICategoryRepository categoryRepository,
            IPackageRepository packageRepository,
            IProductImageRepository productImageRepository,
            IUnitOfWork uow,
            ISubCategoryRepository subCategoryRepository,
            ISizeRepository sizeRepository,
            IColorRepository colorRepository,
            IFabricRepository fabricRepository)
        {
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _productModelRepository = productModelRepository;
            _manufactureRepository = manufactureRepository;
            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _packageRepository = packageRepository;
            _productImageRepository = productImageRepository;
            _fabricRepository = fabricRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _subCategoryRepository = subCategoryRepository;
            _uow = uow;
        }

        private IEnumerable<Product> GetAllProductsMatchingQueryAndSort(GetProductsByCategoryRequest request, Query productQuery)
        {
            IEnumerable<Product> productsMatchingRefinement = _productRepository.FindBy(productQuery);

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceToHigh:
                    productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
                    break;
                case ProductsSortBy.PriceToLow:
                    productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
            }
            return productsMatchingRefinement;
        }

        public IEnumerable<ProductView> GetProductByTitle(int TitleId)
        {
            Query productQuery=ProductSearchGenerateQueryfromReuquest.CreateProductByTitleIdQuery(TitleId);
            IEnumerable<Product> productRefin = _productRepository.FindBy(productQuery);
            IEnumerable<ProductView> response = productRefin.ConvertToProductViews();
            return response;
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response;

            Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);

            IEnumerable<Product> productsMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, productQuery);

            response = productsMatchingRefinement.CreateProductSearchResultFrom(request);

            response.SelectedCategoryName =_categoryRepository.FindBy(request.CategoryId).Name;


            return response;
        }

        //public IEnumerable<ProductView> GetProductCountStockByBrand()
        //{
        //    GetProductsByCategoryResponse response = new GetProductsByCategoryResponse();
        //    IEnumerable<ProductTitle> products =_productTitleRepository.FindAll();
        //    response.Products = products.ConvertToProductTitleViews();

        //    var GetStockByBrand = from product in response.Products.Distinct()
        //                        group product by product.BrandName into brandGroup
        //                        select new ProductView
        //                        {
        //                            BrandId=brandGroup.FirstOrDefault().BrandId,
        //                            BrandName=brandGroup.Key.ToString(),
        //                            TotalProductByBrand =brandGroup.Count()
        //                        };


        //    return GetStockByBrand.ToList();
        //}

        public IEnumerable<ProductTitleView> GetProductCountStockByColor()
        {
            GetProductsByCategoryResponse response = new GetProductsByCategoryResponse();
            IEnumerable<ProductTitle> products =_productTitleRepository.FindAll();
            response.Products = products.ConvertToProductTitleViews();

            var GetStockByBrand = from product in response.Products.Distinct()
                                  group product by product.ColorName into brandGroup
                                  select new ProductTitleView
                                  {
                                      ColorId = brandGroup.FirstOrDefault().ColorId,
                                      ColorName = brandGroup.Key.ToString(),
                                      TotalProductByColor=brandGroup.Count()
                                  };


            return GetStockByBrand.ToList();
        }

        public GetProductTitleDetailsResponse GetProductDetails(GetProductTitleDetailsRequest request)
        {
            ProductTitle productTitle =_productTitleRepository.FindBy(request.Id);
            GetProductTitleDetailsResponse response = new GetProductTitleDetailsResponse();
            response.Product=productTitle.ConvertToProductTitleView();
            return response;
        }
        public CreateProductTitleResponse CreateProductTitle(CreateProductTitleRequest request)
        {
            ProductTitle productTitle = new ProductTitle();
            productTitle.Name = request.Name;
            productTitle.Price = request.Price;
            productTitle.Description = request.Description;
            productTitle.ImageId = request.ImageId;
            productTitle.MadeIn = request.MadeIn;
            productTitle.FabricName = request.FabricName;

            Manufacture manufacture = _manufactureRepository.FindBy(request.ManufactureId);
            Brand brand = _brandRepository.FindBy(request.BrandId);
            ProductModel productModel = _productModelRepository.FindBy(request.ProductModelId);
            Category category = _categoryRepository.FindBy(request.CategoryId);
            SubCategory subCategory = _subCategoryRepository.FindBy(request.SubCategoryId);
            Color color = _colorRepository.FindBy(request.ColorId);

            productTitle.SubCategory = subCategory;
            productTitle.Color = color;
            productTitle.Category = category;
            productTitle.Manufacture = manufacture;
            productTitle.ProductModel = productModel;
            productTitle.Brand = brand;

            // Method for adding product image
            //productTitle.AddProductImage();

            _productTitleRepository.Add(productTitle);

            _uow.Commit();

            CreateProductTitleResponse response = new CreateProductTitleResponse();
            response.ProductTitle = productTitle.ConvertToProductTitleView();

            return response;
        }
        public void ModifyProductTitle(ModifyProductTitleRequest request)
        {
            ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductTitleId);
            productTitle.Name = request.Name;
            productTitle.Price = request.Price;
            productTitle.Description = request.Description;

            Manufacture manufacture = _manufactureRepository.FindBy(request.ManufactureId);
            Brand brand = _brandRepository.FindBy(request.BrandId);
            ProductModel productModel = _productModelRepository.FindBy(request.ProductModelId);
            Category category = _categoryRepository.FindBy(request.CategoryId);

            productTitle.Category = category;
            productTitle.Manufacture = manufacture;
            productTitle.ProductModel = productModel;
            productTitle.Brand = brand;

            _productTitleRepository.Save(productTitle);

            _uow.Commit();
        }
        public int CountLastProductImage()
        {
            IEnumerable<ProductImage> productImage = _productImageRepository.FindAll();
            return productImage.Last().Id;
        }
        public void AssignProductTitleToProduct(CreateProductRequest request)
        {
            Product product = new Product();
            ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductTitleId);
            Size size = _sizeRepository.FindBy(request.SizeId);
            product.Size = size;
            product.Title = productTitle;
            _productRepository.Add(product);
        }
        public void ModifyProductImage(ModifyProductTitleImageRequest request)
        {
            ProductImage productImage = _productImageRepository.FindBy(request.ImageId);
            _productImageRepository.Save(productImage);
            _uow.Commit();
        }
        public Messaging.Product.GetPackageByCategoryResponse GetPackageByCategory(Messaging.Product.GetPackageByCategoryRequest request)
        {
            Package package = _packageRepository.FindBy(request.CategoryId);
            GetPackageByCategoryResponse response = new GetPackageByCategoryResponse();
            response.Packages = package.ConvertToPackageView();

            return response;
        }
        public Messaging.Product.GetPackageDetailsResponse GetPackageDetailsByPackage(Messaging.Product.GetPackageDetailsRequest request)
        {
            Package package = _packageRepository.FindBy(request.PackageId);
            GetPackageDetailsResponse response = new GetPackageDetailsResponse();
            response.Package = package.ConvertToPackageView();

            return response;
        }
        public void DeleteProductByProductTitle(DeleteProductTitleRequest request)
        {
            RemoveProductTitle(request.RemoveToProduct);
            _uow.Commit();
        }
        public void RemoveProductTitle(IList<int> RemoveToProductTitle)
        {
            ProductTitle productTitle;
            foreach (int productTitleId in RemoveToProductTitle)
            {
                productTitle = _productTitleRepository.FindBy(productTitleId);
                _productTitleRepository.Delete(productTitle);
                _uow.Commit();
            }
        }
        public void DeleteProductByProduct(DeleteProductRequest request)
        {
            RemoveProduct(request.DeleteProductId);
        }
        public void RemoveProduct(IList<DeleteProductIdRequest> productToDelete)
        {
            ProductTitle productTitle;
            foreach (DeleteProductIdRequest productId in productToDelete)
            {
                productTitle =_productTitleRepository.FindBy(productId.ProductTitleId);
                _productTitleRepository.Delete(productTitle);
                _uow.Commit();
            }
        }
        public GetAllProductTitleResponse GetAll()
        {
            GetAllProductTitleResponse response = new GetAllProductTitleResponse();
            IEnumerable<ProductTitle> products = _productTitleRepository.FindAll();
            response.ProductTitles = products.ConvertToProductTitleViews();
            return response;
        }
        public GetProductTitleResponse GetProductTitle(GetProductTitleRequest request)
        {
            GetProductTitleResponse response = new GetProductTitleResponse();
            ProductTitle productTitle = _productTitleRepository.FindBy(request.Id);
            response.ProductTitle = productTitle.ConvertToProductTitleView();
            return response;
        }
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            Query productQuery = ProductSearchGenerateQueryfromReuquest.CreateProductByIdQuery(request);
            IEnumerable<Product> ProductMatchingRefinement =_productRepository.FindBy(productQuery);
            GetProductResponse response=new GetProductResponse();
            response.Products= ProductMatchingRefinement.ConvertToProductViews();
            return response;
        }
        public GetAllSizeResponse GetAllSize()
        {
            GetAllSizeResponse response = new GetAllSizeResponse();
            IEnumerable<Size> sizes =_sizeRepository.FindAll();
            response.Sizes = sizes.ConvertToSizeViews();
            return response;
        }
        public GetAllColorResponse GetAllColor()
        {
            GetAllColorResponse response = new GetAllColorResponse();
            IEnumerable<Color> colors = _colorRepository.FindAll();
            response.Colors = colors.ConvertToColorViews();
            return response;
        }
        public GetAllFabricsResponse GetAllFabric()
        {
            GetAllFabricsResponse response = new GetAllFabricsResponse();
            IEnumerable<Fabric> fabrics = _fabricRepository.FindAll();
            response.Febrics = fabrics.ConvertToFabricViews();
            return response;
        }
        public GetAllSubCategoryResponse GetAllSubCategory()
        {
            GetAllSubCategoryResponse response = new GetAllSubCategoryResponse();
            IEnumerable<SubCategory> subCategories = _subCategoryRepository.FindAll();
            response.SubCategories = subCategories.ConvertToSubCategoryViews();
            return response;
        }
        public void AddProductSampleImage(CreateProductImageRequest request)
        {
            ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductTitleId);
            ProductImage productImage = new ProductImage();
            productImage.ProductTitle = productTitle;
            productImage.SampleImage = request.SampleImage;
            _productImageRepository.Add(productImage);
            _uow.Commit();
        }

         
    }
}
