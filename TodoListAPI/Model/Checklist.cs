using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace TodoListAPI.Model
{
    public class Checklist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid? UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
    }
}
