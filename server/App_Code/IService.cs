using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    //[OperationContract]
    //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    //    BodyStyle = WebMessageBodyStyle.Wrapped,
    //     UriTemplate = "json/{firstN}")]
    //Book json(string firstN);
    //[OperationContract]
    //[WebInvoke(Method = "POST",
    //    ResponseFormat = WebMessageFormat.Json,
    //    BodyStyle = WebMessageBodyStyle.Wrapped,
    //     UriTemplate = "SaveStudent")]
    //void SaveStudent(Students req);


    //[OperationContract]
    //[WebGet]
    //string GetDataUsingMethod(string value);

    //[OperationContract]
    //[WebGet(RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
    //    BodyStyle = WebMessageBodyStyle.Wrapped,
    //    UriTemplate="/GetDatat/{value}")]
    //Object GetDataUsingURI(String value);


   
        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        //  ResponseFormat = WebMessageFormat.Json,
        //  UriTemplate = "Tasks/SetTasksForMerge")]
        //void CreateNewTaks(valObj values);



        // [OperationContract]
        // [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //     BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "Tasks/GetTasksForMerge/{s}")]
        //Book GetTask(string s);


         [OperationContract]
         [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "Tasks")]
            void addBook(string s,valObj values);
         //GET(ID)
         [OperationContract]
         [WebGet( ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Tasks/TasksForMerge/{id}")]
         valObj GetSingleTask(string id);
         //SAVE(object)  
         [OperationContract]
         [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Tasks/TasksForMerge/{id}")]
         valObj UpdateSingleTask(string id, valObj v);
         //PUT=UPDATE (id,object)
         [OperationContract]
         [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Tasks/TasksForMerge/{id}")]
         valObj PutSingleTask(string id, valObj v);
         //DELETE(id)
         [OperationContract]
         [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Tasks/TasksForMerges/{id}")]
         valObj DeleteSingleTask(string id);

         [OperationContractAttribute(AsyncPattern = true)]
         [WebGet(ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "Tasks/TasksForMerge1/{id}")]
         IAsyncResult BeginServiceAsyncMethod(string id, AsyncCallback callback, object asyncState);

         // Note: There is no OperationContractAttribute for the end method.
         string EndServiceAsyncMethod(IAsyncResult result);

    
}


