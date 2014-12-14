using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

[DataContract]
public class Book
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public String ISBN { get; set; }
    [DataMember]
    public String Title { get; set; }
    [DataMember]
    public String Publisher { get; set; }

}
