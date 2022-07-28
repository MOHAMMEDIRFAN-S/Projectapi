using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Student.Models
{
    [Table("Gender")]
    public partial class Gender
    {
        public Gender()
        {
            Students = new HashSet<Students>();
        }
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenderId { get; set; }
        [StringLength(15)]
        public string GenderName { get; set; } = null!;
        [InverseProperty("Gender")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
