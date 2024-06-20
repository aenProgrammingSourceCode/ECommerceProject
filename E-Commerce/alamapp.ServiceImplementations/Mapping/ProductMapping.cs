using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel;
using alamapp.ServiceImplementations.ViewModel.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class ProductMapping
    {
       
       public static GetProductsByCategoryResponse CreateProductSearchResultFrom(this IEnumerable<Product> productsMatchingRefinement, GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();

            IEnumerable<ProductTitle> productsFound = productsMatchingRefinement.Select(p => p.Title).Distinct();
           
            IEnumerable<Size> sizeFound = productsMatchingRefinement.Select(s => s.Size).Distinct();

            IEnumerable<Product> productsNoFound = productsMatchingRefinement;

            productSearchResultView.BaseProduct = productsMatchingRefinement.ConvertToProductViews();

            productSearchResultView.SelectedCategory = request.CategoryId;

            productSearchResultView.NumberOfTitlesFound = productsFound.Count();

            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                                                              productSearchResultView.NumberOfTitlesFound);

            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);
            productSearchResultView.Sizes = CropToSize(sizeFound);
            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, productsFound);

            return productSearchResultView;
        }

        private static IEnumerable<SizeView> CropToSize(IEnumerable<Size> sizeFound)
        {
            return Mapper.Map<IEnumerable<Size>, IEnumerable<SizeView>>(sizeFound);
        }
        private static IEnumerable<ProductTitleView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductTitle> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip).Take(numberOfResultsPerPage).ConvertToProductTitleViews();
            }
            else
                return productsFound.Take(numberOfResultsPerPage).ConvertToProductTitleViews();
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductTitle> productsFound)
        {
            var brandsRefinementGroup = productsFound.Select(p => p.Brand).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(b => (IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.brand);
            var colorsRefinementGroup = productsFound.Select(p => p.Color).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(c => (IProductAttribute)c).ConvertToRefinementGroup(RefinementGroupings.color);
            var sizesRefinementGroup = (from p in productsFound
                                        from si in p.Products
                                        select si.Size).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(s => (IProductAttribute)s).ConvertToRefinementGroup(RefinementGroupings.size);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);
            return refinementGroups;
        }

       public static IEnumerable<ProductView> ConvertToProductViews(this IEnumerable<Product> products)
       {
           return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(products);
       }
       public static ProductView ConvertToProductView(this Product product)
       {
           return Mapper.Map<Product, ProductView>(product);
       }

       public static IEnumerable<ColorView> ConvertToColorViews(this IEnumerable<Color> colors)
       {
           return Mapper.Map<IEnumerable<Color>, IEnumerable<ColorView>>(colors);
       }

       public static IEnumerable<SizeView> ConvertToSizeViews(this IEnumerable<Size> sizes)
       {
           return Mapper.Map<IEnumerable<Size>, IEnumerable<SizeView>>(sizes);
       }

       public static IEnumerable<FabricView> ConvertToFabricViews(this IEnumerable<Fabric> fabrics)
       {
           return Mapper.Map<IEnumerable<Fabric>, IEnumerable<FabricView>>(fabrics);
       }

       public static IEnumerable<SubCategoryView> ConvertToSubCategoryViews(this IEnumerable<SubCategory> subCategorys)
       {
           return Mapper.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryView>>(subCategorys);
       }
    }
}
