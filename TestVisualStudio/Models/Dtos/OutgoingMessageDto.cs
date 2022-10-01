using System;
namespace TestVisualStudio.Models.Dtos;

public class OutgoingMessageDto
{
    public string Id { get; set; }
    public string Author { get; set; }
    public string Message { get; set; }
    public DateTime SendTime { get; set; }
}

