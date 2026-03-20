namespace AE.Application
{
    partial class UC_RecordsClass
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ArchiveorRestorebutton = new Krypton.Toolkit.KryptonButton();
            sidebarbtn = new Krypton.Toolkit.KryptonButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            classnamelabel = new Krypton.Toolkit.KryptonLabel();
            AmountofStudentslabel = new Krypton.Toolkit.KryptonLabel();
            classinfotable = new TableLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ArchiveorRestorebutton
            // 
            ArchiveorRestorebutton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ArchiveorRestorebutton.Location = new Point(427, 3);
            ArchiveorRestorebutton.Name = "ArchiveorRestorebutton";
            ArchiveorRestorebutton.Size = new Size(90, 37);
            ArchiveorRestorebutton.StateCommon.Border.Rounding = 20F;
            ArchiveorRestorebutton.StateCommon.Content.ShortText.Color1 = Color.White;
            ArchiveorRestorebutton.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ArchiveorRestorebutton.StateNormal.Back.Color1 = Color.FromArgb(39, 165, 153);
            ArchiveorRestorebutton.StateNormal.Back.Color2 = Color.FromArgb(39, 165, 153);
            ArchiveorRestorebutton.TabIndex = 13;
            ArchiveorRestorebutton.Values.DropDownArrowColor = Color.Empty;
            ArchiveorRestorebutton.Values.Text = "Archive";
            // 
            // sidebarbtn
            // 
            sidebarbtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sidebarbtn.Location = new Point(523, 3);
            sidebarbtn.Name = "sidebarbtn";
            sidebarbtn.Size = new Size(34, 37);
            sidebarbtn.StateCommon.Border.Rounding = 5F;
            sidebarbtn.StateCommon.Content.ShortText.Font = new Font("Material Symbols Sharp", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sidebarbtn.StateNormal.Back.Color1 = Color.White;
            sidebarbtn.StateNormal.Back.Color2 = Color.White;
            sidebarbtn.TabIndex = 15;
            sidebarbtn.Values.DropDownArrowColor = Color.Empty;
            sidebarbtn.Values.Text = "";
            sidebarbtn.Click += kryptonButton1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(classnamelabel);
            flowLayoutPanel1.Controls.Add(AmountofStudentslabel);
            flowLayoutPanel1.Controls.Add(ArchiveorRestorebutton);
            flowLayoutPanel1.Controls.Add(sidebarbtn);
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(573, 40);
            flowLayoutPanel1.TabIndex = 16;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // classnamelabel
            // 
            classnamelabel.Location = new Point(3, 3);
            classnamelabel.Name = "classnamelabel";
            classnamelabel.Size = new Size(183, 37);
            classnamelabel.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            classnamelabel.StateNormal.ShortText.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            classnamelabel.TabIndex = 17;
            classnamelabel.Values.Text = "Class Name";
            // 
            // AmountofStudentslabel
            // 
            AmountofStudentslabel.Location = new Point(192, 3);
            AmountofStudentslabel.Name = "AmountofStudentslabel";
            AmountofStudentslabel.Size = new Size(229, 37);
            AmountofStudentslabel.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AmountofStudentslabel.TabIndex = 16;
            AmountofStudentslabel.Values.Text = "Students";
            // 
            // classinfotable
            // 
            classinfotable.ColumnCount = 2;
            classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            classinfotable.Location = new Point(0, 46);
            classinfotable.Name = "classinfotable";
            classinfotable.RowCount = 2;
            classinfotable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            classinfotable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            classinfotable.Size = new Size(573, 200);
            classinfotable.TabIndex = 17;
            classinfotable.Paint += classinfotable_Paint;
            // 
            // UC_RecordsClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(classinfotable);
            Controls.Add(flowLayoutPanel1);
            Name = "UC_RecordsClass";
            Size = new Size(573, 246);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonButton ArchiveorRestorebutton;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton sidebarbtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Krypton.Toolkit.KryptonLabel AmountofStudentslabel;
        private TableLayoutPanel classinfotable;
        private Krypton.Toolkit.KryptonLabel classnamelabel;
    }
}
