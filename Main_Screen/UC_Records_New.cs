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
                flowLayoutPanel2.Controls.Clear();

                using var db = new AE.Infrastructure.Data.AppDbContext();

                var sections = db.Sections
                    .OrderBy(s => s.SectionName)
                    .ToList();

                foreach (var sec in sections)
                {
                    var item = new UC_RecordsClass();
                    item.SetSection(sec.Id);
                    // make sure the control will auto size horizontally in the flow panel
                    item.AutoSize = false;
                    item.Width = currentclassesflowpanel.ClientSize.Width - 25;

                    if (sec.IsArchived)
                    {
                        item.SetArchivedState(true);
                        flowLayoutPanel2.Controls.Add(item);
                    }
                    else
                    {
                        item.SetArchivedState(false);
                        currentclassesflowpanel.Controls.Add(item);
                    }
                }
            }
            catch
            {
                // ignore DB errors at design time
            }
        }

        public void MoveToArchived(UC_RecordsClass item)
        {
            if (item == null) return;
            currentclassesflowpanel.Controls.Remove(item);
            item.AutoSize = false;
            item.Width = flowLayoutPanel2.ClientSize.Width - 25;
            flowLayoutPanel2.Controls.Add(item);
            item.SetArchivedState(true);
        }

        public void MoveToCurrent(UC_RecordsClass item)
        {
            if (item == null) return;
            flowLayoutPanel2.Controls.Remove(item);
            item.AutoSize = false;
            item.Width = currentclassesflowpanel.ClientSize.Width - 25;
            currentclassesflowpanel.Controls.Add(item);
            item.SetArchivedState(false);
        }

        private void currentclassesflowpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
