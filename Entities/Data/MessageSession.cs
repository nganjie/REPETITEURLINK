using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class MessageSession:Message
{
    public Guid SessionRepetitionId { get; set; }
    [ForeignKey(nameof(SessionRepetitionId))]
    public SessionRepetition SessionRepetition { get; set; }
}

public class MessageSessionDto: Message
{
    public Guid SessionRepetitionId { get; set; }
    public SessionRepetitionDto SessionRepetition { get; set; }
}