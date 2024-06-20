using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public class PaymentTerm:EntityBase<int>
    {
       private decimal _amount;
       private string _createDate, _mobileBankName, _sentAmountDate;
       private string _mobileBankNo;
       private bool _isFinished;
       private Payment _payment;
       private Order _order;
       private string _transactionNo;
       public string TransactionNo
       {
           get { return _transactionNo; }
           set { _transactionNo = value; }
       }
     
       public PaymentTerm()
       {
           CreateDate = DateTime.Now.ToString();
       }

       public Order Order
       {
           get { return _order; }
           set { _order = value; }
       }
      

       public PaymentTerm(string mobileBankNo, Orders.Payment payment,Order order, decimal amount, string mobileBankName, string sentAmountDate, bool isFinished)
       {
           // TODO: Complete member initialization
           _mobileBankNo= mobileBankNo;
           _payment = payment;
           _amount = amount;
           _mobileBankName = mobileBankName;
           _sentAmountDate = sentAmountDate;
           _isFinished = isFinished;
           _order = order;
       }
        
       public decimal Amount
       {
           get { return _amount; }
           set { _amount = value; }
       }
       public string SentAmountDate
       {
           get { return _sentAmountDate; }
           set { _sentAmountDate = value; }
       }

       public string MobileBankName
       {
           get { return _mobileBankName; }
           set { _mobileBankName = value; }
       }

       public string MobileBankNo
       {
           get { return _mobileBankNo; }
           set { _mobileBankNo = value; }
       }

       public string CreateDate
       {
           get { return _createDate; }
           set { _createDate = value; }
       }
       public bool IsFinished
       {
           get { return _isFinished; }
           set { _isFinished = value; }
       }
       public Payment Payment
       {
           get { return _payment; }
           set { _payment = value; }
       }
       protected override void Validate()
       {
            throw new NotImplementedException();
       }
    }
}
