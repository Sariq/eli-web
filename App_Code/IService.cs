using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "GetObject/{id}")]
    ValObject GetObject(string id);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "InsertObject")]
    void InsertObject(ValObject obj);

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "RemoveObject/{id}")]
    void RemoveObject(string id);

    [OperationContract]
    [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "UpdateObject")]
    void UpdateObject(ValObject obj);

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "GetAllObject")]
    List<ValObject> GetAllObject();

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "MyFunction/{str}")]
    List<Employee> MyFunction(string str);

////    [OperationContract]
////    string GetData(int value);

////    [OperationContract]
////    CompositeType GetDataUsingDataContract(CompositeType composite);

////    // TODO: Add your service operations here
////}

////// Use a data contract as illustrated in the sample below to add composite types to service operations.
////[DataContract]
////public class CompositeType
//{
    //bool boolValue = true;
    //string stringValue = "Hello ";

    //[DataMember]
    //public bool BoolValue
    //{
    //    get { return boolValue; }
    //    set { boolValue = value; }
    //}

    //[DataMember]
    //public string StringValue
    //{
    //    get { return stringValue; }
    //    set { stringValue = value; }
    //}
}
