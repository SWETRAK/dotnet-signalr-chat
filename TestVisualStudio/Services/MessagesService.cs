using System;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using TestVisualStudio.Entity;
using TestVisualStudio.Hubs;
using TestVisualStudio.Models.Dtos;
using TestVisualStudio.Models.Mappers;

namespace TestVisualStudio.Services;

public interface IMessagesService
{
    public IEnumerable<OutgoingMessageDto> GetAllPreviousMessages();

    public OutgoingMessageDto SendNewMessage(IncomingMessageDto incomingMessageDto);
}

public class MessagesService : IMessagesService
{

    private readonly IHubContext<MessagesHub, IMessagesHub> _messagesHub;
    private readonly IMapper _mapper;
    private readonly ChatDbContext _dbContext;

    public MessagesService(
        IHubContext<MessagesHub, IMessagesHub> messagesHub,
        IMapper mapper,
        ChatDbContext dbContext
        )
    {
        this._messagesHub = messagesHub;
        this._mapper = mapper;
        this._dbContext = dbContext;
    }

    public IEnumerable<OutgoingMessageDto> GetAllPreviousMessages()
    {
        var dbResult = this._dbContext.Messages.ToList();

        var result = this._mapper.Map<List<OutgoingMessageDto>>(dbResult);

        return result;
    }

    public OutgoingMessageDto SendNewMessage(IncomingMessageDto incomingMessageDto)
    {
        var messageEntity = this._mapper.Map<MessageEntity>(incomingMessageDto);
        this._dbContext.Messages.Add(messageEntity);
        this._dbContext.SaveChanges();
        var result = this._mapper.Map<OutgoingMessageDto>(messageEntity);
        this._messagesHub.Clients.All.ReceiveMessages(result);
        return result;
    }
}

