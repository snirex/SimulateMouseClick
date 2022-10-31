using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimulateMouseClick
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Global Keyboard Shortcut
        /// </summary>
        KeyboardHook hook = new KeyboardHook();

        private string FileNamesHistory = "filenames.txt";
        public Form1()
        {
            InitializeComponent();
        }

        public MouseClicks SelectedTab
        {
            get { return (tabControl1.SelectedTab.Controls[0] as MouseClicks); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load files history
            string filenames = IO.ReadFilePath(FileNamesHistory);

            try
            {
                if (filenames.Length > 0)
                {
                    string[] ar = filenames.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < ar.Length; i++)
                    {
                        LoadFile(ar[i]);
                    }
                }
                else
                {
                    AddTab($"snir {tabControl1.TabPages.Count + 1}");
                }

                //KeyPress Event Registeration the event that is fired after key press
                hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

                //register the ctrl+Q combination as hot key
                hook.RegisterHotKey(SimulateMouseClick.ModifierKeys.Contorl, Keys.Q);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int cnt = tabControl1.TabPages.Count;
            string filenames = "";

            //collect all opened tabs
            foreach (TabPage tb in tabControl1.TabPages)
            {
                var tab = (tb.Controls[0] as MouseClicks);
                if (tab.FilePath.Length > 0)
                {
                    filenames += tab.FilePath + Environment.NewLine;
                }
            }

            //save list of tabs on a file
            if (filenames.Length > 0)
            {
                bool b = IO.WriteFileContent(FileNamesHistory, filenames);
            }
        }

        private void AddTab(string text = "", string content = "", string filename = "")
        {
            TabPage tp = new TabPage();
            var me = new MouseClicks
            {
                Dock = DockStyle.Fill,
                MyEvents = content,
                FilePath = filename
            };
            me.minimizeOnStart_event += ((bool_minimize) =>
            {
                if (bool_minimize)
                    this.WindowState = FormWindowState.Minimized;
            });
            tp.Controls.Add(me);
            tp.Text = text;
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (tabControl1.TabPages.Count > 0 &&
                e.Key == Keys.Q && e.Modifier == SimulateMouseClick.ModifierKeys.Contorl)
            {
                SelectedTab.HotKeyPressed();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
                AddTab($"snir {tabControl1.TabPages.Count + 1}");
            //MouseClicks tab = (tabControl1.SelectedTab.Controls[0] as MouseClicks);
            var tab = SelectedTab;
            if (tab.FilePath.Length > 0)
                Save(tab, tab.FilePath);
            else
                SaveAs(tab);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
                AddTab($"snir {tabControl1.TabPages.Count + 1}");
            //var tab = (tabControl1.SelectedTab.Controls[0] as MouseClicks);
            var tab = SelectedTab;
            SaveAs(tab);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFilesDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab($"snir {tabControl1.TabPages.Count + 1}");
        }

        private void closeCurrentTab_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }

        /// <summary>
        /// open in notepad
        /// </summary>
        private void openInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInNotepad();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadTabListbox();

        }

        private void OpenInNotepad()
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            var tab_mouseclick = SelectedTab; //(tabControl1.SelectedTab.Controls[0] as MouseClicks);
            if (tab_mouseclick.FilePath.Length == 0)
                return;
            try
            {
                System.Diagnostics.Process.Start(SelectedTab.FilePath);//(tabControl1.SelectedTab.Controls[0] as MouseClicks).FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region IO

        private void ReloadTabListbox()
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            var tab_mouseclick = SelectedTab; //(tabControl1.SelectedTab.Controls[0] as MouseClicks);
            if (tab_mouseclick.FilePath.Length == 0)
                return;
            string contents = IO.ReadFilePath(tab_mouseclick.FilePath);
            tab_mouseclick.ClearListbox();
            tab_mouseclick.MyEvents = contents;
        }

        private void Save(MouseClicks tab, string fileName)
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            try
            {
                string content = tab.MyEvents;
                if (!IO.WriteFileContent(fileName, content))
                    throw new Exception("Write File Error");
                tab.FilePath = fileName;
                string title = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                tabControl1.SelectedTab.Text = title;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAs(MouseClicks tab)
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    DefaultExt = "txt",
                    AddExtension = true,
                    Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Save text file"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Save(tab, sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFilesDialog()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    DefaultExt = "*.txt",
                    AddExtension = true,
                    Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Open text files",
                    Multiselect = true
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string content, title;

                    foreach (string filename in ofd.FileNames)
                    {
                        LoadFile(filename);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFile(string filename)
        {
            string content = IO.ReadFilePath(filename);
            string title = filename.Substring(filename.LastIndexOf('\\') + 1);
            AddTab(title, content, filename);
        }



        #endregion

        private void notifyIconMenu_Opening(object sender, CancelEventArgs e)
        {
            notifyIconMenu.Items.Clear();
            ToolStripMenuItem tsmi;
            foreach (TabPage item in tabControl1.TabPages)
            {
                tsmi = new ToolStripMenuItem() { Text = item.Text };
                tsmi.Click += (s, ev) =>
                {
                    (item.Controls[0] as MouseClicks).RunScript();
                };
                notifyIconMenu.Items.Add(tsmi);
            }
        }
    }
}
