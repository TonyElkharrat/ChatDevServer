using AutoMapper;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Models.Messages;
using ChatDev.Models.Users;
using ChatDev.Repository;
using ChatDev.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;


        public ChatController(IChatRepository chatRepository,IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("post-message")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PostMessage([FromBody] MessagePostDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            var messageCreated = await _chatRepository.AddAsync(message);
            var response = _mapper.Map<MessageResponseDto>(messageCreated);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hi");

            return Ok();
        }
    }
}
