using AutoMapper;
using Moq;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.Card.Handlers.Commands;
using MRT.CardManagement.Application.Features.Card.Requests.Commands;
using MRT.CardManagement.Application.Profiles;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace MRT.CardManagement.Application.UnitTest
{ 
    public class CreateCardEntryCommandRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICardRepository> _mockCardRepo;
        private readonly Mock<ICardTypeRepository> _mockCardTypeRepo;
        private readonly CreateCardEntryCommandHandler _handler;
        private readonly CardTypeDto _qlessBasic;
        private readonly CardTypeDto _qlessDiscount;
        private const string SENIOR_CITIZEN_ID = "Senior Citizen ID";
        private const string PWD_ID = "Pwd ID";

        public CreateCardEntryCommandRequestHandlerTest()
        {
            _mockCardRepo = new Mock<ICardRepository>();
            _mockCardTypeRepo = new Mock<ICardTypeRepository>();
            _qlessBasic = new CardTypeDto { Id = 1, Name = "Q-Less Transport Card", InitialLoad = 100, Validity=5 };
            _qlessDiscount = new CardTypeDto { Id = 2, Name = "Q-Less Discount Transport Card", InitialLoad = 500, Validity=3 };

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateCardEntryCommandHandler(_mockCardRepo.Object, _mapper, _mockCardTypeRepo.Object);
        }
        [Fact]
        public async Task ShouldSucceedSuceedWhenInputsAreValid()
        { 
            var card = new CardDto { Id = 1, AccountNumber = "1111-1111-1111", CardTypeId = 1, CardType = _qlessBasic};

            _mockCardTypeRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((CardType cardType) =>
            {
                
                return cardType;
            });

            var result = await _handler.Handle(new CreateCardEntryCommand() { CardDto = card }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }

        
        [Fact]
        public async Task ShouldFailQLessDiscountIfNoIdIsNotProvided()
        {
            var card = new CardDto { Id = 1, AccountNumber = "1111-1111-1111", CardTypeId = 2, CardType = _qlessDiscount };

            var result = await _handler.Handle(new CreateCardEntryCommand() { CardDto = card }, CancellationToken.None);
            result.Success.ShouldBeFalse();
        }

        [Theory]
        [InlineData(PWD_ID, "1111-1111")]
        [InlineData(PWD_ID, "1111111")]
        [InlineData(SENIOR_CITIZEN_ID, "1111-1111")]
        [InlineData(SENIOR_CITIZEN_ID, "1111111")]
        public async Task ShouldFailWhenDiscountIdIsNotValid(string idType, string discountId)
        {
            var card = new CardDto { Id = 1, AccountNumber = "1111-1111-1111", CardTypeId = 2, CardType=_qlessDiscount, DiscountId=discountId, DiscountIdType = idType };

            var result = await _handler.Handle(new CreateCardEntryCommand() { CardDto = card }, CancellationToken.None);
            result.Success.ShouldBeFalse();
        }

        [Theory]
        [InlineData(SENIOR_CITIZEN_ID, "11-1111-1111")]
        [InlineData(PWD_ID, "1111-1111-1111")]
        public async Task ShouldSucceedWhenDiscountIdIsValid(string idType, string discountId)
        {
            var card = new CardDto { Id = 1, AccountNumber = "1111-1111-1111", CardTypeId = 2, CardType=_qlessDiscount, DiscountId = discountId, DiscountIdType = idType };

            var result = await _handler.Handle(new CreateCardEntryCommand() { CardDto = card }, CancellationToken.None);
            result.Success.ShouldBeTrue();
        }
    }
}
