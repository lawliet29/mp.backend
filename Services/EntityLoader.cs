using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Backend.Services
{
    public interface IEntityLoader<TEntity>
    {
        TEntity Load(int id);
        ICollection<TEntity> LoadList();
    }

    public class EntityLoader<TEntity> : IEntityLoader<TEntity>
    {
        private readonly IDbConnection _connection;
        private readonly IQueryBuilder _queryBuilder;

        public EntityLoader(IDbConnection connection, IQueryBuilder queryBuilder)
        {
            _connection = connection;
            _queryBuilder = queryBuilder;
        }

        public TEntity Load(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> LoadList()
        {
            return _connection.Query<TEntity>(_queryBuilder.CreateQueryFor<TEntity>()).ToList();
        }
    }
}
