namespace REPETITEURLINK.Entities.Data;

public class RequestCourse:EntityBase
{
    public StatusRequestEnum status { get; set; }
    public string message { get; set; }
    //public List<>
}

public enum StatusRequestEnum
{
    Created,
    Accepted,
    Deleted,
    Read,
    UnRead,
    Rejected,
}