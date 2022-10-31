namespace SimulateMouseClick
{
    partial class MouseClicks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseClicks));
            this.btnAddRightClick = new System.Windows.Forms.Button();
            this.btnAddLeftClick = new System.Windows.Forms.Button();
            this.btnAddDoubleClick = new System.Windows.Forms.Button();
            this.btnAddPause = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuListbox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToCursorLocationdoubleClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteSelectedItem = new System.Windows.Forms.Button();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.btnListUp = new System.Windows.Forms.Button();
            this.btnListDown = new System.Windows.Forms.Button();
            this.num_ms = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.chkReturnToUserPos = new System.Windows.Forms.CheckBox();
            this.btnUpdateLine = new System.Windows.Forms.Button();
            this.btnRunSelected = new System.Windows.Forms.Button();
            this.rdbMultipleTimes = new System.Windows.Forms.RadioButton();
            this.rdbLoop = new System.Windows.Forms.RadioButton();
            this.rdbOneTime = new System.Windows.Forms.RadioButton();
            this.numMultipleTimes = new System.Windows.Forms.NumericUpDown();
            this.btnGotoNextLine = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxClickType = new System.Windows.Forms.GroupBox();
            this.chkRecord = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.blRecordTimeCounter = new System.Windows.Forms.Label();
            this.lblPauseTimeCounter = new System.Windows.Forms.Label();
            this.chkMinimize = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.buttonSetClipboardText = new System.Windows.Forms.Button();
            this.lblTimeCount = new System.Windows.Forms.Label();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonTypeText = new System.Windows.Forms.Button();
            this.contextMenuListbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_ms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMultipleTimes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRightClick
            // 
            this.btnAddRightClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRightClick.Location = new System.Drawing.Point(394, 90);
            this.btnAddRightClick.Name = "btnAddRightClick";
            this.btnAddRightClick.Size = new System.Drawing.Size(55, 23);
            this.btnAddRightClick.TabIndex = 2;
            this.btnAddRightClick.Text = "&Right";
            this.toolTip1.SetToolTip(this.btnAddRightClick, "Add RightClick event to the list");
            this.btnAddRightClick.UseVisualStyleBackColor = true;
            this.btnAddRightClick.Click += new System.EventHandler(this.btnAddRightClick_Click);
            // 
            // btnAddLeftClick
            // 
            this.btnAddLeftClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLeftClick.Location = new System.Drawing.Point(468, 90);
            this.btnAddLeftClick.Name = "btnAddLeftClick";
            this.btnAddLeftClick.Size = new System.Drawing.Size(55, 23);
            this.btnAddLeftClick.TabIndex = 1;
            this.btnAddLeftClick.Tag = "";
            this.btnAddLeftClick.Text = "&Left";
            this.toolTip1.SetToolTip(this.btnAddLeftClick, "Add LeftClick event to the list");
            this.btnAddLeftClick.UseVisualStyleBackColor = true;
            this.btnAddLeftClick.Click += new System.EventHandler(this.btnAddLeftClick_Click);
            this.btnAddLeftClick.MouseEnter += new System.EventHandler(this.btnAddLeftClick_MouseEnter);
            this.btnAddLeftClick.MouseLeave += new System.EventHandler(this.btnAddLeftClick_MouseLeave);
            // 
            // btnAddDoubleClick
            // 
            this.btnAddDoubleClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDoubleClick.Location = new System.Drawing.Point(394, 119);
            this.btnAddDoubleClick.Name = "btnAddDoubleClick";
            this.btnAddDoubleClick.Size = new System.Drawing.Size(129, 23);
            this.btnAddDoubleClick.TabIndex = 2;
            this.btnAddDoubleClick.Text = "Double Click";
            this.toolTip1.SetToolTip(this.btnAddDoubleClick, "Add DoubleClick event to the list");
            this.btnAddDoubleClick.UseVisualStyleBackColor = true;
            this.btnAddDoubleClick.Click += new System.EventHandler(this.btnAddDoubleClick_Click);
            // 
            // btnAddPause
            // 
            this.btnAddPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPause.Location = new System.Drawing.Point(387, 239);
            this.btnAddPause.Name = "btnAddPause";
            this.btnAddPause.Size = new System.Drawing.Size(68, 23);
            this.btnAddPause.TabIndex = 3;
            this.btnAddPause.Text = "Add Pause";
            this.toolTip1.SetToolTip(this.btnAddPause, "ADdd pause event to the list");
            this.btnAddPause.UseVisualStyleBackColor = true;
            this.btnAddPause.Click += new System.EventHandler(this.btnAddPause_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.ContextMenuStrip = this.contextMenuListbox;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(378, 355);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // contextMenuListbox
            // 
            this.contextMenuListbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runSelectedToolStripMenuItem,
            this.goToCursorLocationdoubleClickToolStripMenuItem,
            this.editToolStripMenuItem,
            this.commentToolStripMenuItem,
            this.uncommentToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
            this.contextMenuListbox.Name = "contextMenuListbox";
            this.contextMenuListbox.Size = new System.Drawing.Size(266, 136);
            this.contextMenuListbox.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuListbox_Opening);
            // 
            // runSelectedToolStripMenuItem
            // 
            this.runSelectedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runSelectedToolStripMenuItem.Image")));
            this.runSelectedToolStripMenuItem.Name = "runSelectedToolStripMenuItem";
            this.runSelectedToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.runSelectedToolStripMenuItem.Text = "&Run Selected";
            this.runSelectedToolStripMenuItem.Click += new System.EventHandler(this.btnRunSelected_Click);
            // 
            // goToCursorLocationdoubleClickToolStripMenuItem
            // 
            this.goToCursorLocationdoubleClickToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("goToCursorLocationdoubleClickToolStripMenuItem.Image")));
            this.goToCursorLocationdoubleClickToolStripMenuItem.Name = "goToCursorLocationdoubleClickToolStripMenuItem";
            this.goToCursorLocationdoubleClickToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.goToCursorLocationdoubleClickToolStripMenuItem.Text = "&Go to Cursor Location (double click)";
            this.goToCursorLocationdoubleClickToolStripMenuItem.Click += new System.EventHandler(this.goToCursorLocationdoubleClickToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.editToolStripMenuItem.Text = "&Edit / Update";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // commentToolStripMenuItem
            // 
            this.commentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("commentToolStripMenuItem.Image")));
            this.commentToolStripMenuItem.Name = "commentToolStripMenuItem";
            this.commentToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.commentToolStripMenuItem.Text = "&Comment";
            this.commentToolStripMenuItem.Click += new System.EventHandler(this.commentToolStripMenuItem_Click);
            // 
            // uncommentToolStripMenuItem
            // 
            this.uncommentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uncommentToolStripMenuItem.Image")));
            this.uncommentToolStripMenuItem.Name = "uncommentToolStripMenuItem";
            this.uncommentToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.uncommentToolStripMenuItem.Text = "&Uncomment";
            this.uncommentToolStripMenuItem.Click += new System.EventHandler(this.uncommentToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remo&ve Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.btnDeleteSelectedItem_Click);
            // 
            // btnDeleteSelectedItem
            // 
            this.btnDeleteSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelectedItem.Location = new System.Drawing.Point(288, 433);
            this.btnDeleteSelectedItem.Name = "btnDeleteSelectedItem";
            this.btnDeleteSelectedItem.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteSelectedItem.TabIndex = 10;
            this.btnDeleteSelectedItem.Text = "Remove Line";
            this.toolTip1.SetToolTip(this.btnDeleteSelectedItem, "Remove line  from the list");
            this.btnDeleteSelectedItem.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedItem.Click += new System.EventHandler(this.btnDeleteSelectedItem_Click);
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(4, 51);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(113, 20);
            this.txtAction.TabIndex = 4;
            this.txtAction.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtAction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAction_KeyDown);
            this.txtAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComment_KeyPress);
            this.txtAction.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // btnListUp
            // 
            this.btnListUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListUp.Location = new System.Drawing.Point(3, 433);
            this.btnListUp.Name = "btnListUp";
            this.btnListUp.Size = new System.Drawing.Size(50, 23);
            this.btnListUp.TabIndex = 8;
            this.btnListUp.Text = "Up";
            this.btnListUp.UseVisualStyleBackColor = true;
            this.btnListUp.Click += new System.EventHandler(this.btnListUp_Click);
            // 
            // btnListDown
            // 
            this.btnListDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListDown.Location = new System.Drawing.Point(59, 433);
            this.btnListDown.Name = "btnListDown";
            this.btnListDown.Size = new System.Drawing.Size(50, 23);
            this.btnListDown.TabIndex = 9;
            this.btnListDown.Text = "Down";
            this.btnListDown.UseVisualStyleBackColor = true;
            this.btnListDown.Click += new System.EventHandler(this.btnListDown_Click);
            // 
            // num_ms
            // 
            this.num_ms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_ms.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_ms.Location = new System.Drawing.Point(460, 240);
            this.num_ms.Maximum = new decimal(new int[] {
            90000000,
            0,
            0,
            0});
            this.num_ms.Name = "num_ms";
            this.num_ms.Size = new System.Drawing.Size(52, 20);
            this.num_ms.TabIndex = 4;
            this.toolTip1.SetToolTip(this.num_ms, "Pause length");
            this.num_ms.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ms.";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(175, 51);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(142, 20);
            this.txtComment.TabIndex = 5;
            this.txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.txtComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComment_KeyPress);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(123, 54);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(54, 13);
            this.lblComment.TabIndex = 10;
            this.lblComment.Text = "Comment:";
            // 
            // chkReturnToUserPos
            // 
            this.chkReturnToUserPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReturnToUserPos.Location = new System.Drawing.Point(391, 274);
            this.chkReturnToUserPos.Name = "chkReturnToUserPos";
            this.chkReturnToUserPos.Size = new System.Drawing.Size(132, 32);
            this.chkReturnToUserPos.TabIndex = 18;
            this.chkReturnToUserPos.Text = "Cursor to user position";
            this.chkReturnToUserPos.UseVisualStyleBackColor = true;
            this.chkReturnToUserPos.Visible = false;
            // 
            // btnUpdateLine
            // 
            this.btnUpdateLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateLine.Location = new System.Drawing.Point(320, 49);
            this.btnUpdateLine.Name = "btnUpdateLine";
            this.btnUpdateLine.Size = new System.Drawing.Size(62, 23);
            this.btnUpdateLine.TabIndex = 6;
            this.btnUpdateLine.Text = "Update";
            this.btnUpdateLine.UseVisualStyleBackColor = true;
            this.btnUpdateLine.Click += new System.EventHandler(this.btnUpdateLine_Click);
            // 
            // btnRunSelected
            // 
            this.btnRunSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunSelected.Location = new System.Drawing.Point(236, 23);
            this.btnRunSelected.Name = "btnRunSelected";
            this.btnRunSelected.Size = new System.Drawing.Size(81, 23);
            this.btnRunSelected.TabIndex = 3;
            this.btnRunSelected.Text = "Run &Selected";
            this.toolTip1.SetToolTip(this.btnRunSelected, "Run selected line in list");
            this.btnRunSelected.UseVisualStyleBackColor = true;
            this.btnRunSelected.Visible = false;
            this.btnRunSelected.Click += new System.EventHandler(this.btnRunSelected_Click);
            // 
            // rdbMultipleTimes
            // 
            this.rdbMultipleTimes.AutoSize = true;
            this.rdbMultipleTimes.Location = new System.Drawing.Point(4, 57);
            this.rdbMultipleTimes.Name = "rdbMultipleTimes";
            this.rdbMultipleTimes.Size = new System.Drawing.Size(95, 17);
            this.rdbMultipleTimes.TabIndex = 16;
            this.rdbMultipleTimes.Text = "Multiple Times:";
            this.rdbMultipleTimes.UseVisualStyleBackColor = true;
            // 
            // rdbLoop
            // 
            this.rdbLoop.AutoSize = true;
            this.rdbLoop.Location = new System.Drawing.Point(4, 38);
            this.rdbLoop.Name = "rdbLoop";
            this.rdbLoop.Size = new System.Drawing.Size(49, 17);
            this.rdbLoop.TabIndex = 16;
            this.rdbLoop.Text = "Loop";
            this.rdbLoop.UseVisualStyleBackColor = true;
            // 
            // rdbOneTime
            // 
            this.rdbOneTime.AutoSize = true;
            this.rdbOneTime.Checked = true;
            this.rdbOneTime.Location = new System.Drawing.Point(4, 19);
            this.rdbOneTime.Name = "rdbOneTime";
            this.rdbOneTime.Size = new System.Drawing.Size(71, 17);
            this.rdbOneTime.TabIndex = 16;
            this.rdbOneTime.TabStop = true;
            this.rdbOneTime.Text = "One Time";
            this.rdbOneTime.UseVisualStyleBackColor = true;
            // 
            // numMultipleTimes
            // 
            this.numMultipleTimes.Location = new System.Drawing.Point(95, 57);
            this.numMultipleTimes.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numMultipleTimes.Name = "numMultipleTimes";
            this.numMultipleTimes.Size = new System.Drawing.Size(43, 20);
            this.numMultipleTimes.TabIndex = 17;
            this.numMultipleTimes.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnGotoNextLine
            // 
            this.btnGotoNextLine.Location = new System.Drawing.Point(175, 23);
            this.btnGotoNextLine.Name = "btnGotoNextLine";
            this.btnGotoNextLine.Size = new System.Drawing.Size(55, 23);
            this.btnGotoNextLine.TabIndex = 2;
            this.btnGotoNextLine.Text = "&Next";
            this.toolTip1.SetToolTip(this.btnGotoNextLine, "Go to next line in list");
            this.btnGotoNextLine.UseVisualStyleBackColor = true;
            this.btnGotoNextLine.Click += new System.EventHandler(this.btnGotoNextLine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numMultipleTimes);
            this.groupBox1.Controls.Add(this.rdbMultipleTimes);
            this.groupBox1.Controls.Add(this.rdbLoop);
            this.groupBox1.Controls.Add(this.rdbOneTime);
            this.groupBox1.Location = new System.Drawing.Point(387, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 87);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run";
            // 
            // groupBoxClickType
            // 
            this.groupBoxClickType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClickType.Location = new System.Drawing.Point(387, 72);
            this.groupBoxClickType.Name = "groupBoxClickType";
            this.groupBoxClickType.Size = new System.Drawing.Size(142, 167);
            this.groupBoxClickType.TabIndex = 21;
            this.groupBoxClickType.TabStop = false;
            this.groupBoxClickType.Text = "Add Event";
            // 
            // chkRecord
            // 
            this.chkRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRecord.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRecord.Image = ((System.Drawing.Image)(resources.GetObject("chkRecord.Image")));
            this.chkRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecord.Location = new System.Drawing.Point(398, 9);
            this.chkRecord.Name = "chkRecord";
            this.chkRecord.Size = new System.Drawing.Size(131, 24);
            this.chkRecord.TabIndex = 22;
            this.chkRecord.Text = "Record";
            this.toolTip1.SetToolTip(this.chkRecord, "Start recording script. \r\nPress ctrl+Q to add LeftClick to the list.\r\nYou can cha" +
        "nge the event type after recording.");
            this.chkRecord.UseVisualStyleBackColor = true;
            this.chkRecord.CheckedChanged += new System.EventHandler(this.btnRecord_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(532, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // blRecordTimeCounter
            // 
            this.blRecordTimeCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blRecordTimeCounter.AutoSize = true;
            this.blRecordTimeCounter.Location = new System.Drawing.Point(402, 36);
            this.blRecordTimeCounter.Name = "blRecordTimeCounter";
            this.blRecordTimeCounter.Size = new System.Drawing.Size(110, 13);
            this.blRecordTimeCounter.TabIndex = 24;
            this.blRecordTimeCounter.Text = "blRecordTimeCounter";
            // 
            // lblPauseTimeCounter
            // 
            this.lblPauseTimeCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPauseTimeCounter.AutoSize = true;
            this.lblPauseTimeCounter.Location = new System.Drawing.Point(123, 438);
            this.lblPauseTimeCounter.Name = "lblPauseTimeCounter";
            this.lblPauseTimeCounter.Size = new System.Drawing.Size(107, 13);
            this.lblPauseTimeCounter.TabIndex = 24;
            this.lblPauseTimeCounter.Text = "lblPauseTimeCounter";
            // 
            // chkMinimize
            // 
            this.chkMinimize.AutoSize = true;
            this.chkMinimize.Location = new System.Drawing.Point(4, 3);
            this.chkMinimize.Name = "chkMinimize";
            this.chkMinimize.Size = new System.Drawing.Size(108, 17);
            this.chkMinimize.TabIndex = 25;
            this.chkMinimize.Text = "Minimize On Start";
            this.chkMinimize.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(61, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "S&top";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnStop, "Stop Script\r\nCtrl+Q");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(4, 23);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(56, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "&Start (F5)";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnPlay, "Start script.\r\nStop it by pressing Ctrl+Q.");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // buttonSetClipboardText
            // 
            this.buttonSetClipboardText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetClipboardText.Location = new System.Drawing.Point(394, 148);
            this.buttonSetClipboardText.Name = "buttonSetClipboardText";
            this.buttonSetClipboardText.Size = new System.Drawing.Size(129, 23);
            this.buttonSetClipboardText.TabIndex = 26;
            this.buttonSetClipboardText.Text = "SetClipboardText";
            this.toolTip1.SetToolTip(this.buttonSetClipboardText, "Put text in the clipboard");
            this.buttonSetClipboardText.UseVisualStyleBackColor = true;
            this.buttonSetClipboardText.Click += new System.EventHandler(this.buttonSetClipboardText_Click);
            // 
            // lblTimeCount
            // 
            this.lblTimeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeCount.Location = new System.Drawing.Point(387, 387);
            this.lblTimeCount.Name = "lblTimeCount";
            this.lblTimeCount.Size = new System.Drawing.Size(138, 69);
            this.lblTimeCount.TabIndex = 24;
            this.lblTimeCount.Text = "lblTimeCount";
            this.lblTimeCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // buttonPaste
            // 
            this.buttonPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPaste.Location = new System.Drawing.Point(394, 177);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(129, 23);
            this.buttonPaste.TabIndex = 26;
            this.buttonPaste.Text = "Paste";
            this.toolTip1.SetToolTip(this.buttonPaste, "Run event: Paste from clipboard");
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // buttonTypeText
            // 
            this.buttonTypeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTypeText.Enabled = false;
            this.buttonTypeText.Location = new System.Drawing.Point(394, 206);
            this.buttonTypeText.Name = "buttonTypeText";
            this.buttonTypeText.Size = new System.Drawing.Size(129, 23);
            this.buttonTypeText.TabIndex = 26;
            this.buttonTypeText.Text = "Type Text";
            this.toolTip1.SetToolTip(this.buttonTypeText, "Type text with delays between keystrokes");
            this.buttonTypeText.UseVisualStyleBackColor = true;
            this.buttonTypeText.Click += new System.EventHandler(this.buttonTypeText_Click);
            // 
            // MouseClicks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkRecord);
            this.Controls.Add(this.buttonTypeText);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.buttonSetClipboardText);
            this.Controls.Add(this.chkMinimize);
            this.Controls.Add(this.lblTimeCount);
            this.Controls.Add(this.lblPauseTimeCounter);
            this.Controls.Add(this.blRecordTimeCounter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGotoNextLine);
            this.Controls.Add(this.btnRunSelected);
            this.Controls.Add(this.btnAddRightClick);
            this.Controls.Add(this.btnAddLeftClick);
            this.Controls.Add(this.btnAddDoubleClick);
            this.Controls.Add(this.btnAddPause);
            this.Controls.Add(this.num_ms);
            this.Controls.Add(this.btnUpdateLine);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtAction);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnListDown);
            this.Controls.Add(this.btnListUp);
            this.Controls.Add(this.btnDeleteSelectedItem);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.groupBoxClickType);
            this.Controls.Add(this.chkReturnToUserPos);
            this.Controls.Add(this.label4);
            this.Name = "MouseClicks";
            this.Size = new System.Drawing.Size(532, 481);
            this.Load += new System.EventHandler(this.MouseClicks_Load);
            this.contextMenuListbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_ms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMultipleTimes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRightClick;
        private System.Windows.Forms.Button btnAddLeftClick;
        private System.Windows.Forms.Button btnAddDoubleClick;
        private System.Windows.Forms.Button btnAddPause;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDeleteSelectedItem;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Button btnListUp;
        private System.Windows.Forms.Button btnListDown;
        private System.Windows.Forms.NumericUpDown num_ms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnUpdateLine;
        private System.Windows.Forms.Button btnRunSelected;
        private System.Windows.Forms.RadioButton rdbMultipleTimes;
        private System.Windows.Forms.RadioButton rdbLoop;
        private System.Windows.Forms.RadioButton rdbOneTime;
        private System.Windows.Forms.NumericUpDown numMultipleTimes;
        private System.Windows.Forms.ContextMenuStrip contextMenuListbox;
        private System.Windows.Forms.ToolStripMenuItem goToCursorLocationdoubleClickToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkReturnToUserPos;
        private System.Windows.Forms.Button btnGotoNextLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxClickType;
        private System.Windows.Forms.CheckBox chkRecord;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label blRecordTimeCounter;
        private System.Windows.Forms.Label lblPauseTimeCounter;
        private System.Windows.Forms.ToolStripMenuItem commentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkMinimize;
        private System.Windows.Forms.Button buttonSetClipboardText;
        private System.Windows.Forms.Label lblTimeCount;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.Button buttonTypeText;
    }
}
