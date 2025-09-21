﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieDirectorApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
