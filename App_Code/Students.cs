using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Students
/// </summary>
/// 
 [DataContract]
public class Students
{

        [DataMember]
        public String FirstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
        [DataMember]
        public String LastName
        {
            get { return LastName; }
            set { LastName = value; }
        }
    
}