namespace FRMBIER
{
    partial class FrmGen
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.rotationTrackBar = new System.Windows.Forms.TrackBar();
            this.scaleTrackBar = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlParametros = new System.Windows.Forms.Panel();
            this.cmbFig = new System.Windows.Forms.ComboBox();
            this.picCnv = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCnv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rotationTrackBar);
            this.panel1.Controls.Add(this.scaleTrackBar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pnlParametros);
            this.panel1.Controls.Add(this.cmbFig);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 426);
            this.panel1.TabIndex = 0;
            // 
            // rotationTrackBar
            // 
            this.rotationTrackBar.Location = new System.Drawing.Point(0, 361);
            this.rotationTrackBar.Maximum = 360;
            this.rotationTrackBar.Name = "rotationTrackBar";
            this.rotationTrackBar.Size = new System.Drawing.Size(249, 45);
            this.rotationTrackBar.TabIndex = 6;
            this.rotationTrackBar.Value = 5;
            // 
            // scaleTrackBar
            // 
            this.scaleTrackBar.Location = new System.Drawing.Point(4, 297);
            this.scaleTrackBar.Maximum = 30;
            this.scaleTrackBar.Minimum = 5;
            this.scaleTrackBar.Name = "scaleTrackBar";
            this.scaleTrackBar.Size = new System.Drawing.Size(245, 45);
            this.scaleTrackBar.TabIndex = 5;
            this.scaleTrackBar.Value = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // pnlParametros
            // 
            this.pnlParametros.Location = new System.Drawing.Point(4, 31);
            this.pnlParametros.Name = "pnlParametros";
            this.pnlParametros.Size = new System.Drawing.Size(249, 181);
            this.pnlParametros.TabIndex = 3;
            // 
            // cmbFig
            // 
            this.cmbFig.FormattingEnabled = true;
            this.cmbFig.Items.AddRange(new object[] {
            "Rombo",
            "Pentágono",
            "Romboide",
            "Trapezoide"});
            this.cmbFig.Location = new System.Drawing.Point(3, 3);
            this.cmbFig.Name = "cmbFig";
            this.cmbFig.Size = new System.Drawing.Size(250, 21);
            this.cmbFig.TabIndex = 2;
            this.cmbFig.SelectedIndexChanged += new System.EventHandler(this.cmbFig_SelectedIndexChanged);
            // 
            // picCnv
            // 
            this.picCnv.Location = new System.Drawing.Point(3, 3);
            this.picCnv.Name = "picCnv";
            this.picCnv.Size = new System.Drawing.Size(508, 420);
            this.picCnv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCnv.TabIndex = 0;
            this.picCnv.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picCnv);
            this.panel2.Location = new System.Drawing.Point(274, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 426);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escala";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rotación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Para mover la figura, mover con las flechas del teclado";
            // 
            // FrmGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGen";
            this.Text = "Figuras";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCnv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlParametros;
        private System.Windows.Forms.ComboBox cmbFig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picCnv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar scaleTrackBar;
        private System.Windows.Forms.TrackBar rotationTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

