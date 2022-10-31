using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.IO;

namespace SimulateMouseClick
{
    public partial class MouseClicks : UserControl
    {
        private const string Pause = "Pause";
        private const string LeftClick = "LeftClick";
        private const string RightClick = "RightClick";
        private const string DoubleClick = "DoubleClick";
        private const string SetClipboardText = "SetClipboardText";
        private const string TypeText = "TypeText";
        private const string PasteText = "Paste";

        enum MouseEvents
        {
            LeftClick,
            RightClick,
            DoubleClick,
            /// <summary>Set Clipboard value</summary>
            SetClipboard
        }
        /// <summary>
        /// enum for moving items in the list
        /// </summary>
        enum Direction
        {
            Up = -1,
            Down = 1
        }

        public string FilePath { get; set; }
        public string MyEvents
        {
            get
            {
                string content = "";
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    content += listBox1.Items[i] + "\n";
                }
                return content;
            }
            set
            {
                string content = value;
                while (content.Contains("  "))
                {
                    content = content.Replace("  ", " ");
                }
                foreach (var item in content.Split('\n'))
                {
                    if (item.Trim().Length > 0)
                        listBox1.Items.Add(item);
                }
            }
        }

        char CommentChar = '-';
        bool RecordPause = true;
        bool ScriptRunning = false;

        /// <summary>
        /// listBox1.SelectedIndex
        /// </summary>
        int SelectedLineIndex = -1;
        new System.Windows.Forms.Timer tmrEvents;
        new System.Windows.Forms.Timer tmrRecord;

        int idx = 0;
        int recordCounter = 0;
        int pauseCounter = 0;
        int timerInterval = 50;

        Clicks clicks;
        KeyboardSimulator KeyboardSimulator;
        KeyboardHook hook = new KeyboardHook();

        /// <summary>ctor</summary>
        public MouseClicks()
        {
            InitializeComponent();
            clicks = new Clicks();
            KeyboardSimulator = new KeyboardSimulator();
        }

