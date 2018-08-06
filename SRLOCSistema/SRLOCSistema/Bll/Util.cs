using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLOCSistema.Bll
{
	public static class Util
	{
		public static bool ValidarNumero(KeyPressEventArgs e)
		{
			return !"0123456789".Contains(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar);
		}
	}
}
