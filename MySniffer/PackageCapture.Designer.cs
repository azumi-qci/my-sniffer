
namespace MySniffer
{
    partial class PackageCapture
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
            this.captureLb = new System.Windows.Forms.ListBox();
            this.stopThreadBtn = new System.Windows.Forms.Button();
            this.selectPacketBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // captureLb
            // 
            this.captureLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureLb.FormattingEnabled = true;
            this.captureLb.ItemHeight = 20;
            this.captureLb.Location = new System.Drawing.Point(12, 12);
            this.captureLb.Name = "captureLb";
            this.captureLb.Size = new System.Drawing.Size(537, 284);
            this.captureLb.TabIndex = 0;
            this.captureLb.SelectedIndexChanged += new System.EventHandler(this.captureLb_SelectedIndexChanged);
            // 
            // stopThreadBtn
            // 
            this.stopThreadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopThreadBtn.Location = new System.Drawing.Point(12, 302);
            this.stopThreadBtn.Name = "stopThreadBtn";
            this.stopThreadBtn.Size = new System.Drawing.Size(121, 55);
            this.stopThreadBtn.TabIndex = 1;
            this.stopThreadBtn.Text = "Detener";
            this.stopThreadBtn.UseVisualStyleBackColor = true;
            this.stopThreadBtn.Click += new System.EventHandler(this.stopThreadBtn_Click);
            // 
            // selectPacketBtn
            // 
            this.selectPacketBtn.Enabled = false;
            this.selectPacketBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPacketBtn.Location = new System.Drawing.Point(369, 302);
            this.selectPacketBtn.Name = "selectPacketBtn";
            this.selectPacketBtn.Size = new System.Drawing.Size(180, 55);
            this.selectPacketBtn.TabIndex = 2;
            this.selectPacketBtn.Text = "Seleccionar paquete";
            this.selectPacketBtn.UseVisualStyleBackColor = true;
            this.selectPacketBtn.Click += new System.EventHandler(this.selectPacketBtn_Click);
            // 
            // PackageCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 369);
            this.Controls.Add(this.selectPacketBtn);
            this.Controls.Add(this.stopThreadBtn);
            this.Controls.Add(this.captureLb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PackageCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar paquetes | Sniffer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PackageCapture_FormClosed);
            this.Load += new System.EventHandler(this.PackageCapture_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox captureLb;
        private System.Windows.Forms.Button stopThreadBtn;
        private System.Windows.Forms.Button selectPacketBtn;
    }
}