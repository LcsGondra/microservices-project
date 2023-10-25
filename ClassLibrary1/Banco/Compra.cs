using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Banco
{
    public class Compra
    {
        public int Id { get; set; }
        [ForeignKey("Cartao")]
        public int CartaoID { get; set; }
        public virtual Cartao Cartao { get; set; }
        public double Valor { get; set; }
        public DateTime DataHora { get; set; }
        public string Comerciante { get; set; }
        public string Status { get; set; }
    }
}
