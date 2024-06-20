using alamapp.Model.Baskets;
using alamapp.Model.Orders;
using alamapp.Model.RepositoryInterface.Baskets;
using alamapp.Model.RepositoryInterface.Orders;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Orders;
using alamapp.ServiceImplementations.ViewModel.Orders;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.Infrastructure.UnitOfWorks;
using System.Web;
using alamapp.Infrastructure.Querying;

namespace alamapp.ServiceImplementations.Implementation
{
   public class OrderService:IOrderService
    {
       private IBasketRepository _basketRepository;
       private IOrderRepository _orderRepository;
       private IOrderItemRepository _orderItemRepository;
       private IPaymentRepository _paymentRepository;
       private IUnitOfWork _uow;
       public OrderService(IBasketRepository basketRepository, 
           IOrderRepository orderRepository, 
           IOrderItemRepository orderItemRepository, 
           IPaymentRepository paymentRepository,
           IUnitOfWork uow)
       {
           _basketRepository = basketRepository;
           _orderRepository = orderRepository;
           _orderItemRepository = orderItemRepository;
           _paymentRepository = paymentRepository;
           _uow = uow;
       }
        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            Basket basket = _basketRepository.FindBy(request.BasketId);
            Order order = basket.ConvertToOrder(request);
            
            _orderRepository.Add(order);
            _basketRepository.Delete(basket);
            _uow.Commit();

            response.Order = order.ConvertToOrderView();
            return response;
             
        }
        public GetOrdersByTokenResponse GetOrderByToken(GetOrdersByTokenRequest request)
        {
            GetOrdersByTokenResponse response = new GetOrdersByTokenResponse();
            Order order = _orderRepository.FindBy(request.IdentityToken);
            response.Order = order.ConvertToOrderView();
            return response;
        }

        public GetOrderItemByTokenResponse GetOrderItemByToken(GetOrderItemByTokenRequest request)
        {
            GetOrderItemByTokenResponse response = new GetOrderItemByTokenResponse();
            OrderItem orderItem = _orderItemRepository.FindBy(request.IdentityToken);
            response.OrderItem = orderItem.ConvertToOrderItemView();
            return response;
        }

       public GetAllPaymentResponse GetAllPayment(CreatePaymentRequest request)
        {
            Query paymentQuery = PaymentGenerateQueryRequest.CreatePaymentQuery(request);
            GetAllPaymentResponse response = new GetAllPaymentResponse();
            IEnumerable<Payment> payments = _paymentRepository.FindAll();
            response.Payments = payments.ConvertToPaymentViews();
            return response;
        }

       public void CreatePayment(CreatePaymentRequest request)
        {
            Payment payment = new Payment();
            Order order = _orderRepository.FindBy(9029);
            payment.IdentityToken = request.IdentityToken;
            payment.MobileBankNo=request.MobileBankNo;
            payment.Order=order;
            payment.Amount=request.Amount;
            payment.IsConfirmed=1;
            payment.MobileBankName=request.MobileBankName;
            payment.TransactionNo = request.TransactionId;
            payment.IsFinished = request.isFinished;
            _paymentRepository.Add(payment);
            _uow.Commit();
        }

       public void ConfirmPayment(CreateConfirmPaymentRequest request)
       {
           Payment payment = _paymentRepository.FindBy(request.Id);
           payment.IsConfirmed = 2;
           _paymentRepository.Save(payment);
           _uow.Commit();
       }
    }
}
