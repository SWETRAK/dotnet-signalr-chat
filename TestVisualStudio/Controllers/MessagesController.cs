using Microsoft.AspNetCore.Mvc;
using TestVisualStudio.Models.Dtos;
using TestVisualStudio.Services;

namespace TestVisualStudio.Controllers;

[ApiController]
[Route("messages")]
public class MessagesController : ControllerBase
{

    private readonly ILogger<MessagesController> _logger;
    private readonly IMessagesService _messagesService;

    public MessagesController(
        ILogger<MessagesController> logger,
        IMessagesService messagesService
        )
    {
        _logger = logger;
        _messagesService = messagesService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OutgoingMessageDto>> Get()
    {
        var listOfMessages = _messagesService.GetAllPreviousMessages();
        return Ok(listOfMessages);
    }

    [HttpPost]
    public ActionResult<OutgoingMessageDto> SendMessage([FromBody] IncomingMessageDto messageDto)
    {
        var result = _messagesService.SendNewMessage(messageDto);
        return Created("", result);
    }
}

