using iTemo.jsGrid;
using System;
using System.Linq;
using System.Linq.Expressions;
using iTemo.Core.Enum;

namespace iTemo.Business.Implementation
{
    public class BaseBusiness
    {
        protected static void Paging<T>(ref IQueryable<T> records, GridSettings gridSettings)
            where T : class
        {
            records = records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }
        protected static void OrderBy<T>(ref IQueryable<T> records, GridSettings gridSetting)
        {
            var methodName = gridSetting.SortOrder == SortOrder.Asc ? "OrderBy" : "OrderByDescending";
            var parameter = Expression.Parameter(records.ElementType, "p");

            var memberAccess = Expression.Property(parameter, gridSetting.SortField);

            var orderByLambda = Expression.Lambda(memberAccess, parameter);

            var result = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { records.ElementType, memberAccess.Type },
                records.Expression,
                Expression.Quote(orderByLambda));

            records = records.Provider.CreateQuery<T>(result);
        }

        protected static void Paging<T>(ref IQueryable<T> records, int page, out int currentPage, out int totalPages)
            where T : class
        {
            var numberOfRecords = 10;

            #region correct paging info
            if (numberOfRecords <= 0)
            {
                numberOfRecords = 1;
            }

            var totalItems = records.Count();
            totalPages = (int)Math.Ceiling((decimal)totalItems / numberOfRecords);
            currentPage = page;
            if (totalPages <= 0)
            {
                totalPages = 1;
            }

            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }
            #endregion

            records = records.Skip(numberOfRecords * (currentPage - 1)).Take(numberOfRecords);
        }
        protected static void OrderBy<T>(ref IQueryable<T> records, string sortBy, SortTypeEnum sortType)
        {
            var methodName = sortType == SortTypeEnum.Asc ? "OrderBy" : "OrderByDescending";
            var parameter = Expression.Parameter(records.ElementType, "p");

            var memberAccess = Expression.Property(parameter, sortBy);

            var orderByLambda = Expression.Lambda(memberAccess, parameter);

            var result = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { records.ElementType, memberAccess.Type },
                records.Expression,
                Expression.Quote(orderByLambda));

            records = records.Provider.CreateQuery<T>(result);
        }
    }
}
