namespace REPETITEURLINK.Entities.Data;

public class User:BaseUserEntity
{
    public UserRoles Role { get; set; }
    public Guid? ParentSubjectId { get; set; }
    public Guid? GoogleId { get; set; }
    public UserSubjectType ParentSubjectType { get; set; }
}

public enum UserSubjectType
{
    Parent,
    Encadreur,
    Student,
    None
}

public class UserDto : BaseUserEntity
{
    public UserRoles Role { get; set; }
    public Guid? ParentSubjectId { get; set; }
    public UserSubjectType ParentSubjectType { get; set; }
}