namespace TETRIX
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.难度CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.简单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一般ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.困难ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最高记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.previewArea = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerDown = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.nameInput = new System.Windows.Forms.TextBox();
            this.inPutOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 390);
            this.label1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.帮助HToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem,
            this.退出EToolStripMenuItem1});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出EToolStripMenuItem.Text = "开始/结束(&S)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.开始EToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem1
            // 
            this.退出EToolStripMenuItem1.Name = "退出EToolStripMenuItem1";
            this.退出EToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.退出EToolStripMenuItem1.Text = "退出(&E)";
            this.退出EToolStripMenuItem1.Click += new System.EventHandler(this.退出EToolStripMenuItem1_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.难度CToolStripMenuItem,
            this.暂停PToolStripMenuItem,
            this.最高记录ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.帮助HToolStripMenuItem.Text = "选项(&C)";
            // 
            // 难度CToolStripMenuItem
            // 
            this.难度CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.简单ToolStripMenuItem,
            this.一般ToolStripMenuItem,
            this.困难ToolStripMenuItem});
            this.难度CToolStripMenuItem.Name = "难度CToolStripMenuItem";
            this.难度CToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.难度CToolStripMenuItem.Text = "难度(&C)";
            // 
            // 简单ToolStripMenuItem
            // 
            this.简单ToolStripMenuItem.Name = "简单ToolStripMenuItem";
            this.简单ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.简单ToolStripMenuItem.Text = "简单";
            this.简单ToolStripMenuItem.Click += new System.EventHandler(this.简单ToolStripMenuItem_Click);
            // 
            // 一般ToolStripMenuItem
            // 
            this.一般ToolStripMenuItem.Name = "一般ToolStripMenuItem";
            this.一般ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.一般ToolStripMenuItem.Text = "一般";
            this.一般ToolStripMenuItem.Click += new System.EventHandler(this.一般ToolStripMenuItem_Click);
            // 
            // 困难ToolStripMenuItem
            // 
            this.困难ToolStripMenuItem.Name = "困难ToolStripMenuItem";
            this.困难ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.困难ToolStripMenuItem.Text = "困难";
            this.困难ToolStripMenuItem.Click += new System.EventHandler(this.困难ToolStripMenuItem_Click);
            // 
            // 暂停PToolStripMenuItem
            // 
            this.暂停PToolStripMenuItem.Enabled = false;
            this.暂停PToolStripMenuItem.Name = "暂停PToolStripMenuItem";
            this.暂停PToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.暂停PToolStripMenuItem.Text = "暂停/继续(&P)";
            this.暂停PToolStripMenuItem.Click += new System.EventHandler(this.暂停PToolStripMenuItem1_Click);
            // 
            // 最高记录ToolStripMenuItem
            // 
            this.最高记录ToolStripMenuItem.Name = "最高记录ToolStripMenuItem";
            this.最高记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.最高记录ToolStripMenuItem.Text = "最高记录";
            this.最高记录ToolStripMenuItem.Click += new System.EventHandler(this.最高记录ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem1
            // 
            this.帮助HToolStripMenuItem1.Name = "帮助HToolStripMenuItem1";
            this.帮助HToolStripMenuItem1.Size = new System.Drawing.Size(58, 20);
            this.帮助HToolStripMenuItem1.Text = "帮助(&H)";
            this.帮助HToolStripMenuItem1.Click += new System.EventHandler(this.帮助HToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(555, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "作者：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel2.Text = "段聪";
            // 
            // previewArea
            // 
            this.previewArea.BackColor = System.Drawing.Color.Blue;
            this.previewArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewArea.Location = new System.Drawing.Point(6, 22);
            this.previewArea.Name = "previewArea";
            this.previewArea.Size = new System.Drawing.Size(150, 150);
            this.previewArea.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "当前得分：";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.ForeColor = System.Drawing.Color.Red;
            this.score.Location = new System.Drawing.Point(65, 165);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(17, 16);
            this.score.TabIndex = 6;
            this.score.Text = "0";
            this.score.TextChanged += new System.EventHandler(this.score_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 120);
            this.label2.TabIndex = 11;
            // 
            // timerDown
            // 
            this.timerDown.Interval = 1000;
            this.timerDown.Tick += new System.EventHandler(this.timerDown_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "下降速率：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(59, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "1格/1000ms";
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "C:\\Documents and Settings\\Administrator\\桌面\\TETRIX\\TETRIX\\bin\\Debug\\Vista2_color1." +
                "ssk";
            this.skinEngine1.SkinStreamMain = ((System.IO.Stream)(resources.GetObject("skinEngine1.SkinStreamMain")));
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(67, 380);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 21);
            this.nameInput.TabIndex = 18;
            this.nameInput.Visible = false;
            this.nameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameInput_KeyDown);
            // 
            // inPutOk
            // 
            this.inPutOk.Location = new System.Drawing.Point(222, 378);
            this.inPutOk.Name = "inPutOk";
            this.inPutOk.Size = new System.Drawing.Size(54, 23);
            this.inPutOk.TabIndex = 19;
            this.inPutOk.Text = "确定";
            this.inPutOk.UseVisualStyleBackColor = true;
            this.inPutOk.Visible = false;
            this.inPutOk.Click += new System.EventHandler(this.inPutOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 20;
            this.button1.Text = "清除最高纪录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.score);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(381, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 199);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.previewArea);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(381, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 180);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "方块预览";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "当前难度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(59, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "简单";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 437);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inPutOk);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "俄罗斯方块";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem1;
        private System.Windows.Forms.Label previewArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerDown;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem 难度CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 一般ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 困难ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最高记录ToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem1;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Button inPutOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        
    }
}

