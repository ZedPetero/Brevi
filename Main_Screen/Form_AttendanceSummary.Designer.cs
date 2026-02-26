namespace AE.Application
{
    partial class Form_AttendanceSummary
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
            gridSummary = new Krypton.Toolkit.KryptonDataGridView();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            btnDownloadCSV = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)gridSummary).BeginInit();
            SuspendLayout();
            // 
            // gridSummary
            // 
            gridSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSummary.BorderStyle = BorderStyle.None;
            gridSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSummary.Location = new Point(31, 115);
            gridSummary.Name = "gridSummary";
            gridSummary.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007Blue;
            gridSummary.RowTemplate.Height = 35;
            gridSummary.Size = new Size(736, 311);
            gridSummary.StateCommon.Background.Color1 = Color.White;
            gridSummary.StateCommon.Background.Color2 = Color.White;
            gridSummary.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            gridSummary.StateCommon.HeaderColumn.Content.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridSummary.TabIndex = 0;
            gridSummary.CellFormatting += gridSummary_CellFormatting;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(31, 29);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(259, 34);
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonLabel1.TabIndex = 1;
            kryptonLabel1.Values.Text = "Attendance Summary";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(31, 75);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(504, 25);
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonLabel2.TabIndex = 2;
            kryptonLabel2.Values.Text = "Score calculation: Present = 100%, Late = 50%, Absent = 0%";
            // 
            // btnDownloadCSV
            // 
            btnDownloadCSV.Location = new Point(664, 29);
            btnDownloadCSV.Name = "btnDownloadCSV";
            btnDownloadCSV.Size = new Size(103, 34);
            btnDownloadCSV.StateCommon.Back.Color1 = Color.Teal;
            btnDownloadCSV.StateCommon.Back.Color2 = Color.Teal;
            btnDownloadCSV.StateCommon.Border.Color1 = Color.Teal;
            btnDownloadCSV.StateCommon.Border.Rounding = 5F;
            btnDownloadCSV.StateCommon.Content.ShortText.Color1 = Color.White;
            btnDownloadCSV.TabIndex = 3;
            btnDownloadCSV.Values.DropDownArrowColor = Color.Empty;
            btnDownloadCSV.Values.Text = "Download CSV";
            btnDownloadCSV.Click += btnDownloadCSV_Click;
            // 
            // Form_AttendanceSummary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDownloadCSV);
            Controls.Add(kryptonLabel2);
            Controls.Add(kryptonLabel1);
            Controls.Add(gridSummary);
            Name = "Form_AttendanceSummary";
            Text = "Form_AttendanceSummary";
            Load += Form_AttendanceSummary_Load;
            ((System.ComponentModel.ISupportInitialize)gridSummary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView gridSummary;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton btnDownloadCSV;
    }
}