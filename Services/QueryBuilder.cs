using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Backend.Metadata;

namespace Backend.Services
{
    public interface IQueryBuilder
    {
        string CreateQueryFor<TEntity>();
    }

    public class QueryBuilder : IQueryBuilder
    {
        public string CreateQueryFor<TEntity>()
        {
            var tableName = typeof(TEntity).GetCustomAttribute<TableAttribute>()?.TableName;

            if (string.IsNullOrEmpty(tableName))
            {
                return null;
            }

            var builder = new StringBuilder("select ");

            builder.Append(string.Join(
                ", ",
                typeof (TEntity)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(p => new
                    {
                        propertyName = p.Name,
                        column = p.GetCustomAttribute<ColumnAttribute>()?.ColumnName
                    })
                    .Where(p => !string.IsNullOrEmpty(p.column))
                    .Select(p => $"{p.column} {p.propertyName}")
            ));

            builder.Append($" from {tableName}");

            return builder.ToString();
        }
    }
}
