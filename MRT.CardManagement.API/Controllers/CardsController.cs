using MediatR;
using Microsoft.AspNetCore.Mvc;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.Card.Requests.Commands;
using MRT.CardManagement.Application.Features.Card.Requests.Queries;
using MRT.CardManagement.Application.Features.CardType.Requests.Queries;
using MRT.CardManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRT.CardManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        IMediator _mediator;
        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CardsController>
        [HttpGet]
        public async Task<ActionResult<List<CardDto>>> Get()
        {
            var cards = await _mediator.Send(new GetCardListRequest());
            return Ok(cards);
        }

        // GET api/<CardsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto>> Get(int id)
        {
            var card = await _mediator.Send(new GetCardDetailRequest { Id = id });
            return Ok(card);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> LoadCard([FromBody] UpdateCardDto card)
        {
            var command = new UpdateCardEntryCommand { Id = card.Id, TransactionType = card.TransactionType, LoadAmount = card.TransactionAmount };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // [HttpPut("update/{id}")]
        // public async Task<ActionResult> TapCard([FromBody] int Id)
        //{
        //           var command = new UpdateCardEntryCommand { Id = Id, TransactionType = "Tap" };
        //          var response = await _mediator.Send(command);
        //          return Ok(response);
        //}

        //// POST api/<CardsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<CardsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
