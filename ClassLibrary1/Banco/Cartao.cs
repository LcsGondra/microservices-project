using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Banco
{
    public class Cartao
    {
        public int Id { get; set; }
        [ForeignKey("Conta")]
        public int ContaID { get; set; }
        public virtual Conta Conta { get; set; }
        public double LimiteAtual { get; set; }
        public double LimiteMax { get; set; }
        public string Numero { get; set; }
        public string Cvv { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/yyyy}")]
        public DateTime Validade { get; set; }
        public Boolean Ativo { get; set; }
        public List<Compra> compras { get; set; }

        private Boolean EstaAtivo(Compra compra)
        {
            if (!Ativo)
            {
                compra.Status = "RECUSADA";
                return false;
            }
            return true;
        }
        private Boolean DentroDoLimite(Compra compra, double valor)
        {
            if (LimiteAtual < valor)
            {
                compra.Status = "RECUSADA";
                return false;
            }
            return true;
        }
        public Compra AutorizarCompra(double valor, DateTime dataHora, string comerciante)
        {

            var compra = new Compra
            {
                Valor = valor,
                DataHora = dataHora,
                Comerciante = comerciante
            };
            //ta cartao ta ativo? dentro do limite? compra ta repitida?
            if (!EstaAtivo(compra)) return compra;
            if (!DentroDoLimite(compra, valor)) return compra;

            var ultimaCompra = compras[compras.Count() - 1];
            var penultimaCompra = compras[compras.Count() - 2];


            if ((dataHora.Subtract(ultimaCompra.DataHora) - ultimaCompra.DataHora.Subtract(penultimaCompra.DataHora)).TotalSeconds < 120)
            {
                compra.Status = "RECUSADA";
                return compra;
            }
            else if ((ultimaCompra.Valor == valor) && (ultimaCompra.Comerciante == comerciante) && (dataHora.Subtract(ultimaCompra.DataHora).TotalSeconds < 120))
            {
                compra.Status = "RECUSADA";
                return compra;
            }

            compra.Status = "APROVADA";
            LimiteAtual -= valor;
            return compra;
        }
    }
}
