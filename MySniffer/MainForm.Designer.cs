
namespace MySniffer
{
    partial class MainForm
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
            this.packageBtn = new System.Windows.Forms.Button();
            this.wlanBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // packageBtn
            // 
            this.packageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packageBtn.Location = new System.Drawing.Point(12, 12);
            this.packageBtn.Name = "packageBtn";
            this.packageBtn.Size = new System.Drawing.Size(293, 64);
            this.packageBtn.TabIndex = 0;
            this.packageBtn.Text = "Leer un paquete desde un archivo";
            this.packageBtn.UseVisualStyleBackColor = true;
            this.packageBtn.Click += new System.EventHandler(this.packageBtn_Click);
            // 
            // wlanBtn
            // 
            this.wlanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wlanBtn.Location = new System.Drawing.Point(12, 82);
            this.wlanBtn.Name = "wlanBtn";
            this.wlanBtn.Size = new System.Drawing.Size(293, 64);
            this.wlanBtn.TabIndex = 1;
            this.wlanBtn.Text = "Leer paquete desde la WLAN";
            this.wlanBtn.UseVisualStyleBackColor = true;
            this.wlanBtn.Click += new System.EventHandler(this.wlanBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(12, 152);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(293, 64);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Salir";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 229);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.wlanBtn);
            this.Controls.Add(this.packageBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sniffer | Alejandro Suárez";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button packageBtn;
        private System.Windows.Forms.Button wlanBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

