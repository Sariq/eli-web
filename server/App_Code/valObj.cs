using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for valObj
/// </summary>



[DataContract]
public class valObj
{

    [DataMember]
    public int taskIds { get; set; }
    [DataMember]
    public string action { get; set; }
    [DataMember]
    public string userName { get; set; }
    [DataMember]
    public string id { get; set; }
}