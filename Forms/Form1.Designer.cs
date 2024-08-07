namespace organizadorFamilia
{
    partial class Form1
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOrigen = new System.Windows.Forms.Label();
            this.textBoxOrigen = new System.Windows.Forms.TextBox();
            this.btnOrigen = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.btnDestino = new System.Windows.Forms.Button();
            this.textBoxArchivoExcel = new System.Windows.Forms.TextBox();
            this.btnAbrirExcel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblControl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblControl);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelOrigen);
            this.panel1.Controls.Add(this.textBoxOrigen);
            this.panel1.Controls.Add(this.btnOrigen);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.btnProcesar);
            this.panel1.Controls.Add(this.textBoxDestino);
            this.panel1.Controls.Add(this.btnDestino);
            this.panel1.Controls.Add(this.textBoxArchivoExcel);
            this.panel1.Controls.Add(this.btnAbrirExcel);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 366);
            this.panel1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 244);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(639, 24);
            this.progressBar.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seleccionar destino de los datos";
            // 
            // labelOrigen
            // 
            this.labelOrigen.AutoSize = true;
            this.labelOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrigen.Location = new System.Drawing.Point(26, 20);
            this.labelOrigen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrigen.Name = "labelOrigen";
            this.labelOrigen.Size = new System.Drawing.Size(203, 16);
            this.labelOrigen.TabIndex = 9;
            this.labelOrigen.Text = "Seleccionar origen de datos";
            // 
            // textBoxOrigen
            // 
            this.textBoxOrigen.Location = new System.Drawing.Point(28, 49);
            this.textBoxOrigen.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOrigen.Name = "textBoxOrigen";
            this.textBoxOrigen.Size = new System.Drawing.Size(513, 22);
            this.textBoxOrigen.TabIndex = 8;
            // 
            // btnOrigen
            // 
            this.btnOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrigen.Location = new System.Drawing.Point(565, 49);
            this.btnOrigen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrigen.Name = "btnOrigen";
            this.btnOrigen.Size = new System.Drawing.Size(102, 24);
            this.btnOrigen.TabIndex = 7;
            this.btnOrigen.Text = "Seleccionar";
            this.btnOrigen.UseVisualStyleBackColor = true;
            this.btnOrigen.Click += new System.EventHandler(this.btnOrigen_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(26, 165);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(145, 16);
            this.labelInfo.TabIndex = 5;
            this.labelInfo.Text = "Seleccionar archivo";
            this.labelInfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Location = new System.Drawing.Point(364, 290);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(150, 35);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "Copiar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Location = new System.Drawing.Point(28, 113);
            this.textBoxDestino.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(513, 22);
            this.textBoxDestino.TabIndex = 3;
            // 
            // btnDestino
            // 
            this.btnDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestino.Location = new System.Drawing.Point(565, 111);
            this.btnDestino.Margin = new System.Windows.Forms.Padding(2);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(102, 24);
            this.btnDestino.TabIndex = 2;
            this.btnDestino.Text = "Seleccionar";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // textBoxArchivoExcel
            // 
            this.textBoxArchivoExcel.Location = new System.Drawing.Point(28, 184);
            this.textBoxArchivoExcel.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxArchivoExcel.Name = "textBoxArchivoExcel";
            this.textBoxArchivoExcel.Size = new System.Drawing.Size(513, 22);
            this.textBoxArchivoExcel.TabIndex = 1;
            // 
            // btnAbrirExcel
            // 
            this.btnAbrirExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirExcel.Location = new System.Drawing.Point(565, 184);
            this.btnAbrirExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrirExcel.Name = "btnAbrirExcel";
            this.btnAbrirExcel.Size = new System.Drawing.Size(102, 24);
            this.btnAbrirExcel.TabIndex = 0;
            this.btnAbrirExcel.Text = "Seleccionar";
            this.btnAbrirExcel.UseVisualStyleBackColor = true;
            this.btnAbrirExcel.Click += new System.EventHandler(this.btnAbrirExcel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(518, 290);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 35);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.Location = new System.Drawing.Point(26, 299);
            this.lblControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(73, 16);
            this.lblControl.TabIndex = 13;
            this.lblControl.Text = "lblControl";
            this.lblControl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(730, 386);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Organizador de familias";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.TextBox textBoxArchivoExcel;
        private System.Windows.Forms.Button btnAbrirExcel;
        private System.Windows.Forms.TextBox textBoxOrigen;
        private System.Windows.Forms.Button btnOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOrigen;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.Button btnCancelar;
    }
}

