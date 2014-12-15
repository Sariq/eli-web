using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

[ServiceContract]
public interface IEmployee
{
    //[OperationContract]
    //[WebInvoke (
    //    Method = "POST", 
    //    ResponseFormat = WebMessageFormat.Json, 
    //    BodyStyle = WebMessageBodyStyle.Bare,
    //    UriTemplate = "SignIn")
    //]
    //Employee SignIn(string id, string userId, string password);

    [OperationContract]
    [WebInvoke(
         Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "Initialize")
    ]
    Employee Initialize();

    [OperationContract]
    [WebInvoke(
         Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "AddEmployee")
    ]
    void AddEmployee(ValObject employee);
        
}