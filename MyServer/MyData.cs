using System;
using NServiceBus.Saga;

namespace MyServer
{
    public class MyData : ISagaEntity
    {
        [Unique]
        public virtual int MessageKey { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string OriginalMessageId { get; set; }
        public virtual string Originator { get; set; }
        public virtual int RecordVersion { get; set; }
    }
}