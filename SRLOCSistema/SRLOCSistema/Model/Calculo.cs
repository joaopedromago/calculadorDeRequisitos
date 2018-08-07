using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLOCSistema.Model
{
    public class Calculo
    {
        public List<ValorPorComodo> ValoresPorComodo { get; set; }

        public void EfetuarCalculo(List<Item> itens, List<Comodo> comodos)
        {
            ValoresPorComodo = new List<ValorPorComodo>();

            foreach (var comodo in comodos)
            {
                foreach (var item in itens)
                {
                    var valorPorComodo = new ValorPorComodo();

                    valorPorComodo.EfetuarCalculo(item, comodo);

                    ValoresPorComodo.Add(valorPorComodo);
                }
            }
        }
    }

    public class ValorPorComodo
    {
        public string Comodo { get; set; }
        public string Item { get; set; }

        public UInt64 QuantidadeXComprimento { get; set; }
        public UInt64 QuantidadeYComprimento { get; set; }
        public double RecortesXComprimento { get; set; }
        public double RecortesYComprimento { get; set; }

        public UInt64 QuantidadeXLargura { get; set; }
        public UInt64 QuantidadeYLargura { get; set; }
        public double RecortesXLargura { get; set; }
        public double RecortesYLargura { get; set; }

        public void EfetuarCalculo(Item item, Comodo comodo)
        {
            Comodo = comodo.Nome;
            Item = item.Nome;

            var xLargura = (item.Largura + item.LarguraEspacamento) == 0 ? 0 : comodo.Largura / (item.Largura + item.LarguraEspacamento);
            var yLargura = (item.Comprimento + item.ComprimentoEspacamento) == 0 ? 0 : comodo.Largura / (item.Comprimento + item.ComprimentoEspacamento);

            var xComprimento = (item.Largura + item.LarguraEspacamento) == 0 ? 0 : comodo.Comprimento / (item.Largura + item.LarguraEspacamento);
            var yComprimento = (item.Comprimento + item.ComprimentoEspacamento) == 0 ? 0 : comodo.Comprimento / (item.Comprimento + item.ComprimentoEspacamento);

            QuantidadeXLargura = UInt64.Parse(Math.Floor(xLargura).ToString());
            QuantidadeYLargura = UInt64.Parse(Math.Floor(yLargura).ToString());

            RecortesXLargura = xLargura - QuantidadeXLargura;
            RecortesYLargura = yLargura - QuantidadeYLargura;

            QuantidadeXComprimento = UInt64.Parse(Math.Floor(xComprimento).ToString());
            QuantidadeYComprimento = UInt64.Parse(Math.Floor(yComprimento).ToString());

            RecortesXComprimento = xComprimento - QuantidadeXComprimento;
            RecortesYComprimento = yComprimento - QuantidadeYComprimento;

            RecortesXLargura = Math.Ceiling(RecortesXLargura * 100) / 100;
            RecortesYLargura = Math.Ceiling(RecortesYLargura * 100) / 100;

            RecortesXComprimento = Math.Ceiling(RecortesXComprimento * 100) / 100;
            RecortesYComprimento = Math.Ceiling(RecortesYComprimento * 100) / 100;

        }
    }
}
