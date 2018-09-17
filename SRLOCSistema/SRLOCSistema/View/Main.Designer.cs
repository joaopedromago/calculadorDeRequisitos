using System.Windows.Forms;

namespace SRLOCSistema
{
    partial class SRLOC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.CadastrarComodo = new System.Windows.Forms.Button();
			this.CadastrarItem = new System.Windows.Forms.Button();
			this.gridItens = new System.Windows.Forms.DataGridView();
			this.gridComodos = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listResultados = new System.Windows.Forms.ListView();
			this.lblResultado = new System.Windows.Forms.Label();
			this.btnGerarTxt = new System.Windows.Forms.Button();
			this.excluirItem = new System.Windows.Forms.Button();
			this.excluirComodo = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridItens)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridComodos)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.CadastrarComodo);
			this.panel1.Controls.Add(this.CadastrarItem);
			this.panel1.Location = new System.Drawing.Point(12, 364);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(962, 100);
			this.panel1.TabIndex = 1;
			// 
			// CadastrarComodo
			// 
			this.CadastrarComodo.BackColor = System.Drawing.Color.LightSkyBlue;
			this.CadastrarComodo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CadastrarComodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CadastrarComodo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.CadastrarComodo.Location = new System.Drawing.Point(219, 15);
			this.CadastrarComodo.Name = "CadastrarComodo";
			this.CadastrarComodo.Size = new System.Drawing.Size(200, 72);
			this.CadastrarComodo.TabIndex = 1;
			this.CadastrarComodo.Text = "Cadastrar Cômodo";
			this.CadastrarComodo.UseVisualStyleBackColor = false;
			this.CadastrarComodo.Click += new System.EventHandler(this.CadastrarComodo_Click);
			// 
			// CadastrarItem
			// 
			this.CadastrarItem.BackColor = System.Drawing.Color.LightSkyBlue;
			this.CadastrarItem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CadastrarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CadastrarItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.CadastrarItem.Location = new System.Drawing.Point(13, 15);
			this.CadastrarItem.Name = "CadastrarItem";
			this.CadastrarItem.Size = new System.Drawing.Size(200, 72);
			this.CadastrarItem.TabIndex = 0;
			this.CadastrarItem.Text = "Cadastrar Item";
			this.CadastrarItem.UseVisualStyleBackColor = false;
			this.CadastrarItem.Click += new System.EventHandler(this.CadastrarItem_Click);
			// 
			// gridItens
			// 
			this.gridItens.AllowUserToAddRows = false;
			this.gridItens.AllowUserToDeleteRows = false;
			this.gridItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridItens.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gridItens.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gridItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridItens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridItens.Location = new System.Drawing.Point(12, 65);
			this.gridItens.MultiSelect = false;
			this.gridItens.Name = "gridItens";
			this.gridItens.Size = new System.Drawing.Size(313, 293);
			this.gridItens.TabIndex = 4;
			this.gridItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItens_CellClick);
			this.gridItens.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItens_CellValueChanged);
			// 
			// gridComodos
			// 
			this.gridComodos.AllowUserToAddRows = false;
			this.gridComodos.AllowUserToDeleteRows = false;
			this.gridComodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridComodos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gridComodos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gridComodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridComodos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridComodos.Location = new System.Drawing.Point(331, 65);
			this.gridComodos.MultiSelect = false;
			this.gridComodos.Name = "gridComodos";
			this.gridComodos.Size = new System.Drawing.Size(313, 293);
			this.gridComodos.TabIndex = 5;
			this.gridComodos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComodos_CellValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 24);
			this.label1.TabIndex = 6;
			this.label1.Text = "Itens";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(327, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 24);
			this.label2.TabIndex = 7;
			this.label2.Text = "Cômodos";
			// 
			// listResultados
			// 
			this.listResultados.Location = new System.Drawing.Point(665, 12);
			this.listResultados.Name = "listResultados";
			this.listResultados.Size = new System.Drawing.Size(309, 268);
			this.listResultados.TabIndex = 8;
			this.listResultados.UseCompatibleStateImageBehavior = false;
			// 
			// lblResultado
			// 
			this.lblResultado.AutoSize = true;
			this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResultado.Location = new System.Drawing.Point(672, 21);
			this.lblResultado.Name = "lblResultado";
			this.lblResultado.Size = new System.Drawing.Size(86, 20);
			this.lblResultado.TabIndex = 9;
			this.lblResultado.Text = "Resultado:";
			// 
			// btnGerarTxt
			// 
			this.btnGerarTxt.BackColor = System.Drawing.Color.SteelBlue;
			this.btnGerarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGerarTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGerarTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnGerarTxt.Location = new System.Drawing.Point(665, 286);
			this.btnGerarTxt.Name = "btnGerarTxt";
			this.btnGerarTxt.Size = new System.Drawing.Size(309, 72);
			this.btnGerarTxt.TabIndex = 10;
			this.btnGerarTxt.Text = "Exportar Resultado";
			this.btnGerarTxt.UseVisualStyleBackColor = false;
			this.btnGerarTxt.Click += new System.EventHandler(this.btnGerarTxt_Click);
			// 
			// excluirItem
			// 
			this.excluirItem.BackColor = System.Drawing.Color.LightCoral;
			this.excluirItem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.excluirItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.excluirItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.excluirItem.Location = new System.Drawing.Point(246, 21);
			this.excluirItem.Name = "excluirItem";
			this.excluirItem.Size = new System.Drawing.Size(79, 38);
			this.excluirItem.TabIndex = 40;
			this.excluirItem.Text = "Excluir";
			this.excluirItem.UseVisualStyleBackColor = false;
			this.excluirItem.Click += new System.EventHandler(this.excluirItem_Click);
			// 
			// excluirComodo
			// 
			this.excluirComodo.BackColor = System.Drawing.Color.LightCoral;
			this.excluirComodo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.excluirComodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.excluirComodo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.excluirComodo.Location = new System.Drawing.Point(565, 21);
			this.excluirComodo.Name = "excluirComodo";
			this.excluirComodo.Size = new System.Drawing.Size(79, 38);
			this.excluirComodo.TabIndex = 41;
			this.excluirComodo.Text = "Excluir";
			this.excluirComodo.UseVisualStyleBackColor = false;
			this.excluirComodo.Click += new System.EventHandler(this.excluirComodo_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(676, 44);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(288, 225);
			this.richTextBox1.TabIndex = 42;
			this.richTextBox1.Text = "";
			// 
			// SRLOC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(986, 476);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.excluirComodo);
			this.Controls.Add(this.excluirItem);
			this.Controls.Add(this.btnGerarTxt);
			this.Controls.Add(this.lblResultado);
			this.Controls.Add(this.listResultados);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridComodos);
			this.Controls.Add(this.gridItens);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SRLOC";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cálculo de Requísitos";
			this.Load += new System.EventHandler(this.SRLOC_Load);
			this.Enter += new System.EventHandler(this.SRLOC_Enter);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridItens)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridComodos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CadastrarComodo;
        private System.Windows.Forms.Button CadastrarItem;
        private System.Windows.Forms.DataGridView gridItens;
        private System.Windows.Forms.DataGridView gridComodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listResultados;
		private System.Windows.Forms.Label lblResultado;
		private System.Windows.Forms.Button btnGerarTxt;
		private Button excluirItem;
		private Button excluirComodo;
		private RichTextBox richTextBox1;
	}
}

