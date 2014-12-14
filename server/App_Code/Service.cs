using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Web;
using System.IO;
using System.IO.Compression;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
//[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession
,ConcurrencyMode = ConcurrencyMode.Multiple)] 
public class Service : IService
{
 
    public int i=0;
    //public string GetDataUsingMethod(string value){
    //    return value + " I am returned by Method";
    //}
    //public Object GetDataUsingURI(String value)
    //{
        
    //    //JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
    //   // myJavaScriptSerializer.Serialize(value);
    //    Debug.WriteLine(value);
    //    return (value); 
    //}

    //public Book json(string firstN)
    //{
    //    Debug.WriteLine(firstN);
    //    //Debug.WriteLine(new Students { FirstName = "Sari", LastName = "qash" });
    //    Book book = new Book();
    //    book.Title = "myTitle";
    //    book.ISBN = "123456789s789777";
    //    book.Publisher = "sari2222";
    //    JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
    //    string resultStr = myJavaScriptSerializer.Serialize(book);
    //    return book;
    //}


    //public void SaveStudent(Students req)
    //{
    //    JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
    //    //Students emp=myJavaScriptSerializer.Deserialize(req, emp);
    //    Debug.WriteLine("student!!");
    //   // StreamReader reader = new StreamReader(req);
    //    Debug.WriteLine(req.FirstName);
    //    //string text =reader.ReadToEnd();
        
    //   // Debug.WriteLine(text);
   
    //}






    //public void CreateNewTaks(valObj values)
    //{
       
        //Debug.WriteLine(values.action);
        //Debug.WriteLine(values.userName);
        //Debug.WriteLine(values.taskIds + 7);

        //MongoClient client = new MongoClient();
        //var server = client.GetServer();
        //var db = server.GetDatabase("bookStore");
        //var collection = db.GetCollection<Book>("Book");
        //Book book = new Book();
        //book.Title = "myTitle";
        //book.ISBN = "123456789s789777";
        //book.Publisher = "sari2222";
        //Convert.ToString((ObjectId.GenerateNewId()));
        //values._id = Convert.ToString((ObjectId.GenerateNewId())); 
        //collection.Save(values);

        //MongoClient client = new MongoClient();
        //var server = client.GetServer();
        //var db = server.GetDatabase("myTest");
        //var collection = db.GetCollection<valObj>("valObj");
        //collection.Save(values);
    //}


    //public Book GetTask(string s)
    //{
    //    Debug.WriteLine("vaaaaXXXaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaXXXn");
    //     Book book = new Book();
    //    book.Title = "myTitle";
    //    book.ISBN = "123456789s789777";
    //    book.Publisher = "sari2222";
    //    return book;
    //}



    public void addBook(string s,valObj values)
    {
        //Debug.WriteLine(values.action);
        //Debug.WriteLine(values.userName);
        //Debug.WriteLine(values.taskIds + 7);

        //Debug.WriteLine(values.action);
        //Debug.WriteLine(values.userName);
        //Debug.WriteLine(values.taskIds + 7);

        MongoClient client = new MongoClient();
        var server = client.GetServer();
        var db = server.GetDatabase("bookStore");
        var collection = db.GetCollection<Book>("Book");
        values.id = Convert.ToString((ObjectId.GenerateNewId()));
        collection.Save(values);
        
    }

    //public Book GetSingleTask(string s)
    //{
    //    throw new NotImplementedException();
    //}
    public valObj GetSingleTask(string id)
    {
        Thread.Sleep(10000);
        i++;
        Debug.WriteLine(" Instance:" +
          i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() +
          " Time:" + DateTime.Now.ToString() + "\n\n");
      
        //Debug.WriteLine("vaaaaXXXaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaXXXn");
        Book book = new Book();
        book.Title = "myTitle";
        book.ISBN = "123456789s789777";
        book.Publisher = "sari2222";
        valObj val = new valObj();
        val.id = Convert.ToString((ObjectId.GenerateNewId()));
        val.taskIds = 1;
        val.action = "Karin";
        val.userName = "Sari";
        return val;
    }

    public valObj UpdateSingleTask(string id, valObj v)
   {
       v.taskIds = 1;
       v.action = "Sari";
       v.userName = "Sari";
       return v;
   }
    public valObj PutSingleTask(string id, valObj v)
   {
       v.taskIds = 1;
       v.action = "Sari";
       v.userName = "qashuw";
       return v;
   }
    public valObj DeleteSingleTask(string id)
   {
       valObj val = new valObj();
       val.id = Convert.ToString((ObjectId.GenerateNewId()));
       val.taskIds = 1;
       val.action = "Delete";
       val.userName = "Delete";
       return val;
   }


    public IAsyncResult BeginServiceAsyncMethod(string msg, AsyncCallback callback, object asyncState)
    {
        Thread.Sleep(2000);
        Debug.WriteLine(msg);
        //Console.WriteLine("BeginServiceAsyncMethod called with: \"{0}\"", msg);
        return new CompletedAsyncResult<string>(msg);
    }

    public string EndServiceAsyncMethod(IAsyncResult r)
    {
        Debug.WriteLine("vaaaaXXXaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaXXXn");
        CompletedAsyncResult<string> result = r as CompletedAsyncResult<string>;
        Debug.WriteLine("EndServiceAsyncMethod called with: \"{0}\"", result.Data);
        return result.Data;
    }


   
}
