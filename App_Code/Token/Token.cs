using System;
using System.Runtime.Serialization;

[DataContract]
public class Token
{
    [DataMember] 
    public string _id { get; set; }
    [DataMember] 
    public string _exp { get; set; }
    [DataMember] 
    public string _jti { get; set; }
    

    public Token(string id, bool isExp = false)
    {
        DateTime now = DateTime.UtcNow;

        _id = id;
        if (isExp)
            _exp = GetTimestamp(now.AddHours(12));
        _jti = Guid.NewGuid().ToString("N");
    }

    private static String GetTimestamp(DateTime value)
    {
        long ticks = value.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
        ticks /= 10000000;
        return ticks.ToString();
    }
}