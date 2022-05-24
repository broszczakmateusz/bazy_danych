namespace Sklep_komputerowy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tabControlPracownicy = new System.Windows.Forms.TabControl();
            this.tabPagePracownicy = new System.Windows.Forms.TabPage();
            this.dataViewPracownicy = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.azurePostgresCreateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlPracownicy.SuspendLayout();
            this.tabPagePracownicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewPracownicy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.azurePostgresCreateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // tabControlPracownicy
            // 
            this.tabControlPracownicy.Controls.Add(this.tabPagePracownicy);
            this.tabControlPracownicy.Controls.Add(this.tabPage2);
            this.tabControlPracownicy.Location = new System.Drawing.Point(26, 12);
            this.tabControlPracownicy.Name = "tabControlPracownicy";
            this.tabControlPracownicy.SelectedIndex = 0;
            this.tabControlPracownicy.Size = new System.Drawing.Size(1776, 853);
            this.tabControlPracownicy.TabIndex = 0;
            // 
            // tabPagePracownicy
            // 
            this.tabPagePracownicy.Controls.Add(this.button1);
            this.tabPagePracownicy.Controls.Add(this.dataViewPracownicy);
            this.tabPagePracownicy.Location = new System.Drawing.Point(4, 34);
            this.tabPagePracownicy.Name = "tabPagePracownicy";
            this.tabPagePracownicy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePracownicy.Size = new System.Drawing.Size(1768, 815);
            this.tabPagePracownicy.TabIndex = 0;
            this.tabPagePracownicy.Text = "tabPage1";
            this.tabPagePracownicy.UseVisualStyleBackColor = true;
            this.tabPagePracownicy.Click += new System.EventHandler(this.tabPagePracownicy_Click);
            // 
            // dataViewPracownicy
            // 
            this.dataViewPracownicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewPracownicy.Location = new System.Drawing.Point(20, 71);
            this.dataViewPracownicy.Name = "dataViewPracownicy";
            this.dataViewPracownicy.RowHeadersWidth = 62;
            this.dataViewPracownicy.RowTemplate.Height = 33;
            this.dataViewPracownicy.Size = new System.Drawing.Size(1727, 721);
            this.dataViewPracownicy.TabIndex = 0;
            this.dataViewPracownicy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewPracownicy_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1768, 815);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1814, 877);
            this.Controls.Add(this.tabControlPracownicy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlPracownicy.ResumeLayout(false);
            this.tabPagePracownicy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewPracownicy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.azurePostgresCreateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TabControl tabControlPracownicy;
        private System.Windows.Forms.TabPage tabPagePracownicy;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource azurePostgresCreateBindingSource;
        private System.Windows.Forms.DataGridView dataViewPracownicy;
        private System.Windows.Forms.Button button1;
    }
}
