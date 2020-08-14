namespace Punto1
{
    partial class Form1
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
            this.TXTNumber = new System.Windows.Forms.TextBox();
            this.DTP = new System.Windows.Forms.DateTimePicker();
            this.btnScan = new System.Windows.Forms.Button();
            this.lstError = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPerfectos = new System.Windows.Forms.TextBox();
            this.btnPerfectos = new System.Windows.Forms.Button();
            this.lstperfects = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXTNumber
            // 
            this.TXTNumber.Location = new System.Drawing.Point(12, 29);
            this.TXTNumber.Name = "TXTNumber";
            this.TXTNumber.Size = new System.Drawing.Size(144, 20);
            this.TXTNumber.TabIndex = 0;
            this.TXTNumber.TextChanged += new System.EventHandler(this.TXTNumber_TextChanged);
            this.TXTNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTNumber_TextChanged);
            // 
            // DTP
            // 
            this.DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP.Location = new System.Drawing.Point(221, 29);
            this.DTP.Name = "DTP";
            this.DTP.Size = new System.Drawing.Size(166, 20);
            this.DTP.TabIndex = 1;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 219);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(375, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Escanear Tarjeta";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lstError
            // 
            this.lstError.FormattingEnabled = true;
            this.lstError.Location = new System.Drawing.Point(12, 103);
            this.lstError.Name = "lstError";
            this.lstError.Size = new System.Drawing.Size(375, 95);
            this.lstError.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Si se encuentran errores, se mostraran a continuacion:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Digite el numero de su tarjeta.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seleccione la fecha de caducidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Digite la cantidad de numeros a evaluar";
            // 
            // txtPerfectos
            // 
            this.txtPerfectos.Location = new System.Drawing.Point(465, 32);
            this.txtPerfectos.Name = "txtPerfectos";
            this.txtPerfectos.Size = new System.Drawing.Size(250, 20);
            this.txtPerfectos.TabIndex = 7;
            this.txtPerfectos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerfect);
            // 
            // btnPerfectos
            // 
            this.btnPerfectos.Location = new System.Drawing.Point(465, 219);
            this.btnPerfectos.Name = "btnPerfectos";
            this.btnPerfectos.Size = new System.Drawing.Size(250, 23);
            this.btnPerfectos.TabIndex = 9;
            this.btnPerfectos.Text = "Evaluar Perfectos";
            this.btnPerfectos.UseVisualStyleBackColor = true;
            this.btnPerfectos.Click += new System.EventHandler(this.btnPerfectos_Click);
            // 
            // lstperfects
            // 
            this.lstperfects.FormattingEnabled = true;
            this.lstperfects.Location = new System.Drawing.Point(465, 103);
            this.lstperfects.Name = "lstperfects";
            this.lstperfects.Size = new System.Drawing.Size(250, 95);
            this.lstperfects.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Los numeros perfectos se mostraran a continuacion:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstperfects);
            this.Controls.Add(this.btnPerfectos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPerfectos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstError);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.DTP);
            this.Controls.Add(this.TXTNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTNumber;
        private System.Windows.Forms.DateTimePicker DTP;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox lstError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPerfectos;
        private System.Windows.Forms.Button btnPerfectos;
        private System.Windows.Forms.ListBox lstperfects;
        private System.Windows.Forms.Label label5;
    }
}

