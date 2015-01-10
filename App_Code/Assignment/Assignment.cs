using System.Runtime.Serialization;

[DataContract]
public class Assignment : DatabaseObject
{
    [DataMember]
    public User user { get; set; }
    [DataMember] 
    public string title { get; set; }
    [DataMember]
    public string content { get; set; }
    [DataMember]
    public bool isDone { get; set; }


    public Assignment(User user, string title, string content, bool isDone)
        : base()
    {
        this.user = user;
        this.title = title;
        this.content = content;
        this.isDone = isDone;
    }

    public Assignment(Assignment assignment)
        : base()
    {
        this.user = assignment.user;
        this.title = assignment.title;
        this.content = assignment.content;
        this.isDone = assignment.isDone;
    }

}