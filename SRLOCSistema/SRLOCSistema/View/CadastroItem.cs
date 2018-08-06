using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLOCSistema.Model;
using SRLOCSistema.Controller;
using SRLOCSistema.Bll;

namespace SRLOCSistema.View
{
	public partial class CadastroItem : Form
	{
		public CadastroItem()
		{
			InitializeComponent();
		}

		private void CadastrarItem_Click(object sender, EventArgs e)
		{
			var item = new Item();

			var itemController = new ItemController();

			item.Nome = txtNome.Text;
			item.Comprimento = double.Parse(numComprimentoEspacamento.Text.ToString());
			item.Largura = double.Parse(numLarguraEspacamento.Text.ToString());
			item.ComprimentoEspacamento = double.Parse(numLarguraEspacamento.Text.ToString());
			item.LarguraEspacamento = double.Parse(numComprimentoEspacamento.Text.ToString());

			itemController.CadastrarItem(item);

			this.Close();
		}

		private void numComprimento_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!"0123456789".Contains(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
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

		private void numComprimentoEspacamento_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Util.ValidarNumero(e))
			{
				e.Handled = true;
			}
		}

		private void numLarguraEspacamento_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Util.ValidarNumero(e))
			{
				e.Handled = true;
			}
		}
	}
}
