
namespace MySniffer
{
    partial class TCPInfo
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
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.originPortNameTb = new System.Windows.Forms.TextBox();
            this.originPortTb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.destinationPortNameTb = new System.Windows.Forms.TextBox();
            this.destinationPortTb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sequenceNumberRawTb = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.confirmationNumberRawTb = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.headerLengthTb = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.reservedBitsTb = new System.Windows.Forms.TextBox();
            this.groupBox17.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.originPortNameTb);
            this.groupBox17.Controls.Add(this.originPortTb);
            this.groupBox17.Location = new System.Drawing.Point(12, 12);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(193, 83);
            this.groupBox17.TabIndex = 9;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Puerto fuente";
            // 
            // originPortNameTb
            // 
            this.originPortNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originPortNameTb.Location = new System.Drawing.Point(6, 51);
            this.originPortNameTb.Name = "originPortNameTb";
            this.originPortNameTb.ReadOnly = true;
            this.originPortNameTb.Size = new System.Drawing.Size(181, 26);
            this.originPortNameTb.TabIndex = 10;
            // 
            // originPortTb
            // 
            this.originPortTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originPortTb.Location = new System.Drawing.Point(6, 19);
            this.originPortTb.Name = "originPortTb";
            this.originPortTb.ReadOnly = true;
            this.originPortTb.Size = new System.Drawing.Size(181, 26);
            this.originPortTb.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.destinationPortNameTb);
            this.groupBox1.Controls.Add(this.destinationPortTb);
            this.groupBox1.Location = new System.Drawing.Point(211, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 83);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puerto destino";
            // 
            // destinationPortNameTb
            // 
            this.destinationPortNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationPortNameTb.Location = new System.Drawing.Point(6, 51);
            this.destinationPortNameTb.Name = "destinationPortNameTb";
            this.destinationPortNameTb.ReadOnly = true;
            this.destinationPortNameTb.Size = new System.Drawing.Size(181, 26);
            this.destinationPortNameTb.TabIndex = 10;
            // 
            // destinationPortTb
            // 
            this.destinationPortTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationPortTb.Location = new System.Drawing.Point(6, 19);
            this.destinationPortTb.Name = "destinationPortTb";
            this.destinationPortTb.ReadOnly = true;
            this.destinationPortTb.Size = new System.Drawing.Size(181, 26);
            this.destinationPortTb.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 54);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Número de secuencia (relativo)";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(181, 26);
            this.textBox2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sequenceNumberRawTb);
            this.groupBox3.Location = new System.Drawing.Point(211, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 54);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Número de secuencia (crudo)";
            // 
            // sequenceNumberRawTb
            // 
            this.sequenceNumberRawTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequenceNumberRawTb.Location = new System.Drawing.Point(6, 19);
            this.sequenceNumberRawTb.Name = "sequenceNumberRawTb";
            this.sequenceNumberRawTb.ReadOnly = true;
            this.sequenceNumberRawTb.Size = new System.Drawing.Size(181, 26);
            this.sequenceNumberRawTb.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.confirmationNumberRawTb);
            this.groupBox4.Location = new System.Drawing.Point(211, 161);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 54);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Número de confirmación (crudo)";
            // 
            // confirmationNumberRawTb
            // 
            this.confirmationNumberRawTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmationNumberRawTb.Location = new System.Drawing.Point(6, 19);
            this.confirmationNumberRawTb.Name = "confirmationNumberRawTb";
            this.confirmationNumberRawTb.ReadOnly = true;
            this.confirmationNumberRawTb.Size = new System.Drawing.Size(181, 26);
            this.confirmationNumberRawTb.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Location = new System.Drawing.Point(12, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(193, 54);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Número de confirmación (relativo)";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(6, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(181, 26);
            this.textBox4.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.headerLengthTb);
            this.groupBox6.Location = new System.Drawing.Point(12, 221);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(193, 54);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Longitud de la cabecera";
            // 
            // headerLengthTb
            // 
            this.headerLengthTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLengthTb.Location = new System.Drawing.Point(6, 19);
            this.headerLengthTb.Name = "headerLengthTb";
            this.headerLengthTb.ReadOnly = true;
            this.headerLengthTb.Size = new System.Drawing.Size(181, 26);
            this.headerLengthTb.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.reservedBitsTb);
            this.groupBox7.Location = new System.Drawing.Point(211, 221);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(193, 54);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Bits de reserva";
            // 
            // reservedBitsTb
            // 
            this.reservedBitsTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservedBitsTb.Location = new System.Drawing.Point(6, 19);
            this.reservedBitsTb.Name = "reservedBitsTb";
            this.reservedBitsTb.ReadOnly = true;
            this.reservedBitsTb.Size = new System.Drawing.Size(181, 26);
            this.reservedBitsTb.TabIndex = 1;
            // 
            // TCPInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox17);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCPInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cabecera TCP | Mi sniffer";
            this.Load += new System.EventHandler(this.TCPInfo_Load);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox originPortNameTb;
        private System.Windows.Forms.TextBox originPortTb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox destinationPortNameTb;
        private System.Windows.Forms.TextBox destinationPortTb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox sequenceNumberRawTb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox confirmationNumberRawTb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox headerLengthTb;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox reservedBitsTb;
    }
}