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
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre de la calle es un dato requerido.")]
        [StringLength(50)]
        public virtual string streetName { get; set; }

        [Required(ErrorMessage = "El numero de puerta es un dato requerido.")]
        public virtual int streetNumber { get; set; }

        public virtual Client theClient { get; set; }
    }
}
