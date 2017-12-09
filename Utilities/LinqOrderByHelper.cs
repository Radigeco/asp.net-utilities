using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with IQueryable objects
    /// </summary>
    public static class LinqOrderByHelper
    {
        /// <summary>
        /// Orders the given IQueryable based on a given sortexpression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortExpression)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "source is null.");

            if (string.IsNullOrEmpty(sortExpression))
                throw new ArgumentException("sortExpression is null or empty.", nameof(sortExpression));

            var parts = sortExpression.Split(' ');
            var isDescending = false;
            var tType = typeof(T);

            if (parts.Length > 0 && parts[0] != "")
            {
                var propertyName = parts[0];

                if (parts.Length > 1)
                {
                    isDescending = parts[1].ToLower().Contains("esc");
                }

                PropertyInfo prop = tType.GetProperty(propertyName);

                if (prop == null)
                {
                    throw new ArgumentException($"No property '{propertyName}' on type '{tType.Name}'");
                }

                var funcType = typeof(Func<,>)
                    .MakeGenericType(tType, prop.PropertyType);

                var lambdaBuilder = typeof(Expression)
                    .GetMethods()
                    .First(x => x.Name == "Lambda" && x.ContainsGenericParameters && x.GetParameters().Length == 2)
                    .MakeGenericMethod(funcType);

                var parameter = Expression.Parameter(tType);
                var propExpress = Expression.Property(parameter, prop);

                var sortLambda = lambdaBuilder
                    .Invoke(null, new object[] { propExpress, new ParameterExpression[] { parameter } });

                var firstOrDefault = typeof(Queryable)
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == (isDescending ? "OrderByDescending" : "OrderBy") && x.GetParameters().Length == 2);
                if (firstOrDefault != null)
                {
                    var sorter = firstOrDefault
                        .MakeGenericMethod(new[] { tType, prop.PropertyType });

                    return (IQueryable<T>)sorter
                        .Invoke(null, new object[] { source, sortLambda });
                }
            }

            return source;
        }

        /// <summary>
        /// Returns a valid sort expression 
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static string GetSortExpression(string sortBy, string sortOrder)
        {
            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Id";
            }

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "ASC";
            }

            return $"{sortBy} {sortOrder}";
        }

        /// <summary>
        /// Determines if a given IQueryable is already ordered or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public static bool IsOrdered<T>(this IQueryable<T> queryable)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            return queryable.Expression.Type == typeof(IOrderedQueryable<T>);
        }
    }
}