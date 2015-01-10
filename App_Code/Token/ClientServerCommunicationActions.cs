using JWT;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;


public class ClientServerCommunicationActions
{
    public void SetTokenToHeader(User user)
    {
        SetTokenToHeader(user._id, user.isRememberMe);
    }

    public void SetTokenToHeader(string id, bool isExp)
    {
        var response = HttpContext.Current.Response;
        var token = new Token(id, isExp);
        response.Headers.Add("id_token", JWT.JsonWebToken.Encode(token, "elile", JwtHashAlgorithm.HS256));
    }
    
    public void SetTokenToHeader(Token token)
    {
        var response = HttpContext.Current.Response;
        response.Headers.Add("id_token", JWT.JsonWebToken.Encode(token, "elile", JwtHashAlgorithm.HS256));
    }

    public Token GetTokenFromHeader()
    {
        var request = HttpContext.Current.Request;
        //string tokenString = request.Headers["Authorization"].Substring("Bearer ".Length);
        var tokenString = HttpContext.Current.Response.Headers.Get("id_token");
        var token = JWT.JsonWebToken.Decode(tokenString, "elile");

        DataContractJsonSerializer serToken = new DataContractJsonSerializer(typeof(Token));
        MemoryStream streamToken = new MemoryStream(Encoding.UTF8.GetBytes(token));
        Token tokenObj = (Token)serToken.ReadObject(streamToken);
        return tokenObj;
    }

    public string GetID_FromTokenInHeader()
    {
        Token token = GetTokenFromHeader();
        return token._id;
    }

    public string GetEXP_FromTokenInHeader()
    {
        Token token = GetTokenFromHeader();
        return token._exp;
    }

    public string GetJTI_FromTokenInHeader()
    {
        Token token = GetTokenFromHeader();
        return token._jti;
    }

}