using System;
namespace TestVisualStudio.Entity;

public class MessageEntity
{
    public Guid Id { get; set; }
    public string Author { get; set; }
    public string Message { get; set; }
    public DateTime sendTime { get; set; }
}

