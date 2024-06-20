using alamapp.Infrastructure.Querying;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository
{
   public static class QueryTranslator
    {
       public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criterias)
       {
           BuildQueryFrom(query, criterias);
           if (query.OrderByProperty != null)
               criterias.AddOrder(new Order(query.OrderByProperty.ProperityName, !query.OrderByProperty.Desc));
           return criterias;
       }

       private static void BuildQueryFrom(Query query, ICriteria criteria)
       {
           IList<ICriterion> criterionss=new List<ICriterion>();
           
           if(query.Criteria !=null)
           {
             
               foreach(Criterion c in query.Criteria)
               {
                   ICriterion criterions;

                   switch (c.CriteriaOperator)
                   {
                       case CriteriaOperator.Equal:
                           criterions = Expression.Eq(c.PropertyName, c.Value);
                           break;
                       case CriteriaOperator.LesserThenOrEquel:
                           criterions = Expression.Le(c.PropertyName, c.Value);
                           break;
                       
                       default:
                           throw new ArgumentException("No operator defined");
                   }
                   criterionss.Add(criterions);
               }

               if(query.QueryOperator==QueryOperator.And)
               {
                   Conjunction andSubQuery = Expression.Conjunction();
                   foreach(ICriterion criterions in criterionss)
                   {
                       andSubQuery.Add(criterions);
                   }
                   criteria.Add(andSubQuery);
               }
               else
               { 
                   Disjunction orSubQuery=Expression.Disjunction();
                   foreach(ICriterion criterions in criterionss)
                   {
                       orSubQuery.Add(criterions);
                   }
                   criteria.Add(orSubQuery);
               }

               foreach(Query sub in query.SubQueries)
               {
                   BuildQueryFrom(sub, criteria);
               }
           }
       }
    }
}
