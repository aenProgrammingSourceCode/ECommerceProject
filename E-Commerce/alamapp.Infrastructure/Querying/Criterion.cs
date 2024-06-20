using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Querying
{
   public class Criterion
    {
        private string _propertyName;

        public string PropertyName
        {
            get { return _propertyName; }
           
        }
        private object _value;

        public object Value
        {
            get { return _value; }
           
        }
        private CriteriaOperator _criteriaOperator;

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
           
        }
       public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
       {
           _propertyName = propertyName;
           _value = value;
           _criteriaOperator = criteriaOperator;
       }

       public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
       {
           string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
           Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator);
           return myCriterion;

       }
    }
}
