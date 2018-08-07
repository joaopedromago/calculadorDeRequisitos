using SRLOCSistema.Model;
using SRLOCSistema.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLOCSistema.Bll;

namespace SRLOCSistema.View
{
	public partial class CadastroComodo : Form
	{
		public CadastroComodo()
		{
			InitializeComponent();
		}

		private void CadastrarItem_Click(object sender, EventArgs e)
		{
			var comodo = new Comodo();

			var comodoController = new ComodoController();

			comodo.ValidarCampos(txtNome.Text, numLargura.Text, numComprimento.Text);

			comodoController.CadastrarComodo(comodo);
		}

		private void numComprimento_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Util.ValidarNumero(e))
			{
				e.Handled = true;
			}
		}

		private void numLargura_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Util.ValidarNumero(e))
			{
				e.Handled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
