using ChatDev.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatDev.Models.Messages
{
    public class MessagePostDto
    {
        public string Text { get; set; }
        public string SentDate { get; set; }
    }
}
