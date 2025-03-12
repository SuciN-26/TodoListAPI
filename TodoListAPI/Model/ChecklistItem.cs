using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Model
{
    public class ChecklistItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        public bool Status { get; set; } = false;

        public Guid? UserId { get; set; }
        
        public int ChecklistId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Checklist Checklist { get; set; }
    }
}
