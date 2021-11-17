
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
            // 
            // PackageCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 369);
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
    }
}