        private void RunListboxCommand()
        {
            if (listBox1.SelectedIndex < 0)
                return;

            string[] ar;
            string item, pos, str;
            string textToType = "";
            int textIdx = 0;
            Point pnt,
                p_user_position = Cursor.Position;

            try
            {
                listBox1.SelectedIndex = idx;
                item = $"{listBox1.SelectedItem}";
                ar = item.Split(' ');
                str = ar[0];

            //TextTyping:
                switch (str)
                {
                    case LeftClick:
                        pos = ar[1].TrimStart('(').TrimEnd(')');
                        pnt = new Point(int.Parse(pos.Split(',')[0]), int.Parse(pos.Split(',')[1]));
                        clicks.leftClick(pnt);
                        break;
                    case RightClick:
                        pos = ar[1].TrimStart('(').TrimEnd(')');
                        pnt = new Point(int.Parse(pos.Split(',')[0]), int.Parse(pos.Split(',')[1]));
                        clicks.rightClick(pnt);
                        break;
                    case DoubleClick:
                        pos = ar[1].TrimStart('(').TrimEnd(')');
                        pnt = new Point(int.Parse(pos.Split(',')[0]), int.Parse(pos.Split(',')[1]));
                        clicks.doubleClick(pnt);
                        break;
                    //case "TypeText":
                    //    KeyboardSimulator.TypeText("3333", "IntaffClient.UI");
                    //    break;
                    case Pause:
                        string a = GetValueBetweenBraces(ar[1]);
                        pauseCounter = int.Parse(a);
                        break;
                    case SetClipboardText:
                        Clipboard.SetText(item.Substring(item.IndexOf(" ") + 1));
                        break;
                    case PasteText:
                        SendKeys.SendWait("^V");
                        break;
                    //case TypeText:
                    //    if (textToType.Length == 0)
                    //        textToType = item.Substring(item.IndexOf(' ') + 1); //  get only the the text to type
                    //    string chr = $"{textToType[0]}";
                    //    Clipboard.SetText(chr);//set first char to clipboard
                    //    textToType = textToType.Remove(0, 1);//remove first char
                    //    SendKeys.SendWait("^V");
                    //    Thread.Sleep(20);
                    //    if (textToType.Length > 0)
                    //        goto TextTyping;
                    //    break;
                    default:
                        break;
                }

                //return to user position
                if (chkReturnToUserPos.Checked)
                {
                    pauseCounter += 50;
                    Cursor.Position = p_user_position;
                }

                idx++;
                if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
                {
                    // Stop running
                    if (rdbOneTime.Checked)
                        Stop();

                    if (rdbMultipleTimes.Checked && numMultipleTimes.Value > 0)
                        numMultipleTimes.Value--;

                    if (rdbMultipleTimes.Checked && numMultipleTimes.Value == 0)
                        Stop();


                    //else, run in loop
                    idx = 0;
                    listBox1.SelectedIndex = 0;
                }


                ////Count total time
                //lblTimeCount.Text = "Time:" + Environment.NewLine + $"From current event: { CountTime(listBox1.SelectedIndex) }";
                //lblTimeCount.Text += Environment.NewLine + $"Total: { CountTime() }";
            }
            catch (Exception ex)
            {
                Stop();
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// for example - input: Pause (300) output: "300"
        /// </summary>
        /// <param name="a">"Pause (300)"</param>
        /// <returns>"300"</returns>
        private static string GetValueBetweenBraces(string a)
        {
            a = a.TrimStart('(');
            a = a.TrimEnd('\n');
            a = a.TrimEnd('\r');
            a = a.TrimEnd(')');
            return a;
        }

        private void MouseClicks_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            blRecordTimeCounter.Text = "";
            lblPauseTimeCounter.Text = "";
            lblTimeCount.Text = "";


            tmrEvents = new System.Windows.Forms.Timer { Interval = timerInterval };
            tmrEvents.Tick += TmrEvents_Tick;

            tmrRecord = new System.Windows.Forms.Timer { Interval = timerInterval };
            tmrRecord.Tick += TmrRecord_Tick;


            //Thread trd = new Thread(TrackMouse);
            //trd.Start();
        }


        private void TrackMouse()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                while (true)
                {
                    //label2.Text = $"{Cursor.Position.X},{Cursor.Position.Y}";
                }
            }));
        }

        public void RunScript()
        {
            Start();
        }

        public void HotKeyPressed()
        {
            if (ScriptRunning)
            {
                //stop script running
                Stop();
            }
            else if (subform_isOpen)
            {
                subform.PointPosition = $"({Cursor.Position.X},{Cursor.Position.Y})";
            }
            else
            {
                // write leftclick on the listbox
                AddEventLeftClick();
                RecordPause = true;
            }
        }

        #region Events Handlers

        private void btnAddRightClick_Click(object sender, EventArgs e)
        {
            if (true)
                AddEventRightClick();
            else
            {
                //update line
                string item = $"{listBox1.SelectedItem}";
                if (item.StartsWith(MouseEvents.LeftClick.ToString()) || item.StartsWith(MouseEvents.DoubleClick.ToString()))
                {
                    int indexer = listBox1.SelectedIndex;
                    UpdateLine(MouseEvents.RightClick.ToString() + item.Substring(item.IndexOf(' ')));
                    listBox1.SelectedIndex = indexer;
                }
            }
        }

        private void btnAddLeftClick_Click(object sender, EventArgs e)
        {

            if (true)
                AddEventLeftClick();
            else
            {
                //update line            
                string item = $"{listBox1.SelectedItem}";
                if (item.StartsWith(MouseEvents.RightClick.ToString()) || item.StartsWith(MouseEvents.DoubleClick.ToString()))
                {
                    int indexer = listBox1.SelectedIndex;
                    UpdateLine(MouseEvents.LeftClick.ToString() + item.Substring(item.IndexOf(' ')));
                    listBox1.SelectedIndex = indexer;
                }
            }
        }

        private void btnAddDoubleClick_Click(object sender, EventArgs e)
        {
            if (true)
                AddEventDoubleClick();
            else
            {
                string item = $"{listBox1.SelectedItem}";
                if (item.StartsWith(MouseEvents.LeftClick.ToString()) || item.StartsWith(MouseEvents.RightClick.ToString()))
                {
                    int indexer = listBox1.SelectedIndex;
                    UpdateLine(MouseEvents.DoubleClick.ToString() + item.Substring(item.IndexOf(' ')));
                    listBox1.SelectedIndex = indexer;
                }
            }
        }

        private void buttonSetClipboardText_Click(object sender, EventArgs e)
        {
            Forms.GetText getText = new Forms.GetText();
            if (getText.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(SetClipboardText + " " + getText.Text);
            }
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(PasteText);
        }

        private void btnAddPause_Click(object sender, EventArgs e)
        {
            AddEventPause();
        }

        private void btnDeleteSelectedItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                idx--;
                if (listBox1.Items.Count > 0)
                {
                    if (idx >= 0)
                        listBox1.SelectedIndex = idx;
                    else
                        listBox1.SelectedIndex = 0;
                }
            }
        }

        private void btnListUp_Click(object sender, EventArgs e) { MoveItem(Direction.Up); }

        private void btnListDown_Click(object sender, EventArgs e) { MoveItem(Direction.Down); }

        private void btnPlay_Click(object sender, EventArgs e) { Start(); }

        private void btnStop_Click(object sender, EventArgs e) { Stop(); }

        private void TmrEvents_Tick(object sender, EventArgs e)
        {
            if (pauseCounter > 0)
            {
                pauseCounter -= 100;
                lblPauseTimeCounter.Text = $"{pauseCounter}";

                //Count total time
                lblTimeCount.Text = "Time:\n";
                lblTimeCount.Text += "Current:\t " + $"{pauseCounter}";
                lblTimeCount.Text += Environment.NewLine + "Time Left:\t " + $"{ CountTime(listBox1.SelectedIndex) } ms";
                lblTimeCount.Text += Environment.NewLine + "Total:\t " + $"{ CountTime() } ms";
            }
            else
            {
                RunListboxCommand();
            }
        }

        private void btnUpdateLine_Click(object sender, EventArgs e)
        {
            UpdateLine(txtAction.Text + " " + txtComment.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //enable 'Click Type' buttons
                string str = $"{listBox1.SelectedItem}";
                bool clickTypeEnabled = str.StartsWith(MouseEvents.RightClick.ToString()) || str.StartsWith(MouseEvents.LeftClick.ToString()) || str.StartsWith(MouseEvents.DoubleClick.ToString());

                //groupBoxClickType.Enabled = clickTypeEnabled;
                //btnAddDoubleClick.Enabled = clickTypeEnabled;
                //btnAddRightClick.Enabled = clickTypeEnabled;
                //btnAddLeftClick.Enabled = clickTypeEnabled;




                if (str.Length == 0)
                    return;

                ////   1ST VERSION:
                string[] ar = str.Split(' ');
                txtAction.Text = ar[0] + " " + ar[1];


                ////   2ND VERSION
                ////update selected index
                //idx = listBox1.SelectedIndex;

                //string[] ar = str.TrimStart().Split(' ');
                //textBox1.Text = ar[0];

                //// trim double spaces to single space
                //for (int i = 1; i < ar.Length - 1; i++)
                //{
                //    if (ar[i].Length == 0)
                //        continue;
                //    textBox1.Text += " " + ar[i];
                //    break;//from here to the end it's comment, so break the loop
                //}



                // fill comment textbox
                if (str.Length > txtAction.Text.Length)
                    txtComment.Text = str.Substring(txtAction.Text.Length + 1);
                else
                    txtComment.Clear();


                if (!ScriptRunning)
                    idx = listBox1.SelectedIndex;

                //Count total time
                //lblTimeCount.Text = "Time:" + Environment.NewLine + $"From current event: { CountTime(listBox1.SelectedIndex) } ms";
                //lblTimeCount.Text += Environment.NewLine + $"Total: { CountTime() } sec";
                lblTimeCount.Text = "Time:\n";
                lblTimeCount.Text += "Current:\t " + $"{pauseCounter}";
                lblTimeCount.Text += Environment.NewLine + "Time Left:\t " + $"{ CountTime(listBox1.SelectedIndex) } ms";
                lblTimeCount.Text += Environment.NewLine + "Total:\t " + $"{ CountTime() } ms";
            }
            catch (Exception ex) { }
        }

        private void btnRunSelected_Click(object sender, EventArgs e)
        {
            RunListboxCommand();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GoToPoint();
        }

        private void goToCursorLocationdoubleClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToPoint();
        }

        private void txtComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                UpdateLine(txtAction.Text + " " + txtComment.Text);
                listBox1.SelectedIndex = idx >= 0 ? idx : 0;
                //SelectedLineIndex >= 0 ? SelectedLineIndex : 0;
            }
            if (e.KeyChar == (Char)Keys.Escape)
            {
                if (txtComment.SelectedText.Length == txtComment.Text.Length)
                    listBox1.Focus();
                else
                    txtComment.SelectAll();
            }

        }

        private void txtAction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Shift && e.KeyCode == Keys.F5)
            {
                Stop();
            }

            if (e.KeyCode == Keys.F5)
            {
                Start();
            }

            if (e.KeyData == (Keys.Control | Keys.S))
            {

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //SelectedLineIndex 
            idx = listBox1.SelectedIndex;
            toolStripStatusLabel1.Text = "press Enter to update selected line";
        }

        private void btnGotoNextLine_Click(object sender, EventArgs e)
        {
            Stop();
            Start();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Shift && e.KeyCode == Keys.F5)
            {
                Stop();
            }

            if (e.KeyCode == Keys.F5)
            {
                Start();
            }

            if (e.KeyCode == Keys.Delete)
            {
                btnDeleteSelectedItem_Click(sender, e);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (chkRecord.Checked)
            {
                chkRecord.BackColor = Color.Yellow;

                //disable buttons
                btnPlay.Enabled = false;
                btnStop.Enabled = false;
                btnGotoNextLine.Enabled = false;
                btnRunSelected.Enabled = false;

                RecordPause = false;
                chkRecord.Text = "Pause Recording";
                tmrRecord.Start();
            }
            else
            {
                tmrRecord.Stop();
                chkRecord.BackColor = Color.LightGray;
                recordCounter = 0;

                //enable buttons
                btnPlay.Enabled = true;
                btnStop.Enabled = true;
                btnGotoNextLine.Enabled = true;
                btnRunSelected.Enabled = true;
                chkRecord.Text = "Record";
            }
        }

        private void TmrRecord_Tick(object sender, EventArgs e)
        {
            recordCounter += timerInterval;
            blRecordTimeCounter.Text = $"{recordCounter}";
            if (RecordPause)
            {
                AddEventPause(recordCounter);
                recordCounter = 0;
            }
            RecordPause = false;
        }



        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                listBox1.Items[idx] = CommentChar + listBox1.Items[idx].ToString();
        }

        private void uncommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                listBox1.Items[idx] = listBox1.Items[idx].ToString().TrimStart(new char[] { CommentChar });
        }


        bool subform_isOpen = false;
        SubForm1 subform = new SubForm1();

        /// <summary>Open SubForm()</summary>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;

            string item = $"{listBox1.SelectedItem}";
            string[] ar_comment = item.Split(')');

            string clickType = item.Split(' ')[0];
            string pointPosition = item.Split(' ').Length > 0 ? item.Split(' ')[1] : "";

            subform = new SubForm1
            {
                ClickType = clickType,
                Comment = ar_comment.Length > 1 ? ar_comment[1] : "",
                PointPosition = pointPosition,
                StartPosition = FormStartPosition.CenterParent
            };

            subform_isOpen = true;
            if (subform.ShowDialog() == DialogResult.OK)
            {
                subform_isOpen = false;
                UpdateLine(subform.PointPosition);
            }
        }

        private void contextMenuListbox_Opening(object sender, CancelEventArgs e)
        {
            runSelectedToolStripMenuItem.Enabled = listBox1.SelectedIndex >= 0;
            editToolStripMenuItem.Enabled = listBox1.SelectedIndex >= 0;
            commentToolStripMenuItem.Enabled = listBox1.SelectedIndex >= 0;
            uncommentToolStripMenuItem.Enabled = listBox1.SelectedIndex >= 0;
            goToCursorLocationdoubleClickToolStripMenuItem.Enabled =
                (listBox1.SelectedIndex >= 0 && (listBox1.SelectedItem.ToString().StartsWith("LeftClick")
                || listBox1.SelectedItem.ToString().StartsWith("RightClick")
                || listBox1.SelectedItem.ToString().StartsWith("DoubleClick")));
        }


        #region toolStripStatusLabel1

        private void btnAddLeftClick_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hotkey: Ctrl+Q";
        }

        private void btnAddLeftClick_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        #endregion



        #endregion

        private void AddEventRightClick()
        {
            listBox1.Items.Add($"RightClick ({Cursor.Position.X},{Cursor.Position.Y}) {txtComment.Text}");
            btnAddPause.Focus();
        }

        public void AddEventLeftClick()
        {
            listBox1.Items.Add($"LeftClick ({Cursor.Position.X},{Cursor.Position.Y}) {txtComment.Text}");
            btnAddPause.Focus();
        }

        private void AddEventDoubleClick()
        {
            listBox1.Items.Add($"DoubleClick ({Cursor.Position.X},{Cursor.Position.Y}) {txtComment.Text}");
            btnAddPause.Focus();
        }

        private void AddEventPause()
        {
            listBox1.Items.Add($"Pause ({num_ms.Value})");
            btnAddLeftClick.Focus();
        }

        private void AddEventPause(decimal val)
        {
            listBox1.Items.Add($"Pause ({val})");
            btnAddLeftClick.Focus();
        }

        /// <summary>
        /// Move items in the listbox
        /// </summary>
        /// <param name="dir">up or down</param>
        private void MoveItem(Direction dir)
        {
            int direction = (int)dir;

            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return;

            int newIndex = listBox1.SelectedIndex + direction;

            if (newIndex < 0 || newIndex >= listBox1.Items.Count + 1)
                return;

            object selected = listBox1.SelectedItem;

            //remove removable element
            listBox1.Items.Remove(selected);
            // insert it in the new position
            listBox1.Items.Insert(newIndex, selected);
            //restore selection
            listBox1.SetSelected(newIndex, true);
        }


        //public delegate void MinimizeOnStart(bool m);
        public event Action<bool> minimizeOnStart_event;
        /// <summary>
        /// Minimize form on start of script
        /// </summary>
        public virtual void OnMinimize(bool b) { minimizeOnStart_event(b); }

        private void Start()
        {
            OnMinimize(chkMinimize.Checked);

            if (listBox1.Items.Count == 0)
                return;
            if (listBox1.SelectedIndex < 0)
                listBox1.SelectedIndex = 0;
            Stop();
            tmrEvents.Start();
            ScriptRunning = true;
            btnPlay.Enabled = false;
            btnStop.Enabled = true;
        }

        private void Stop()
        {
            tmrEvents.Stop();
            ScriptRunning = false;
            pauseCounter = 0;
            btnStop.Enabled = false;
            btnPlay.Enabled = true;
        }

        private void UpdateLine(string value)
        {
            int indexer = listBox1.SelectedIndex;
            listBox1.Items.Insert(indexer, value);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            //listBox1.SelectedIndex = indexer;
        }

        /// <summary>
        /// Count time of list
        /// </summary>
        /// <param name="startIndex">count starting from item's index</param>
        /// <returns>1000 sec</returns>
        private int CountTime(int startIndex = 0)
        {
            int count = 0;
            for (int i = startIndex; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().StartsWith("Pause"))
                {
                    try
                    {
                        string str = listBox1.Items[i].ToString().Split(' ')[1];
                        count += int.Parse(GetValueBetweenBraces(str));
                    }
                    catch (Exception ex)
                    { }
                }
                count += timerInterval;
            }
            //count /= 1000;

            if (startIndex == 0)
                return count;
            count = count + pauseCounter;
            return count;// * 1000;
        }

        private void GoToPoint()
        {
            if (listBox1.SelectedIndex < 0)
                return;

            //select textbox
            txtAction.Focus();
            txtAction.SelectAll();

            string item = $"{listBox1.SelectedItem}";
            if (item.StartsWith("Pause"))
            {
                return;
            }

            string[] ar = item.Split(new string[] { " ", "(" }, StringSplitOptions.RemoveEmptyEntries);
            string pos = ar[1].TrimStart('(').TrimEnd(')');
            Point pnt = new Point(int.Parse(pos.Split(',')[0]), int.Parse(pos.Split(',')[1]));
            clicks.MoveMouse(pnt);
        }

        public void ClearListbox()
        {
            listBox1.Items.Clear();
        }

        private string print(string num)
        {
            string str = num[0].ToString();
            if (num.Length == 1) str += "\n";
            else
            {
                if ((num.Length - 1) % 3 == 0)
                    str += ",";
                print(num.Substring(1));
            }
            return str;
        }

        private void buttonTypeText_Click(object sender, EventArgs e)
        {
            //Forms.GetText getText = new Forms.GetText();
            //if (getText.ShowDialog() == DialogResult.OK)
            //{
            //    listBox1.Items.Add(TypeText + " " + getText.Text);
            //}
        }
    }
}
