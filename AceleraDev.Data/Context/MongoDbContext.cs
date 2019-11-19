using AceleraDev.Data.Auditoria;
using MongoDB.Driver;
using System;
using System.Security.Authentication;

namespace AceleraDev.Data.Context
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public const string DATABASE_NAME = "aceleradev-auditoria";

        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };

                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DATABASE_NAME);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<AuditoriaModel> Auditorias
        {
            get
            {
                return _database.GetCollection<AuditoriaModel>("auditoria");
            }
        }
    }
}
