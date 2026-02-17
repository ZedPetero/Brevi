using System;
using System.Drawing;
using System.Windows.Forms;

namespace AE.Application
{
    public static class ThemeManager
    {
        private static readonly Color DarkFormColor = Color.FromArgb(34, 34, 34);
        private static readonly Color DarkControlColor = Color.FromArgb(45, 45, 48);

        public static bool IsDarkMode { get; private set; }

        public static void SetDarkMode(bool enabled)
        {
            IsDarkMode = enabled;

            // Apply to already open forms (skip login screen)
            foreach (Form f in global::System.Windows.Forms.Application.OpenForms)
            {
                if (f.GetType().Name == "Login_Screen_Form")
                    continue;

                ApplyThemeToForm(f);
            }
        }

        public static void ApplyThemeToForm(Form form)
        {
            if (form == null) return;

            if (IsDarkMode)
                form.BackColor = DarkFormColor;
            else
                form.BackColor = SystemColors.Window;

            ApplyThemeRecursively(form, IsDarkMode);
        }

        public static void ApplyThemeRecursively(Control parent, bool dark)
        {
            if (parent == null) return;

            foreach (Control c in parent.Controls)
            {
                try
                {
                    if (dark)
                    {
                        // Do not change ForeColor per requirement
                        if (c is Panel || c is UserControl || c is GroupBox)
                            c.BackColor = DarkFormColor;
                        else if (c is TextBox || c is RichTextBox || c is ComboBox || c is ListBox)
                            c.BackColor = DarkControlColor;
                        else if (c is Button || c is CheckBox || c is RadioButton)
                            c.BackColor = DarkControlColor;
                        else if (c is Label)
                        {
                            if (c.BackColor != Color.Transparent)
                                c.BackColor = DarkFormColor;
                        }
                        else
                        {
                            c.BackColor = DarkFormColor;
                        }
                    }
                    else
                    {
                        // Reset to system defaults conservatively
                        if (c is TextBox || c is RichTextBox)
                            c.BackColor = SystemColors.Window;
                        else if (c is Button)
                            c.BackColor = SystemColors.Control;
                        else
                            c.BackColor = SystemColors.Control;
                    }
                }
                catch
                {
                    // ignore controls that throw when setting BackColor
                }

                if (c.HasChildren)
                    ApplyThemeRecursively(c, dark);
            }
        }
    }
}
