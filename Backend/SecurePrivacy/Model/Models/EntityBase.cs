using Model.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class EntityBase : IEntityBase
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
