using System;
using AutoMapper;
using TestVisualStudio.Entity;
using TestVisualStudio.Models.Dtos;

namespace TestVisualStudio.Models.Mappers;

public class MessageMappingProfile : Profile
{
    public MessageMappingProfile()
    {
        CreateMap<IncomingMessageDto, OutgoingMessageDto>();

        CreateMap<IncomingMessageDto, MessageEntity>();

        CreateMap<MessageEntity, OutgoingMessageDto>()
            .ForMember(
            m => m.Id,
            c => c.MapFrom(
                entity => entity.Id.ToString()
                )
            );
    }
}

