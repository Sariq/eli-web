using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.Serialization;

public class ValObject
{
    public String _id;
    Service service = new Service();

    protected async Task<ValObject> GetObject(string key, string value, string collectionName)
    {
        var collection = service.GetCollection(collectionName);
        var obj = await collection.FindOneAsAsync<ValObject>(new QueryDocument(key, value));
        return obj;
    }

    protected async void InsertObject(ValObject obj, string collectionName)
    {
        var collection = service.GetCollection(collectionName);
        await collection.SaveAsync(obj);
    }

    protected async void RemoveObject(string id, string collectionName)
    {
        var collection = service.GetCollection(collectionName);
        await collection.RemoveAsync(new QueryDocument("_id", id));
    }

    protected async void UpdateObject(ValObject obj, string collectionName)
    {
        var collection = service.GetCollection(collectionName);
        await collection.UpdateAsync(new QueryDocument("_id", obj._id), new UpdateDocument(new BsonDocument(obj.ToBsonDocument())));
    }

    protected async Task<List<ValObject>> GetAllObject(string collectionName)
    {
        var collection = service.GetCollection(collectionName);
        var x = collection.Count();
        var obj = await collection.FindAllAsAsync<ValObject>();

        return obj.ToList<ValObject>();
    }
}