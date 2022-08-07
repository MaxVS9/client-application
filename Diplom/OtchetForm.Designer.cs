
namespace Diplom
{
    partial class OtchetForm
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.buttonPostroitGrafik = new System.Windows.Forms.Button();
            this.buttonTovar = new System.Windows.Forms.Button();
            this.buttonBudjet = new System.Windows.Forms.Button();
            this.buttonPeriod = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Date1Box = new System.Windows.Forms.DateTimePicker();
            this.Date2Box = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cartesianChart1.Location = new System.Drawing.Point(12, 63);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(776, 340);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // buttonPostroitGrafik
            // 
            this.buttonPostroitGrafik.BackColor = System.Drawing.Color.White;
            this.buttonPostroitGrafik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPostroitGrafik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPostroitGrafik.ForeColor = System.Drawing.Color.Black;
            this.buttonPostroitGrafik.Location = new System.Drawing.Point(12, 12);
            this.buttonPostroitGrafik.Name = "buttonPostroitGrafik";
            this.buttonPostroitGrafik.Size = new System.Drawing.Size(258, 45);
            this.buttonPostroitGrafik.TabIndex = 2;
            this.buttonPostroitGrafik.Text = "Доходы\\Расходы";
            this.buttonPostroitGrafik.UseVisualStyleBackColor = false;
            this.buttonPostroitGrafik.Click += new System.EventHandler(this.buttonPostroitGrafik_Click);
            // 
            // buttonTovar
            // 
            this.buttonTovar.BackColor = System.Drawing.Color.White;
            this.buttonTovar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTovar.ForeColor = System.Drawing.Color.Black;
            this.buttonTovar.Location = new System.Drawing.Point(530, 12);
            this.buttonTovar.Name = "buttonTovar";
            this.buttonTovar.Size = new System.Drawing.Size(258, 45);
            this.buttonTovar.TabIndex = 3;
            this.buttonTovar.Text = "Товары";
            this.buttonTovar.UseVisualStyleBackColor = false;
            this.buttonTovar.Click += new System.EventHandler(this.buttonTovar_Click);
            // 
            // buttonBudjet
            // 
            this.buttonBudjet.BackColor = System.Drawing.Color.White;
            this.buttonBudjet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonBudjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBudjet.ForeColor = System.Drawing.Color.Black;
            this.buttonBudjet.Location = new System.Drawing.Point(271, 12);
            this.buttonBudjet.Name = "buttonBudjet";
            this.buttonBudjet.Size = new System.Drawing.Size(258, 45);
            this.buttonBudjet.TabIndex = 4;
            this.buttonBudjet.Text = "Бюджет";
            this.buttonBudjet.UseVisualStyleBackColor = false;
            this.buttonBudjet.Click += new System.EventHandler(this.buttonBudjet_Click);
            // 
            // buttonPeriod
            // 
            this.buttonPeriod.BackColor = System.Drawing.Color.White;
            this.buttonPeriod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPeriod.ForeColor = System.Drawing.Color.Black;
            this.buttonPeriod.Location = new System.Drawing.Point(530, 409);
            this.buttonPeriod.Name = "buttonPeriod";
            this.buttonPeriod.Size = new System.Drawing.Size(258, 29);
            this.buttonPeriod.TabIndex = 22;
            this.buttonPeriod.Text = "Задать период";
            this.buttonPeriod.UseVisualStyleBackColor = false;
            this.buttonPeriod.Click += new System.EventHandler(this.buttonPeriod_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "С";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(254, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "ПО";
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.White;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.Red;
            this.CloseButton.Location = new System.Drawing.Point(797, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(34, 30);
            this.CloseButton.TabIndex = 25;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Date1Box
            // 
            this.Date1Box.CustomFormat = "yyyy.MM.dd";
            this.Date1Box.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date1Box.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date1Box.Location = new System.Drawing.Point(38, 409);
            this.Date1Box.Name = "Date1Box";
            this.Date1Box.Size = new System.Drawing.Size(210, 29);
            this.Date1Box.TabIndex = 28;
            // 
            // Date2Box
            // 
            this.Date2Box.CustomFormat = "yyyy.MM.dd";
            this.Date2Box.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date2Box.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date2Box.Location = new System.Drawing.Point(292, 409);
            this.Date2Box.Name = "Date2Box";
            this.Date2Box.Size = new System.Drawing.Size(210, 29);
            this.Date2Box.TabIndex = 29;
            // 
            // OtchetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.Date2Box);
            this.Controls.Add(this.Date1Box);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPeriod);
            this.Controls.Add(this.buttonBudjet);
            this.Controls.Add(this.buttonTovar);
            this.Controls.Add(this.buttonPostroitGrafik);
            this.Controls.Add(this.cartesianChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OtchetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OtchetForm";
            this.Load += new System.EventHandler(this.OtchetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button buttonPostroitGrafik;
        private System.Windows.Forms.Button buttonTovar;
        private System.Windows.Forms.Button buttonBudjet;
        private System.Windows.Forms.Button buttonPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.DateTimePicker Date1Box;
        private System.Windows.Forms.DateTimePicker Date2Box;
    }
}