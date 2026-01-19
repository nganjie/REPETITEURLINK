using REPETITEURLINK.Services.Queues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace REPETITEURLINK.Services;

public class CoreQueueService
{
    private readonly Channel<PushMessage> _messageChannel = Channel.CreateUnbounded<PushMessage>();

    public void EnqueueMessage(PushMessage message)
    {
        _messageChannel.Writer.TryWrite(message);
    }


    public ChannelReader<PushMessage> GetMessageReader() => _messageChannel.Reader;
}
