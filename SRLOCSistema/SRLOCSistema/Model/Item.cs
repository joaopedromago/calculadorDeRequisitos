using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLOCSistema.Model
{
	public class Item : BaseModel
	{
		public string Nome { get; set; }
		public double Largura { get; set; }
		public double Comprimento { get; set; }
		public double LarguraEspacamento { get; set; }
		public double ComprimentoEspacamento { get; set; }
	}
}
