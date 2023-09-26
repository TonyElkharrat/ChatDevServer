
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatDev.Data
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string SentDate { get; set; }
        [ForeignKey("UserId")]
        public ApiUser SentBy { get; set; }
        [ForeignKey("ChatSubjectId")]
        public ChatSubject ChatSubject { get; set; }
    }
}
