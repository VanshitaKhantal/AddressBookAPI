using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IModel = Microsoft.EntityFrameworkCore.Metadata.IModel;

namespace BusinessLayer.Messaging
{
    public class RabbitMQConnection
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQConnection(string hostName = "localhost")
        {
            _factory = new ConnectionFactory() { HostName = hostName };
        }

        public IModel GetChannel()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = _factory.CreateConnection();
                _channel = (IModel)_connection.CreateModel();
            }
            return _channel;
        }
    }
}
