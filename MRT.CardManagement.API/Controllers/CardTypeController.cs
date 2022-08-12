using MediatR;
using Microsoft.AspNetCore.Mvc;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.CardType.Requests.Commands;
using MRT.CardManagement.Application.Features.CardType.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRT.CardManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeController : ControllerBase
    {
        IMediator _mediator;
        public CardTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CardTypeController>
        [HttpGet]
        public async Task<ActionResult<List<CardTypeDto>>> Get()
        {
            var cardTypes = await _mediator.Send(new GetCardTypeListRequest());
            return Ok(cardTypes);
        }

        // GET api/<CardTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardTypeDto>> Get(int id)
        {
            var cardType = await _mediator.Send(new GetCardTypeDetailRequest { Id = id });
            return Ok(cardType);
        }

        // POST api/<CardTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CardTypeDto cardType)
        {
            var command = new CreateCardTypeCommand { CardTypeDto = cardType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CardTypeController>
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put([FromBody] CardTypeDto cardType)
        //{
        //    var command = new CreateCardTypeCommand { CardTypeDto = cardType };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //// DELETE api/<CardTypeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
