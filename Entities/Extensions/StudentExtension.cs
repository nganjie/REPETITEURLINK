using NeinLinq;
using REPETITEURLINK.Entities.Data;
using System.Linq.Expressions;

namespace REPETITEURLINK.Entities.Extensions;

public static class StudentExtension
{
    private static Func<Student, StudentDto> _model;
    private static Expression<Func<Student, StudentDto>> ToDto()
        => entity => new StudentDto
        {
            Id = entity.Id,
            SchoolLevelId = entity.SchoolLevelId,
            SchoolLevel=entity.SchoolLevel.ToSchoolLevel(),
           // User=entity.User.ToDto(),
        };
    [InjectLambda]
    public static StudentDto ToDto(this Student entity)
        => (_model ??= ToDto().Compile()).Invoke(entity);
}
