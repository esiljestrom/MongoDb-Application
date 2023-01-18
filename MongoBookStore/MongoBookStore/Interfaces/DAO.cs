using MongoDB.Bson;
using System.Collections.Generic;

namespace MongoBookStore.Interfaces
{
    internal interface DAO // Interface. Database Access Object
    {
        public bool Create<T>(T document);
        public T ReadOne<T>(ObjectId objectId);
        public bool Update<T>(ObjectId objectId, int property, string value);
        public bool Delete(ObjectId objectId);

        public ObjectId GetID();
        public List<T> GetAll<T>();
    }
}
