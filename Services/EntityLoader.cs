using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace Backend.Services
{
    public interface IEntityLoader<TEntity>
    {
        TEntity Load(int id, IDbConnection connection);
        ICollection<TEntity> LoadList(IDbConnection connection);
    }

    public class EntityLoader<TEntity> : IEntityLoader<TEntity>
    {
        private readonly IQueryBuilder _queryBuilder;

        public EntityLoader(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public TEntity Load(int id, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> LoadList(IDbConnection connection)
        {
            return connection.Query<TEntity>(_queryBuilder.CreateQueryFor<TEntity>(), new {}).ToList();
        }
    }
}
