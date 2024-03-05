using GymBro.Abstractions.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.Persistence
{
    public sealed class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;

        public SqlConnectionFactory(  IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection is not defined in config");
            _connectionString = conString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection is null || _connection.State!=ConnectionState.Open)
            {
                _connection=new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }
        public void Dispose()
        {
            if (_connection is not null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}
