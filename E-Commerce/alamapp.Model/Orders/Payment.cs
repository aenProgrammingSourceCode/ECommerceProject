using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public class Payment:EntityBase<int>, IAggregateRoot
    {
        private Order _order;
        private int _isConfirmed;
        private decimal _amount;
        private string _identityToken, _paymentDate, _createDate, _mobileBankName, _mobileBankNo, _transactionNo;
        private int _isFinished;

        public Payment()
        {
            CreateDate = DateTime.Now.ToString();
        }
        public int IsFinished
        {
            get { return _isFinished; }
            set { _isFinished = value; }
        }
        public string TransactionNo
        {
            get { return _transactionNo; }
            set { _transactionNo = value; }
        }

        public string MobileBankNo
        {
            get { return _mobileBankNo; }
            set { _mobileBankNo = value; }
        }

        public string MobileBankName
        {
            get { return _mobileBankName; }
            set { _mobileBankName = value; }
        }

        public string CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public string PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        public string IdentityToken
        {
            get { return _identityToken; }
            set { _identityToken = value; }
        }
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public int IsConfirmed
        {
            get { return _isConfirmed; }
            set { _isConfirmed = value; }
        }
      
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }
       
              
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
