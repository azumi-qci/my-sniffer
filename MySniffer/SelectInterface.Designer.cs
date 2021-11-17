
namespace MySniffer
{
    partial class SelectInterface
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
            this.interfacesCb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectInterfaceBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // interfacesCb
            // 
            this.interfacesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interfacesCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfacesCb.FormattingEnabled = true;
            this.interfacesCb.Location = new System.Drawing.Point(6, 19);
            this.interfacesCb.Name = "interfacesCb";
            this.interfacesCb.Size = new System.Drawing.Size(336, 28);
            this.interfacesCb.TabIndex = 0;
            this.interfacesCb.SelectedIndexChanged += new System.EventHandler(this.interfacesCb_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectInterfaceBtn);
            this.groupBox1.Controls.Add(this.interfacesCb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecciona una interfaz";
            // 
            // selectInterfaceBtn
            // 
            this.selectInterfaceBtn.Enabled = false;
            this.selectInterfaceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectInterfaceBtn.Location = new System.Drawing.Point(230, 53);
            this.selectInterfaceBtn.Name = "selectInterfaceBtn";
            this.selectInterfaceBtn.Size = new System.Drawing.Size(112, 41);
            this.selectInterfaceBtn.TabIndex = 1;
            this.selectInterfaceBtn.Text = "Seleccionar";
            this.selectInterfaceBtn.UseVisualStyleBackColor = true;
            this.selectInterfaceBtn.Click += new System.EventHandler(this.selectInterfaceBtn_Click);
            // 
            // SelectInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 120);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SelectInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar interfaz | Sniffer";
            this.Load += new System.EventHandler(this.SelectInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox interfacesCb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectInterfaceBtn;
    }
}