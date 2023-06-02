using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }
        [Column(TypeName = "char(20)")]
        public string Role { get; set; }
    }
}
