using System.Text.Json.Serialization;

namespace CRUDOperationWithElasticSearch.Models
{
    public class Backpack : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }
    }
}
