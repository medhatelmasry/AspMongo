using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AspMongo.Models {
  public class Student {
      [BsonId]
      [BsonRepresentation(BsonType.ObjectId)]
      public string StudentId { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      [BsonElement("School")]
      public string Department { get; set; }
  }
}