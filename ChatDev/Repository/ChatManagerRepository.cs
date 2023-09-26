using AutoMapper;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Models.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatDev.Repository
{
    public class ChatManagerRepository : GenericRepository<Message>, IChatRepository
    {
        public ChatManagerRepository(ChatDevDbContext chatDevDbContext) : base(chatDevDbContext)
        {
        }

        public Task<IActionResult> GetMessagesBySubject(ChatSubjectDto chatSubjectDto)
        {
            throw new NotImplementedException();
        }
    }
}
