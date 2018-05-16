using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Domain
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "La cedula es un dato requerido.")]
        public virtual string idCard { get; set; }

        [Required(ErrorMessage = "El nombre es un dato requerido.")]
        [StringLength(50)]
        public virtual string name { get; set; }

        [Required(ErrorMessage = "El apellido es un dato requerido.")]
        [StringLength(50)]
        public virtual string lastname { get; set; }

        public virtual List<Address> addresses { get; set; }

        [Required(ErrorMessage = "El email es un dato requerido.")]
        [StringLength(50)]
        public virtual string email { get; set; }

        [NotMapped]
        public virtual bool selected { get; set; }

        public Client()
        {
            addresses = new List<Address>();
        }
    }
}
