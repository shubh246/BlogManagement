using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Blog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string BlogTitle { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BlogContent { get; set; }
        [Required]
        [Column(TypeName = "char(20)")]
        public string BlogCategory { get; set; }
        [Range(1,6)]
        public int SubscriptioNumber { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }


    }
}
