using NeinLinq;
using REPETITEURLINK.Entities.Data;
using System.Linq.Expressions;

namespace REPETITEURLINK.Entities.Extensions;

public static class EncadreurExtension
{
    private static Func<Encadreur, EncadreurDto> _model;
    private static Expression<Func<Encadreur, EncadreurDto>> ToDto()
        => entity => new EncadreurDto
        {
            Id = entity.Id,
            DateOfBirth= entity.DateOfBirth,
            IsCertified = entity.IsCertified,
            // User=entity.User.ToDto(),
        };
    [InjectLambda]
    public static EncadreurDto ToDto(this Encadreur entity)
        => (_model ??= ToDto().Compile()).Invoke(entity);
}
