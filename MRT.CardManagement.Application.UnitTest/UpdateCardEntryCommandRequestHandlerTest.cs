using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using AutoMapper;
using Moq;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.Features.Card.Handlers.Commands;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Profiles;
using MRT.CardManagement.Application.Features.Card.Requests.Commands;
using System.Threading;
using MRT.CardManagement.Domain;

namespace MRT.CardManagement.Application.UnitTest
{
    public class UpdateCardEntryCommandRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateCardEntryCommandHandler _handler;
        private readonly CardTypeDto _qlessBasic;
        private readonly CardTypeDto _qlessDiscount;
        private const string SENIOR_CITIZEN_ID = "Senior Citizen ID";
        private const string PWD_ID = "Pwd ID";

        public UpdateCardEntryCommandRequestHandlerTest()
        {
            _mockUow = new Mock<IUnitOfWork>();
  
            _qlessBasic = new CardTypeDto { Id = 1, Name = "Q-Less Transport Card", InitialLoad = 100, Validity = 5 };
            _qlessDiscount = new CardTypeDto { Id = 2, Name = "Q-Less Discount Transport Card", InitialLoad = 500, Validity = 3 };

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new UpdateCardEntryCommandHandler(_mapper, _mockUow.Object);
        }

        //[Theory]
        //[InlineData(PWD_ID)]
        //[InlineData(SENIOR_CITIZEN_ID)]
        //public async Task ShouldLoadWhenDoesNotExceedAllowedBalance(string cardType)
        //{
        //    var mockCardRepository = new Mock<ICardRepository>();

        //    var card = new CardDto
        //    {
        //        Id = 1,
        //        AccountNumber = "1111-1111-1111",
        //        CardType = _qlessBasic,
        //        LoadBalance = 100000,
        //        ExpirationDate = DateTime.Today
        //    };
        //    _mockUow.Setup(r => r.CardRepository).Returns(mockCardRepository.Object);
        //    _mockUow.Setup(r => r.CardRepository.GetCardDetails(It.IsAny<int>())).ReturnsAsync((Card card) =>
        //    {
        //        return card;
        //    });


            
        //    var result = await _handler.Handle(
        //        new UpdateCardEntryCommand() { Id = 1, LoadAmount = 111, TransactionType="Load" }, 
        //        CancellationToken.None);
        //    result.Success.ShouldBeTrue();
        //}
    }
}
