using System;
namespace TestVisualStudio.Models.Dtos;

public class IncomingMessageDto
{
    public string Author { get; set; }
    public string Message { get; set; }
    public DateTime SendTime { get; set; }
}

