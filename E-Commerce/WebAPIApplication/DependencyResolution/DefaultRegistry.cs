// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WebAPIApplication.DependencyResolution {
    using alamapp.Infrastructure.CookieStorage;
    using alamapp.Infrastructure.UnitOfWorks;
    using alamapp.Model.RepositoryInterface;
    using alamapp.Model.RepositoryInterface.Auth;
    using alamapp.Model.RepositoryInterface.Baskets;
    using alamapp.Model.RepositoryInterface.Customers;
    using alamapp.Model.RepositoryInterface.Orders;
    using alamapp.Model.RepositoryInterface.Packages;
    using alamapp.Model.RepositoryInterface.Products;
    using alamapp.NhRepository.PersistenceRepository.Auth;
    using alamapp.Repositories.NH;
    using alamapp.Repositories.NH.PersistenceRepository;
    using alamapp.Repositories.NH.PersistenceRepository.Baskets;
    using alamapp.Repositories.NH.PersistenceRepository.Customers;
    using alamapp.Repositories.NH.PersistenceRepository.Orders;
    using alamapp.Repositories.NH.PersistenceRepository.Packages;
    using alamapp.Repositories.NH.PersistenceRepository.Products;
    using alamapp.ServiceImplementations.Implementation;
    using alamapp.ServiceImplementations.Interface;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            //For<IExample>().Use<Example>();

            //Category--------------------------------
            //CategoryRepository
            For<ICategoryRepository>().Use<CategoryRepository>();
            //ProductRepository
            For<IProductRepository>().Use<ProductRepository>();
            For<IProductTitleRepository>().Use<ProductTitleRepository>();
            For<IManufactureRepository>().Use<ManufactureRepository>();
            For<IBrandRepository>().Use<BrandRepository>();
            For<IProductModelRepository>().Use<ProductModelRepository>();
            For<IPackageRepository>().Use<PackageRepository>();
            
            //CustomerRepository
            For<IOrderRepository>().Use<OrderRepository>();
            For<IOrderItemRepository>().Use<OrderItemRepository>();
            For<IPaymentRepository>().Use<PaymentRepository>();
            For<IColorRepository>().Use<ColorRepository>();
            For<IDeliveryAddressRepository>().Use<DeliveryAddressRepository>();
            For<ISizeRepository>().Use<SizeRepository>();
            For<IFabricRepository>().Use<FabricRepository>();
            For<ISubCategoryRepository>().Use<SubCategoryRepository>();

            For<ICustomerRepository>().Use<CustomerRepository>();
            For<ICustomerRepository>().Use<CustomerRepository>();
            For<IDistrictRepository>().Use<DistrictRepository>();
            For<IPoliceStationRepository>().Use<PoliceStationRepository>();

            //BasketRepository
            For<IBasketRepository>().Use<BasketRepository>();
            For<IBasketItemRepository>().Use<BasketItemRepository>();
            For<IProductImageRepository>().Use<ProductImageRepository>();

            //BasketService
            For<IBasketService>().Use<BasketService>();
            For<IOrderService>().Use<OrderService>();
            For<IBrandService>().Use<BrandService>();
            For<IProductModelService>().Use<ProductModelService>();
            For<IManufactureService>().Use<ManufactureService>();

            //CategoryService
            For<ICategoryService>().Use<CategoryService>();

            //CustomerService
            For<ICustomerService>().Use<CustomerService>();

            // ProductService
            For<IProductService>().Use<ProductService>();

            // Unit of work
            For<IUnitOfWork>().Use<NhUnitOfWork>();

            //Cookie storage service
            For<ICookieStorageService>().Use<CookieStorageService>();

            //Aspnet Authentication
            For<IAspRoleRepository>().Use<AspRoleRepository>();
            For<IAspUserRepository>().Use<AspUserRepository>();
            For<IAspUserRoleRepository>().Use<AspUserRoleRepository>();
            For<IAspAuthenticationService>().Use<AspAuthenticationService>();
        }

        #endregion
    }
}