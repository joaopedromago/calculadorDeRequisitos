namespace SRLOCSistema.View
{
	partial class CadastroComodo
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
			this.CadastrarItem = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblComprimento = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.lblNome = new System.Windows.Forms.Label();
			this.numComprimento = new System.Windows.Forms.TextBox();
			this.numLargura = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.CadastrarItem);
			this.panel1.Location = new System.Drawing.Point(16, 361);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(470, 100);
			this.panel1.TabIndex = 24;
			// 
			// CadastrarItem
			// 
			this.CadastrarItem.BackColor = System.Drawing.Color.LightGreen;
			this.CadastrarItem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CadastrarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CadastrarItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CadastrarItem.Location = new System.Drawing.Point(13, 14);
			this.CadastrarItem.Name = "CadastrarItem";
			this.CadastrarItem.Size = new System.Drawing.Size(200, 72);
			this.CadastrarItem.TabIndex = 0;
			this.CadastrarItem.Text = "Salvar";
			this.CadastrarItem.UseVisualStyleBackColor = false;
			this.CadastrarItem.Click += new System.EventHandler(this.CadastrarItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(279, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 24);
			this.label1.TabIndex = 30;
			this.label1.Text = "Largura";
			// 
			// lblComprimento
			// 
			this.lblComprimento.AutoSize = true;
			this.lblComprimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblComprimento.Location = new System.Drawing.Point(12, 102);
			this.lblComprimento.Name = "lblComprimento";
			this.lblComprimento.Size = new System.Drawing.Size(124, 24);
			this.lblComprimento.TabIndex = 28;
			this.lblComprimento.Text = "Comprimento";
			// 
			// txtNome
			// 
			this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNome.Location = new System.Drawing.Point(16, 63);
			this.txtNome.MaxLength = 80;
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(470, 29);
			this.txtNome.TabIndex = 26;
			// 
			// lblNome
			// 
			this.lblNome.AutoSize = true;
			this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNome.Location = new System.Drawing.Point(12, 36);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(62, 24);
			this.lblNome.TabIndex = 25;
			this.lblNome.Text = "Nome";
			// 
			// numComprimento
			// 
			this.numComprimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numComprimento.Location = new System.Drawing.Point(16, 129);
			this.numComprimento.MaxLength = 80;
			this.numComprimento.Name = "numComprimento";
			this.numComprimento.Size = new System.Drawing.Size(225, 29);
			this.numComprimento.TabIndex = 31;
			this.numComprimento.Text = "0";
			this.numComprimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numComprimento_KeyPress);
			// 
			// numLargura
			// 
			this.numLargura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numLargura.Location = new System.Drawing.Point(261, 129);
			this.numLargura.MaxLength = 80;
			this.numLargura.Name = "numLargura";
			this.numLargura.Size = new System.Drawing.Size(225, 29);
			this.numLargura.TabIndex = 32;
			this.numLargura.Text = "0";
			this.numLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numLargura_KeyPress);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightCoral;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(332, 41);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(122, 45);
			this.button1.TabIndex = 1;
			this.button1.Text = "Cancelar";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// CadastroComodo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 473);
			this.Controls.Add(this.numLargura);
			this.Controls.Add(this.numComprimento);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblComprimento);
			this.Controls.Add(this.txtNome);
			this.Controls.Add(this.lblNome);
			this.Name = "CadastroComodo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastro de Comodo";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button CadastrarItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblComprimento;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.TextBox numComprimento;
		private System.Windows.Forms.TextBox numLargura;
		private System.Windows.Forms.Button button1;
	}
}