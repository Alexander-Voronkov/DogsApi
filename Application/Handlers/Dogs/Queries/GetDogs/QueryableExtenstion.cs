using System.Linq.Expressions;

namespace Application.Handlers.Dogs.Queries.GetDogs
{
    public static class QueryableExtenstion
    {
        public static IOrderedQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName, bool ascending = true)
        {
            var propertyInfo = typeof(T).GetProperties().FirstOrDefault(x => x.Name.ToLower() == propertyName.ToLower());

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type {typeof(T).FullName}");
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var lambda = Expression.Lambda(property, parameter);

            var orderByMethod = ascending ? "OrderBy" : "OrderByDescending";

            var orderByExpression = Expression.Call(
                typeof(Queryable),
                orderByMethod,
                new Type[] { typeof(T), propertyInfo.PropertyType },
                source.Expression,
                lambda
            );

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
