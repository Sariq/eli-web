using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

public class Service
{
    public Service()
    {
        var db = GetDatabase();
    }

    public MongoDatabase GetDatabase()
    {
        MongoClient client = new MongoClient();
        var server = client.GetServer();
        var database = server.GetDatabase("EliProject");
        return database;
    }

    public void CreateCollection(string collectionName)
    {
        var database = GetDatabase();
        var collection = database.CreateCollection(collectionName);
        //Convert.ToString((ObjectId.GenerateNewId()));
    }

    public MongoCollection GetCollection(string collectionName)
    {
        var database = GetDatabase();
        var collection = database.GetCollection(collectionName);
        return collection;
    }


    //public string GetData(int value)
    //{
    //    return string.Format("You entered: {0}", value);
    //}

    //public CompositeType GetDataUsingDataContract(CompositeType composite)
    //{
    //    if (composite == null)
    //    {
    //        throw new ArgumentNullException("composite");
    //    }
    //    if (composite.BoolValue)
    //    {
    //        composite.StringValue += "Suffix";
    //    }
    //    return composite;
    //}



    //    public UserService MyFunction(string str)
    //{
    //    UserService val3 = new UserService();
    //    val3.FirstName = "Karin";
    //    val3.LastName = "B";
    //    val3.UserId = "kkk";
    //    val3.Password = "kkk";
    //    val3._id = Convert.ToString((ObjectId.GenerateNewId()));

    //    UserService val2 = new UserService();
    //    val2.FirstName = "Sari";
    //    val2.LastName = "Q";
    //    val2.UserId = "sss";
    //    val2.Password = "sss";
    //    val2._id = Convert.ToString((ObjectId.GenerateNewId()));

    //    Debug.WriteLine("str");

    //    var collection = CreateCollection("User");
    //    InsertObject(val2);
    //    InsertObject(val3);

    //    Debug.WriteLine("str");
      
    //    //RemoveFromCollection("548b038120e1de04a0192091", "B");
    //    //UpdateInCollection(val2, "A");
    //    //try
    //    //{
    //    //    var obj = GetObjById("1", "B");

    //    //    Debug.WriteLine(obj);
    //    //    return obj;
    //    //}
    //    //catch
    //    //{
    //    //    Debug.WriteLine("str");
    //    //    return null;
    //    //}
    //    //var obj = GetAllObjInCollection("A");
    //    return val2;
    //}


    //public async void InsertInCollection(MongoCollection collection, ValObject obj)
    //{
    //    await collection.SaveAsync(obj);
    //}

    //public async void RemoveFromCollection(string id, string collectionName)
    //{
    //    var collection = getCollection(collectionName);
    //    await collection.RemoveAsync(new QueryDocument("_id", id));
    //}

    //public async void UpdateInCollection(ValObject obj, string collectionName)
    //{
    //    var collection = getCollection(collectionName);
    //    await collection.UpdateAsync(new QueryDocument("_id", obj._id), new UpdateDocument(new BsonDocument(obj.ToBsonDocument())));
    //}

    //public async Task<ValObject> GetObject(string id, string collectionName)
    //{
    //    var collection = getCollection(collectionName);
    //    var obj = await collection.FindOneAsAsync<ValObject>(new QueryDocument("_id", id));

    //    return obj;
    //}

    //public async Task<List<ValObject>> GetAllObjInCollection(string collectionName)
    //{
    //    var collection = getCollection(collectionName);
    //    var obj = await collection.FindAllAsAsync<ValObject>();

    //    return obj.ToList<ValObject>();
    //}
}
