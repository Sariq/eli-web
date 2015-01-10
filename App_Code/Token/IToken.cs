using System.ServiceModel;
using System.ServiceModel.Web;

public interface IToken
{
    [OperationContract]
    [WebInvoke(
        Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "RefreshToken")
    ]
    void RefreshToken();
}