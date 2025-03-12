using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListAPI.Model
{
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Checklist> Checklists { get; set; } = new List<Checklist>();
        public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
    }
}
