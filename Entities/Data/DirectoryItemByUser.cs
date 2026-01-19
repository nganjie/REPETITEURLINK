using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class DirectoryItemByUser:EntityBase
{
    public Guid DirectoryItemId { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(DirectoryItemId))]
    public DirectoryItem DirectoryItem { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}

public class DirectoryItemByUserDto : EntityBase
{
    public Guid DirectoryItemId { get; set; }

    public DirectoryItemDto DirectoryItem { get; set; }
    public UserDto User { get; set; }
}