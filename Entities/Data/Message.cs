using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Message:EntityBase
{
    public Guid SenderId { get; set; }
    [ForeignKey(nameof(SenderId))]
    public User Sender { get; set; }
    public Guid ReceiverId { get; set; }
    [ForeignKey(nameof(ReceiverId))]
    public User Receiver { get; set; }
    public MessageStatus Status { get; set; }
    public MessageType Type { get; set; }
    public bool IsRead { get; set; }
    public Guid MessagePayloadId { get; set; }
    [ForeignKey(nameof(MessagePayloadId))]
    public MessagePayload MessagePayload { get; set; }
}

public enum MessageType
{
    Text,
    Image,
    Video,
    File
}
public enum MessageStatus
{
    Sent,
    Delivered,
    Read
}