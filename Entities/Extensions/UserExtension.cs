using NeinLinq;
using REPETITEURLINK.Entities.Data;
using System.Linq.Expressions;

namespace REPETITEURLINK.Entities.Extensions;

public static class UserExtension
{
    private static Func<User, UserDto> _model;
    private static Expression<Func<User, UserDto>> ToDto()
        => entity => new UserDto {
            Id = entity.Id,
            FirstName=entity.FirstName,
            LastName=entity.LastName,
            Email=entity.Email,
            Sexe=entity.Sexe,
            RefreshToken=entity.RefreshToken,
            LastLoginAt=entity.LastLoginAt,
            PhoneNumber=entity.PhoneNumber,
            ParentSubjectType=entity.ParentSubjectType,
            ParentSubjectId=entity.ParentSubjectId,
            Role=entity.Role,
        };
    [InjectLambda]
    public static UserDto ToDto(this User entity)
        => (_model ??= ToDto().Compile()).Invoke(entity);
   // public IQueryable<User> IncludeRelatives(this IQueryable<User> query)=>
}
