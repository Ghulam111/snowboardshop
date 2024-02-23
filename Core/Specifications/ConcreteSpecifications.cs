using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ConcreteSpecifications<t> : ISpecifications<t>

    {
        public ConcreteSpecifications()
        {
        }

        public ConcreteSpecifications(Expression<Func<t,bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<t, bool>> Criteria {get;}

        public List<Expression<Func<t, object>>> Includes {get;} = new List<Expression<Func<t, object>>>();

        public Expression<Func<t, object>> OrderBY {get;private set;}

        public Expression<Func<t, object>> OrderByDescending {get;private set;}

        public int Skip {get;private set;}

        public int Take {get;private set;}

        public bool IsPagingEnabled {get;private set;}

        


        protected void AddInclude(Expression<Func<t,object>> expression){
            Includes.Add(expression);
        }

        protected void AddOrderby(Expression<Func<t,object>> orderby)
        {
            OrderBY = orderby;
        }
        protected void AddOrderbyDescending(Expression<Func<t,object>> orderbydescending)
        {
            OrderByDescending = orderbydescending;
        }

        protected void ApplyPagging( int skip , int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}