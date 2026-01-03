namespace REPETITEURLINK.Entities.Data;

public class User:BaseUserEntity
{
    public string ParentSubjectId { get; set; }
    public UserSubjectType ParentSubjectType { get; set; }
}

public enum UserSubjectType
{
    Parent,
    Encadreur,
    Student
}

public class UserDto
{

}