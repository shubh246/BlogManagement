using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMangementApi.Models
{
    public class Blog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string BlogTitle { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BlogContent { get; set; }
        [Column(TypeName = "char(20)")]
        public string BlogCategory { get; set; }
        public int SubscriptioNumber { get; set; }


    }
}
