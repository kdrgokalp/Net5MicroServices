using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroService.Products.Entities
{
    public class Product
    {
        //Bson paket olarak ekledik. Dataanotication görmesi için
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //Mssql deki IdentitySpecific gibidir. Sürekli artmasını sağlar.
        public string Id { get; set; } // Id değeri mongo db kullandığımız için string yaptık. Çünkü string Id değeri bson olarak gösterebilelim.
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFie { get; set; }
        public decimal Price { get; set; }
    }
}
