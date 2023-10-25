using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace microservices_project.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        [ForeignKey("Conta")]
        public int contaID { get; set; }
        public virtual Conta conta { get; set; }
        public string Numero { get; set; }
        public string Cvv { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/yyyy}")]
        public DateTime Validade { get; set; }
        public Boolean Ativo { get; set; }
    }
}
