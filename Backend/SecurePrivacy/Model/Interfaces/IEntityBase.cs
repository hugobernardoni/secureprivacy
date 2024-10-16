using MongoDB.Bson;

namespace Model.Interfaces
{
    public interface IEntityBase
    {
        ObjectId Id { get; set; }
    }
}
