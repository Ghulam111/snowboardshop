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



        protected void AddInclude(Expression<Func<t,object>> expression){
            Includes.Add(expression);
        }

    }
}