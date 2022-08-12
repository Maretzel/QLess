using AutoMapper;
using MediatR;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.Card.Requests.Commands;
using MRT.CardManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Features.Card.Handlers.Commands
{
    public class UpdateCardEntryCommandHandler : IRequestHandler<UpdateCardEntryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private BaseCommandResponse _response;
        private MRT.CardManagement.Domain.Card _card;

        private const string LOAD_CARD = "Load";
        private const string TAP_CARD = "Tap";

        private const int MAXIMUM_BALANCE_ALLOWED = 10000;

        private const int QLESS_DISCOUNT = 2;
        private const int QLESS_BASIC = 1;

        private const int QLESS_DISCOUNT_TAP_AMOUNT = 10;
        private const int QLESS_BASIC_TAP_AMOUNT = 15;


        private DateTime? _expirationDate;
        public UpdateCardEntryCommandHandler(
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork; 
            _mapper = mapper;
            _response = new BaseCommandResponse();
        }
        public async Task<BaseCommandResponse> Handle(UpdateCardEntryCommand request, CancellationToken cancellationToken)
        {
           
            var response = new BaseCommandResponse();
            _card = await _unitOfWork.CardRepository.GetCardDetails(request.Id);


            _expirationDate = _card.ExpirationDate;
            bool result = CardNotExpired(_expirationDate);

            if (result)
            {
                result = ProcessTransaction(request.TransactionType, request.LoadAmount);
            }

            if (result)
            {
                _response.Success = true;
                _response.Message = "Successfully updated load for " +
                    request.TransactionType + " transaction";
                _card.ExpirationDate = GetNewExpirationDate();
                await _unitOfWork.CardRepository.Update(_card);
                await _unitOfWork.Save();
            }

            return _response;
        }

        private bool ProcessTransaction(string transactionType,  int amountToCredit)
        {
            bool result;
            if (transactionType == LOAD_CARD)
            {
                result = ProcessLoadTransaction(amountToCredit);
            }
            else
            {
                result = ProcessTapTransaction(amountToCredit);
            }
            return result;
        }

        public bool ProcessLoadTransaction(int  amountToCredit)
        {
            bool result = CardNotExpired(_expirationDate);
            if (result)
            {
                result = DoesNotExceedValidAllowedBalance(amountToCredit);
            } 

            return result;
        }

        public bool ProcessTapTransaction(int amountToCredit)
        {
            bool result = CardNotExpired(_expirationDate);
            if (result)
            {
                if (_card.CardTypeId == QLESS_DISCOUNT)
                {
                    result = ComputeDiscount(_card, amountToCredit);
                } else
                {
                    result = LoadBalanceIsStillSufficient(QLESS_BASIC_TAP_AMOUNT);
                }
            }
            return result;
        }

        public bool CardNotExpired(DateTime? expirationDate)
        {
            if (DateTime.UtcNow > expirationDate)
            {
                _response.Message = "This card is no longer valid.";
                _response.Success = false;
                return false;
            }
            return true;
        }

        public bool ComputeDiscount(MRT.CardManagement.Domain.Card card, int amountToCredit)
        {
           
            return false;
        }

        public bool DoesNotExceedValidAllowedBalance(int amountToCredit)
        {
            if (_card.LoadBalance + amountToCredit > MAXIMUM_BALANCE_ALLOWED)
            {
                _response.Message = "Load exceeds the maximum allowed balance.";
                _response.Success = false;
                return false;
            }
            _card.LoadBalance = _card.LoadBalance + amountToCredit;
            return true;
        }

        public bool LoadBalanceIsStillSufficient(int amountToDebit)
        {
            if (amountToDebit > _card.LoadBalance)
            {
                _response.Message = "Insufficient Balance";
                _response.Success = false;
                return false;
            }

            _card.LoadBalance = _card.LoadBalance - amountToDebit;

            return true;
        }

        public DateTime? GetNewExpirationDate()
        {
            DateTime expirationDate = DateTime.Now;

            if (_card.CardTypeId == QLESS_DISCOUNT)
            {
                expirationDate = DateTime.Now.AddYears(3);
            }
            else if (_card.CardTypeId == QLESS_BASIC)
            {
                expirationDate = DateTime.Now.AddYears(5);
            }

            return expirationDate;
        }


    }
}
