using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UC_Records_New : UserControl
    {
        public UC_Records_New()
        {
            InitializeComponent();
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.RoundControl(CurrentClassespanel, 20);
        }

        private void kryptonPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            UIHelper.RoundControl(ArchivedClassespanel, 20);
        }

        private void UC_Records_New_Load(object sender, EventArgs e)
        {

            try
            {
                currentclassesflowpanel.Controls.Clear();

                using var db = new AE.Infrastructure.Data.AppDbContext();

                    var sections = db.Sections
                        .Where(s => !s.IsArchived)
                        .OrderBy(s => s.SectionName)
                        .ToList();

                    foreach (var sec in sections)
                    {
                        var item = new UC_RecordsClass();
                        item.SetSection(sec.Id);
                        // make sure the control will auto size horizontally in the flow panel
                        item.AutoSize = false;
                        item.Width = currentclassesflowpanel.ClientSize.Width - 25;
                        currentclassesflowpanel.Controls.Add(item);
                    }
            }
            catch
            {
                // ignore DB errors at design time
            }
        }
    }
}
