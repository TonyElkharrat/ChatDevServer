using System.ComponentModel.DataAnnotations;

namespace ChatDev.Data
{
    public class ChatSubject
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
