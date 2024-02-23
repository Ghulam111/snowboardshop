using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecifications<T>
    {
        Expression<Func<T,bool>> Criteria {get;}

        List<Expression<Func<T,object>>> Includes {get;}


        Expression<Func<T,object>> OrderBY {get;}

        Expression<Func<T,Object>> OrderByDescending{get;}
        

        int Skip {get;}

        int Take {get;}

        bool IsPagingEnabled {get;}


        



    }
}