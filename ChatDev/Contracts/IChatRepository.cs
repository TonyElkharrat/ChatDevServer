using ChatDev.Data;
using ChatDev.Models.Messages;
using Microsoft.AspNetCore.Mvc;

namespace ChatDev.Contracts
{
    public interface IChatRepository : IGenericRepository<Message>
    {
        Task<IActionResult> GetMessagesBySubject(ChatSubjectDto chatSubjectDto);
    }
}
