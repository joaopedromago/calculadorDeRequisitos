using FastMember;
using SRLOCSistema.Controller;
using SRLOCSistema.Model;
using SRLOCSistema.Model.Enum;
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
        public DataTable comodos;
        public DataTable itens;
        public List<Comodo> listaComodo;
        public List<Item> listaItem;

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

        public void CarregarGrids()
        {
            try
            {
                var comodoControler = new ComodoController();
                var itemController = new ItemController();

                comodos = comodoControler.ObterComodos();
                itens = itemController.ObterItens();

                comodos.Columns.Remove("DATACRIACAO");
                itens.Columns.Remove("DATACRIACAO");

                comodos.Columns["NOME"].ColumnName = "Nome";
                comodos.Columns["COMPRIMENTO"].ColumnName = "Comprimento";
                comodos.Columns["LARGURA"].ColumnName = "Largura";

                comodos.Columns["ID"].SetOrdinal(comodos.Columns.Count - 1);
                itens.Columns["ID"].SetOrdinal(itens.Columns.Count - 1);
                comodos.Columns["ID"].ReadOnly = true;
                itens.Columns["ID"].ReadOnly = true;

                itens.Columns["NOME"].ColumnName = "Nome";
                itens.Columns["COMPRIMENTO"].ColumnName = "Comprimento";
                itens.Columns["LARGURA"].ColumnName = "Largura";
                itens.Columns["COMPRIMENTOESPACAMENTO"].ColumnName = "Comprimento espaçamento";
                itens.Columns["LARGURAESPACAMENTO"].ColumnName = "Largura espaçamento";
                itens.Columns["TIPOCALCULO"].ColumnName = "Tipo de Cálculo";

                gridComodos.DataSource = comodos;
                gridItens.DataSource = itens;

                PreencherDadosResultado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PreencherDadosResultado()
        {
            var comodoControler = new ComodoController();
            var itemController = new ItemController();

            listaComodo = comodoControler.ObterListaComodos();
            listaItem = itemController.ObterListaItens();

            _calculo.EfetuarCalculo(listaItem, listaComodo);
        }

        private void gridItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = gridItens.SelectedRows;

            //var index = this.gridItens.SelectedRows[0].Index;
        }

        private void gridItens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            atualizarItem();
            PreencherDadosResultado();
        }

        private void gridComodos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            atualizarComodo();
            PreencherDadosResultado();
        }

        public void atualizarComodo()
        {
            var comodo = new Comodo();
            var controller = new ComodoController();

            var index = gridComodos.CurrentCell.RowIndex;
            var id = gridComodos.Rows[index].Cells["ID"].Value.ToString();
            var nome = gridComodos.Rows[index].Cells["Nome"].Value.ToString();
            var largura = gridComodos.Rows[index].Cells["Comprimento"].Value.ToString();
            var comprimento = gridComodos.Rows[index].Cells["Largura"].Value.ToString();

            int aux;
            if (!int.TryParse(id, out aux))
            {
                return;
            }
            comodo.Id = int.Parse(id);
            comodo.ValidarCampos(nome, largura, comprimento);

            controller.AtualizarComodo(comodo);
        }

        public void atualizarItem()
        {
            var item = new Item();
            var controller = new ItemController();

            var index = gridItens.CurrentCell.RowIndex;
            var id = gridItens.Rows[index].Cells["ID"].Value.ToString();
            var nome = gridItens.Rows[index].Cells["Nome"].Value.ToString();
            var largura = gridItens.Rows[index].Cells["Comprimento"].Value.ToString();
            var comprimento = gridItens.Rows[index].Cells["Largura"].Value.ToString();
            var larguraEspacamento = gridItens.Rows[index].Cells["Comprimento espaçamento"].Value.ToString();
            var comprimentoEspacamento = gridItens.Rows[index].Cells["Largura espaçamento"].Value.ToString();
            var tipoCalculo = gridItens.Rows[index].Cells["Tipo de Cálculo"].Value.ToString();

            int aux;
            if (!int.TryParse(id, out aux))
            {
                return;
            }
            item.Id = int.Parse(id);
            item.ValidarCampos(nome, largura, comprimento, larguraEspacamento, comprimentoEspacamento, tipoCalculo);

            controller.AtualizarItem(item);
        }

        private void btnGerarTxt_Click(object sender, EventArgs e)
        {

        }

        private void GerarExcel_Click(object sender, EventArgs e)
        {

        }

        private void excluirItem_Click(object sender, EventArgs e)
        {
            var controller = new ItemController();

            var index = gridItens.CurrentCell?.RowIndex ?? null;
            if (index == null)
            {
                return;
            }
            var id = gridItens.Rows[(int)index].Cells["ID"].Value.ToString();

            controller.ExcluirItem(int.Parse(id));

            CarregarGrids();
        }

        private void excluirComodo_Click(object sender, EventArgs e)
        {
            var controller = new ComodoController();

            var index = gridComodos.CurrentCell?.RowIndex ?? null;
            if (index == null)
            {
                return;
            }
            var id = gridComodos.Rows[(int)index].Cells["ID"].Value.ToString();

            controller.ExcluirComodo(int.Parse(id));

            CarregarGrids();
        }
    }
}
