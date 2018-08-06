using SRLOCSistema.Controller;
using SRLOCSistema.Model;
using SRLOCSistema.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLOCSistema
{
	public partial class SRLOC : Form
	{
		public Calculo _calculo;

		public SRLOC()
		{
			_calculo = new Calculo();
			InitializeComponent();
		}

		private void SRLOC_Enter(object sender, EventArgs e)
		{
			CarregarGrids();
		}

		private void SRLOC_Load(object sender, EventArgs e)
		{
			CarregarGrids();
		}

		private void CadastrarComodo_Click(object sender, EventArgs e)
		{
			var obj = new CadastroComodo();
			obj.ShowDialog();
			CarregarGrids();
		}

		private void CadastrarItem_Click(object sender, EventArgs e)
		{
			var obj = new CadastroItem();
			obj.ShowDialog();
			CarregarGrids();
		}

		private void GerarExcel_Click(object sender, EventArgs e)
		{

		}

		public void CarregarGrids()
		{
			try
			{
				var comodoControler = new ComodoController();
				var itemController = new ItemController();

				var comodos = comodoControler.ObterComodos();
				var itens = itemController.ObterItens();

				var listaComodo = comodoControler.TransformarDataTable(comodos);
				var listaItem = itemController.TransformarDataTable(itens);

				comodos.Columns.Remove("DATACRIACAO");
				itens.Columns.Remove("DATACRIACAO");

				comodos.Columns["NOME"].ColumnName = "Nome";
				comodos.Columns["COMPRIMENTO"].ColumnName = "Comprimento";
				comodos.Columns["LARGURA"].ColumnName = "Largura";

				comodos.Columns["ID"].SetOrdinal(comodos.Columns.Count - 1);
				itens.Columns["ID"].SetOrdinal(itens.Columns.Count - 1);

				itens.Columns["NOME"].ColumnName = "Nome";
				itens.Columns["COMPRIMENTO"].ColumnName = "Comprimento";
				itens.Columns["LARGURA"].ColumnName = "Largura";
				itens.Columns["COMPRIMENTOESPACAMENTO"].ColumnName = "Comprimento espaçamento";
				itens.Columns["LARGURAESPACAMENTO"].ColumnName = "Largura espaçamento";

				gridComodos.DataSource = comodos;
				gridItens.DataSource = itens;

				_calculo.EfetuarCalculo(listaItem, listaComodo);

				PreencherDadosResultado();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void PreencherDadosResultado()
		{

		}

		private void gridItens_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var a = gridItens.SelectedRows;

			//var index = this.gridItens.SelectedRows[0].Index;
		}
	}
}
