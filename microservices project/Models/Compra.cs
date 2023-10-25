using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace microservices_project.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [ForeignKey("Cartao")]
        public int cartaoID { get; set; }
        public virtual Cartao cartao { get; set; }
        public float Valor { get; set; }
        public DateTime DataHora { get; set; }
        public string Comerciante { get; set; }
        public string Status { get; set; }
    }
}
