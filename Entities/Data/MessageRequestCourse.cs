using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class MessageRequestCourse:Message
{
    public Guid RequestCourseId { get; set; }
    [ForeignKey(nameof(RequestCourseId))]
    public RequestCourse RequestCourse { get; set; }
}

public class MessageRequestCourseDto: Message
{
    public Guid RequestCourseId { get; set; }
    public RequestCourseDto RequestCourse { get; set; }
}