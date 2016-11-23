using System;
using System.Linq;
using System.Reflection;
using System.Text;
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
            var type = typeof (TEntity);
            var tableName = typeof(TEntity)
                .GetCustomAttributes(typeof(TableAttribute), true)
                .OfType<TableAttribute>().FirstOrDefault()?.TableName;

            if (string.IsNullOrEmpty(tableName))
            {
                return null;
            }

            var builder = new StringBuilder("select \r\n\t");

            var meta = typeof (TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new
                {
                    propertyName = p.Name,
                    columnAttribute = p.GetCustomAttributes(typeof(ColumnAttribute), true).OfType<ColumnAttribute>().FirstOrDefault(),
                    joinAttribute = p.GetCustomAttributes(typeof(RelationColumnAttribute), true).OfType<RelationColumnAttribute>().FirstOrDefault()
                })
                .Where(p => p.columnAttribute != null || p.joinAttribute != null)
                .Select(p => new
                {
                    p.propertyName,
                    p.joinAttribute,
                    column = QueryAlias(
                        columnName: p.columnAttribute?.ColumnName ?? p.joinAttribute?.FromColumn,
                        joinedTableName: p.joinAttribute?.FromTable ?? tableName
                    )
                })
                .Where(p => !string.IsNullOrEmpty(p.column))
                .ToList();

            builder.Append(string.Join(", \r\n\t", meta.Select(p => AliasProperty(p.column, p.propertyName)).ToArray()));

            builder.Append("\r\n");

            var joins = meta
                .Where(c => c.joinAttribute != null)
                .Select(c => c.joinAttribute)
                .Select(join => 
                $"\r\n\tinner join [{join.FromTable}] on [{tableName}].[{join.ReferenceId}] = [{join.FromTable}].[{join.RemoteId}]")
                .ToList();

            var joinBuilder = new StringBuilder();
            joinBuilder.Append($"[{tableName}]");

            if (joins.Count > 0)
            {
                joinBuilder.Append(joins[0]);
            }

            foreach (var join in joins.Skip(1))
            {
                joinBuilder.Insert(0, "(");
                joinBuilder.Append(")");
                joinBuilder.Append(join);
            }

            builder.Append("\r\n");

            builder.Append($"from {joinBuilder}");

            return builder.ToString();
        }

        private static string QueryAlias(
            string columnName,
            string joinedTableName)
        {
            return string.IsNullOrEmpty(joinedTableName)
                ? $"[{columnName}]"
                : $"[{joinedTableName}].[{columnName}]";
        }

        private static string AliasProperty(string column, string property) =>
            string.Equals(column, property, StringComparison.OrdinalIgnoreCase)
                ? $"{column}"
                : $"{column} as [{property}]";
    }


    public static class Extensions
    {
        public static string Repeat(char c, int times) => new string(Enumerable.Range(0, times).Select(_ => c).ToArray());
    }
}
