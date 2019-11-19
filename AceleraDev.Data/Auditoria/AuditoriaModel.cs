using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AceleraDev.Data.Auditoria
{
    public class AuditoriaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("usuarioId")]
        public string UsuarioId { get; set; }

        public DateTime Data { get; set; }

        public string Entidade { get; set; }

        public string Operacao { get; set; }

        public string EntidadeId { get; set; }
    }
}
