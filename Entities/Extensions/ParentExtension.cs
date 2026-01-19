using NeinLinq;
using REPETITEURLINK.Entities.Data;
using System.Linq.Expressions;

namespace REPETITEURLINK.Entities.Extensions;

public static class ParentExtension
{
    #region DirectoryItemDto

    private static Func<Parent, ParentDto> _model;
    private static Expression<Func<Parent, ParentDto>> ToDto()
        => entity => new ParentDto
        {
            Id = entity.Id,
            User=entity.User.ToDto(),
        };
    [InjectLambda]
    public static ParentDto ToDto(this Parent entity)
        => (_model ??= ToDto().Compile()).Invoke(entity);

    #endregion
}
