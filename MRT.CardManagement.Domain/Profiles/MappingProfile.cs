using AutoMapper;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Domain;
using MRT.CardManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, UpdateCardDto>().ReverseMap();
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<CardType, CardTypeDto>().ReverseMap();
            CreateMap<TransactionHistory, TransactionHistoryDto>().ReverseMap();
        }
    }
}