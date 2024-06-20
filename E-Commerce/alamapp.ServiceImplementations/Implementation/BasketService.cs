using alamapp.Model.Baskets;
using alamapp.Model.Packages;
using alamapp.Model.RepositoryInterface.Baskets;
using alamapp.Model.RepositoryInterface.Packages;
using alamapp.ServiceImplementations.Messaging.Baskets;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.ServiceImplementations.Interface;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.Model.Products;
using alamapp.ServiceImplementations.ViewModel.Baskets;

namespace alamapp.ServiceImplementations.Implementation
{
    public class BasketService : IBasketService
    {
        private IBasketRepository _basketRepository;
        private IBasketItemRepository _basketItemRepository;
        private IProductRepository _productRepository;
        private IPackageRepository _packageRepository;
        private IUnitOfWork _uow;
        public BasketService(IBasketRepository basketRepository,
            IPackageRepository packageRepository,
            IProductRepository productRepository,
            IBasketItemRepository basketItemRepository,
            IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
            _basketItemRepository = basketItemRepository;
            _basketRepository = basketRepository;
            _packageRepository = packageRepository;
        }
        public CreateBasketResponse AddPackageToBasket(CreateBasketRequest request)
        {
            CreateBasketResponse response = new CreateBasketResponse();
            Package package = _packageRepository.FindBy(request.PackageId);
            Basket basket = package.ConvertPackageToBasket();

            _basketRepository.Save(basket);
            _uow.Commit();

            response.Basket = basket.ConvertToBasketView();
            return response;
        }



        public GetBasketResponse GetBasket(GetBasketRequest request)
        {
            Basket basket = _basketRepository.FindBy(request.BasketId);
            GetBasketResponse response = new GetBasketResponse();
            response.Basket = basket.ConvertToBasketView();

            return response;
        }

        public GetBasketItemResponse GetBasketItem(GetBasketItemRequest request)
        {
            BasketItem basketItem = _basketItemRepository.FindBy(request.BasketItemId);
            GetBasketItemResponse response = new GetBasketItemResponse();
            response.BasketItem = basketItem.ConvertToBasketItemView();

            return response;
        }

        public CreateProductBasketResponse AddProductToBasket(CreateProductBasketRequest request)
        {
            CreateProductBasketResponse response = new CreateProductBasketResponse();
            Product product = _productRepository.FindBy(request.ProductId);
            Basket basket = new Basket();
            AddProduct(request.productToAdd, basket);
            _basketRepository.Save(basket);
            _uow.Commit();

            response.Basket = basket.ConvertToBasketView();

            return response;
        }
        public ModifyProductBasketResponse ModifyProductBasket(ModifyProductBasketRequest request)
        {
            ModifyProductBasketResponse response = new ModifyProductBasketResponse();
            Basket basket = _basketRepository.FindBy(request.BasketId);
            AddProduct(request.ProductToAdd, basket);
            UpdateItem(request.UpdateItemQty, basket);
            _basketRepository.Save(basket);
            _uow.Commit();

            response.Basket = basket.ConvertToBasketView();
            return response;

        }

        private void AddProduct(IList<int> productForBasket, Basket basket)
        {
            Product product;
            if (productForBasket.Count > 0)
            {
                foreach (int productId in productForBasket)
                {
                    product = _productRepository.FindBy(productId);
                    basket.AddProductToBasket(product);
                }
            }
        }

        private void UpdateItem(IList<UpdateProductQtyRequest> productQtyRequests, Basket basket)
        {
            foreach (UpdateProductQtyRequest productQtyRequest in productQtyRequests)
            {
                Product product = _productRepository.FindBy(productQtyRequest.ProductId);
                if (product != null)
                    basket.ChangeBasketItems(product, productQtyRequest.NewQty);
            }
        }

        public DeleteBasketResponse DeleteBasket(DeleteBasketRequest request)
        {
            DeleteBasketResponse response = new DeleteBasketResponse();
            Basket basket = _basketRepository.FindBy(request.BasketId);
            DeleteProduct(request.DeleteProducts, basket);

            _basketRepository.Save(basket);
            _uow.Commit();

            response.Basket = basket.ConvertToBasketView();
            return response;
        }

        private void DeleteProduct(IList<DeleteProductFromBasketItemRequest> DeleteProducts, Basket basket)
        {
            foreach (DeleteProductFromBasketItemRequest products in DeleteProducts)
            {
                Product product = _productRepository.FindBy(products.ProductId);
                basket.RemoveBasketItems(product);
            }
        }


        public void DeleteBasketItemById(int id)
        {
            BasketItem basketItem =_basketItemRepository.FindBy(id);
            _basketItemRepository.Delete(basketItem);
            _uow.Commit();
        }
    }
}
