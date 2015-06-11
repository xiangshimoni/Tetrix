using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;

namespace TETRIX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    disAreaState[i, j] = false;
                }
            }
        }

        #region 变量定义部分

        //方块颜色信息
        Color[] blockColor = {Color.Red,Color.Green,Color.Yellow,Color.Chocolate,
                                 Color.Black,Color.Brown,Color.HotPink};
        //方块的四种变换矩阵（最后一种和第一种开始相同）
        int[, , ,] blockShape = { 
                {
                {{0,0,0,0},{1,1,1,1},{0,0,0,0},{0,0,0,0}},//1
                {{0,1,0,0},{0,1,0,0},{0,1,1,0},{0,0,0,0}},//2
                {{0,0,1,0},{0,0,1,0},{0,1,1,0},{0,0,0,0}},//3
                {{0,0,0,0},{0,1,1,0},{0,1,1,0},{0,0,0,0}},//4
                {{0,0,1,0},{0,1,1,0},{0,1,0,0},{0,0,0,0}},//5
                {{0,1,0,0},{0,1,1,0},{0,0,1,0},{0,0,0,0}},//6
                {{0,0,0,0},{0,1,0,0},{1,1,1,0},{0,0,0,0}}},//7
                { 
                {{0,1,0,0},{0,1,0,0},{0,1,0,0},{0,1,0,0}},//1
                {{0,0,0,0},{0,1,1,1},{0,1,0,0},{0,0,0,0}},//2
                {{0,0,0,0},{0,1,0,0},{0,1,1,1},{0,0,0,0}},//3
                {{0,0,0,0},{0,1,1,0},{0,1,1,0},{0,0,0,0}},//4
                {{0,0,0,0},{0,1,1,0},{0,0,1,1},{0,0,0,0}},//5
                {{0,0,0,0},{0,1,1,0},{1,1,0,0},{0,0,0,0}},//6
                {{0,0,0,0},{0,1,0,0},{0,1,1,0},{0,1,0,0}}},//7
                { 
                {{0,0,0,0},{1,1,1,1},{0,0,0,0},{0,0,0,0}},//1
                {{0,0,0,0},{1,1,0,0},{0,1,0,0},{0,1,0,0}},//2
                {{0,0,0,0},{0,1,1,0},{0,1,0,0},{0,1,0,0}},//3
                {{0,0,0,0},{0,1,1,0},{0,1,1,0},{0,0,0,0}},//4
                {{0,0,1,0},{0,1,1,0},{0,1,0,0},{0,0,0,0}},//5
                {{0,1,0,0},{0,1,1,0},{0,0,1,0},{0,0,0,0}},//6
                {{0,0,0,0},{0,0,0,0},{1,1,1,0},{0,1,0,0}}},//7
                { 
                {{0,1,0,0},{0,1,0,0},{0,1,0,0},{0,1,0,0}},//1
                {{0,0,0,0},{0,0,1,0},{1,1,1,0},{0,0,0,0}},//2
                {{0,0,0,0},{1,1,1,0},{0,0,1,0},{0,0,0,0}},//3
                {{0,0,0,0},{0,1,1,0},{0,1,1,0},{0,0,0,0}},//4
                {{0,0,0,0},{0,1,1,0},{0,0,1,1},{0,0,0,0}},//5
                {{0,0,0,0},{0,1,1,0},{1,1,0,0},{0,0,0,0}},//6
                {{0,0,0,0},{0,1,0,0},{1,1,0,0},{0,1,0,0}}},//7
                {
                {{0,0,0,0},{1,1,1,1},{0,0,0,0},{0,0,0,0}},//1
                {{0,1,0,0},{0,1,0,0},{0,1,1,0},{0,0,0,0}},//2
                {{0,0,1,0},{0,0,1,0},{0,1,1,0},{0,0,0,0}},//3
                {{0,0,0,0},{0,1,1,0},{0,1,1,0},{0,0,0,0}},//4
                {{0,0,1,0},{0,1,1,0},{0,1,0,0},{0,0,0,0}},//5
                {{0,1,0,0},{0,1,1,0},{0,0,1,0},{0,0,0,0}},//6
                {{0,0,0,0},{0,1,0,0},{1,1,1,0},{0,0,0,0}}}};

        bool hasStarted = false;//判断是否开始了
        int presentBlock, nextBlock, tempBlock;
        int blockHeight = -60, blockWidth = 120;//初始高度和宽度
        int transformCount = 1;//变换的次数
        bool[,] disAreaState = new bool[13, 12];//游戏显示区域矩阵
        int gameScore = 0;//得分
        int nandu = 1;

        #endregion


        #region 显示与清除
        /// <summary>
        /// 在游戏区域画出方块
        /// </summary>
        void drawBlock()
        {
            Graphics gp = label1.CreateGraphics();
            Pen pen = new Pen(Color.White);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (1 == blockShape[0, presentBlock, i, j])
                    {
                        SolidBrush br = new SolidBrush(blockColor[presentBlock]);
                        gp.FillRectangle(br, blockWidth + j * 30, i * 30 + blockHeight, 30, 30);
                        gp.DrawRectangle(pen, blockWidth + j * 30, i * 30 + blockHeight, 30, 30);
                    }
                }
            }
            gp.Dispose();
        }

        /// <summary>
        /// 清除上一个方块的显示
        /// </summary>
        void clearLast()
        {
            Graphics gp = label1.CreateGraphics();
            Pen pen = new Pen(Color.Blue);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (1 == blockShape[0, presentBlock, i, j])
                    {
                        SolidBrush br = new SolidBrush(Color.Blue);
                        gp.FillRectangle(br, blockWidth + j * 30, i * 30 + blockHeight, 30, 30);
                        gp.DrawRectangle(pen, blockWidth + j * 30, i * 30 + blockHeight, 30, 30);
                    }
                }
            }
            gp.Dispose();
        }

        /// <summary>
        /// 在预览区域画出下一个方块
        /// </summary>
        void drawNext()
        {
            Random random = new Random();
            nextBlock = random.Next(7);
            Graphics gp = label2.CreateGraphics();
            gp.Clear(Color.Blue);
            Pen pen = new Pen(Color.White);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (1 == blockShape[0, nextBlock, i, j])
                    {
                        SolidBrush br = new SolidBrush(blockColor[nextBlock]);
                        gp.FillRectangle(br, j * 30, i * 30, 30, 30);
                        gp.DrawRectangle(pen, j * 30, i * 30, 30, 30);
                    }
                }
            }
        }

        /// <summary>
        /// 一行填满就消除该行
        /// </summary>
        void killOneRow()
        {
            Graphics gp = label1.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Blue);
            int[] count = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int r = 0; r < 13; r++)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (disAreaState[r, i] == true)
                    {
                        count[r]++;
                        if (count[r] == 12)
                        {
                            gp.FillRectangle(sb, 0, 0, 360, (r + 1) * 30);//清除r行以上的区域
                            gameScore += 100;
                            score.Text = gameScore.ToString();
                            for (int j = r - 1; j >= 1; j--)
                            {
                                for (int m = 0; m < 12; m++)
                                {
                                    disAreaState[j + 1, m] = disAreaState[j, m];//整体下移,注意第一个循环的顺序
                                }
                            }
                        }
                    }
                }
            }
            for (int s = 0; s < 12; s++)
            {
                for (int t = 0; t < 12; t++)
                {
                    if (!disAreaState[s + 1, t] && !disAreaState[s, t])
                    {
                        gp.DrawLine(pen, new Point(30 * t, 30 * (s + 1)), new Point(30 * (t + 1), 30 * (s + 1)));
                    }
                }
            }
            gp.Dispose();
        }

        /// <summary>
        /// 消除某行后重画显示区域
        /// </summary>
        void drawAbove()
        {
            Graphics gp = label1.CreateGraphics();
            Pen pen = new Pen(Color.White);
            for (int n = 0; n < 13; n++)
            {
                for (int t = 0; t < 12; t++)
                {
                    if (disAreaState[n, t] == true)
                    {
                        SolidBrush br = new SolidBrush(Color.Purple);
                        gp.FillRectangle(br, t * 30, n * 30, 30, 30);
                        gp.DrawRectangle(pen, t * 30, n * 30, 30, 30);
                    }
                }
            }
            gp.Dispose();
        }

        #endregion

        #region 测试部分
        /// <summary>
        /// 判断下面是否有方块
        /// </summary>
        bool testBellow()
        {
            bool testResult = false;
            for (int i = 0; i < 4; i++)
            {
                if (blockShape[0, presentBlock, 3, i] == 1)
                {
                    if (disAreaState[(blockHeight / 30) + 4, (blockWidth / 30) + i])
                    {
                        testResult = true;
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (blockShape[0, presentBlock, 2, j] == 1)
                            {
                                if (disAreaState[(blockHeight / 30) + 3, (blockWidth / 30) + j])
                                {
                                    testResult = true;
                                }
                                else
                                {
                                    for (int k = 0; k < 4; k++)
                                    {
                                        if (blockShape[0, presentBlock, 1, k] == 1)
                                        {
                                            if (disAreaState[(blockHeight / 30) + 2, (blockWidth / 30) + k])
                                            {
                                                testResult = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (blockShape[0, presentBlock, 2, m] == 1)
                        {
                            if (disAreaState[(blockHeight / 30) + 3, (blockWidth / 30) + m])
                            {
                                testResult = true;
                            }
                            else
                            {
                                for (int n = 0; n < 4; n++)
                                {
                                    if (blockShape[0, presentBlock, 1, n] == 1)
                                    {
                                        if (disAreaState[(blockHeight / 30) + 2, (blockWidth / 30) + n])
                                        {
                                            testResult = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int t = 0; t < 4; t++)
                            {
                                if (blockShape[0, presentBlock, 1, t] == 1)
                                {
                                    if (disAreaState[(blockHeight / 30) + 2, (blockWidth / 30) + t])
                                    {
                                        testResult = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return testResult;
        }

        /// <summary>
        /// 判断左边是否有方块
        /// </summary>
        int testLeft()
        {
            int testResult = 0;
            for (int i = 0; i < 4; i++)
            {
                if (blockShape[0, presentBlock, i, 0] == 1)
                {
                    if (disAreaState[(blockHeight / 30) + i, (blockWidth / 30) - 1])
                    {
                        testResult = 1;
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (blockShape[0, presentBlock, j, 1] == 1)
                            {
                                if (disAreaState[(blockHeight / 30) + j, (blockWidth / 30) + 0])
                                {
                                    testResult = 2;
                                }
                                else
                                {
                                    for (int k = 0; k < 4; k++)
                                    {
                                        if (blockShape[0, presentBlock, k, 2] == 1)
                                        {
                                            if (disAreaState[(blockHeight / 30) + k, (blockWidth / 30) + 1])
                                            {
                                                testResult = 3;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (blockShape[0, presentBlock, m, 1] == 1)
                        {
                            if (disAreaState[(blockHeight / 30) + m, (blockWidth / 30) + 0])
                            {
                                testResult = 2;
                            }
                            else
                            {
                                for (int n = 0; n < 4; n++)
                                {
                                    if (blockShape[0, presentBlock, n, 2] == 1)
                                    {
                                        if (disAreaState[(blockHeight / 30) + n, (blockWidth / 30) + 1])
                                        {
                                            testResult = 3;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int t = 0; t < 4; t++)
                            {
                                if (blockShape[0, presentBlock, t, 2] == 1)
                                {
                                    if (disAreaState[(blockHeight / 30) + 2, (blockWidth / 30) + 1])
                                    {
                                        testResult = 3;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return testResult;
        }

        /// <summary>
        /// 判断右边是否有方块
        /// </summary>
        int testRight()
        {
            int testResult = 0;
            for (int i = 0; i < 4; i++)
            {
                if (blockShape[0, presentBlock, i, 3] == 1)
                {
                    if (disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + 4])
                    {
                        testResult = 3;
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (blockShape[0, presentBlock, j, 2] == 1)
                            {
                                if (disAreaState[(blockHeight / 30) + j, (blockWidth / 30) + 3])
                                {
                                    testResult = 2;
                                }
                                else
                                {
                                    for (int k = 0; k < 4; k++)
                                    {
                                        if (blockShape[0, presentBlock, k, 1] == 1)
                                        {
                                            if (disAreaState[(blockHeight / 30) + k, (blockWidth / 30) + 2])
                                            {
                                                testResult = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (blockShape[0, presentBlock, m, 2] == 1)
                        {
                            if (disAreaState[(blockHeight / 30) + m, (blockWidth / 30) + 3])
                            {
                                testResult = 2;
                            }
                            else
                            {
                                for (int n = 0; n < 4; n++)
                                {
                                    if (blockShape[0, presentBlock, n, 1] == 1)
                                    {
                                        if (disAreaState[(blockHeight / 30) + n, (blockWidth / 30) + 2])
                                        {
                                            testResult = 1;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int t = 0; t < 4; t++)
                            {
                                if (blockShape[0, presentBlock, t, 1] == 1)
                                {
                                    if (disAreaState[(blockHeight / 30) + 2, (blockWidth / 30) + 2])
                                    {
                                        testResult = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return testResult;
        }


        /// <summary>
        /// 判断方块是否要停止
        /// </summary>
        void test()
        {
            for (int m = 3; m >= 0; m--)
            {
                for (int n = 0; n < 4; n++)
                {
                    if (blockHeight > 0 && (blockShape[0, presentBlock, m, n] == 1) && (blockHeight + 30 * m < 360))
                    {
                        if (testBellow())
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (1 == blockShape[0, presentBlock, i, j])
                                    {
                                        disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + j] = true;
                                    }
                                }
                            }
                            drawBlock();
                            killOneRow();
                            drawAbove();
                            drawNext();
                            blockHeight = -60;
                            blockWidth = 120;
                            presentBlock = tempBlock;
                            tempBlock = nextBlock;
                            drawBlock();
                        }
                    }
                    if ((blockShape[0, presentBlock, m, n] == 1) && (blockHeight + 30 * m >= 360))
                    {
                        blockHeight = -30 * m + 360;
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (1 == blockShape[0, presentBlock, i, j])
                                {
                                    disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + j] = true;
                                }
                            }
                        }
                        drawBlock();
                        killOneRow();
                        drawAbove();
                        drawNext();
                        blockHeight = -60;
                        blockWidth = 120;
                        presentBlock = tempBlock;
                        tempBlock = nextBlock;
                        drawBlock();
                    }
                    else
                        drawBlock();
                }
            }
        }

        #endregion

        /// <summary>
        /// 计时器
        /// </summary>
        private void timerDown_Tick(object sender, EventArgs e)
        {
            clearLast();
            if (testBellow() && (blockHeight <= 0))
            {
                开始EToolStripMenuItem_Click(sender, e);
                nandu = 0;
                Graphics gp = label1.CreateGraphics();
                Font ft = new Font("Times new Roman", 20);
                gp.DrawString(("你的得分:" + score.Text), ft, Brushes.White, 20, 100);

                //保存纪录
                string tempScore = null, tempName = null, tempTime = null;
                FileStream fs = new FileStream("Records.xml", FileMode.Open);
                XmlReader tr = XmlReader.Create(fs);
                while (!tr.EOF)
                {
                    if ((tr.MoveToContent() == XmlNodeType.Element) && tr.Name == "name")
                    {
                        tempName = tr.ReadString();
                    }
                    if ((tr.MoveToContent() == XmlNodeType.Element) && tr.Name == "time")
                    {
                        tempTime = tr.ReadString();
                    }
                    if ((tr.MoveToContent() == XmlNodeType.Element) && tr.Name == "score")
                    {
                        tempScore = tr.ReadString();
                        if (tempScore == "无")
                        {
                            gp.DrawString(("目前还没有纪录！"), ft, Brushes.White, 20, 150);
                            gp.DrawString(("请输入你的姓名："), ft, Brushes.White, 20, 200);
                            nameInput.Visible = true;
                            inPutOk.Visible = true;
                        }
                        else
                        {
                            if (Convert.ToInt32(score.Text) > 0 && Convert.ToInt32(score.Text) >= Convert.ToInt32(tempScore))
                            {
                                tempScore = score.Text;
                                gp.DrawString(("恭喜你打破纪录！"), ft, Brushes.White, 20, 150);
                                gp.DrawString(("请输入你的姓名："), ft, Brushes.White, 20, 200);
                                nameInput.Visible = true;
                                inPutOk.Visible = true;
                            }
                            else
                            {
                                gp.DrawString(("最高纪录:" + tempScore), ft, Brushes.White, 20, 150);
                                gp.DrawString(("纪录保持者:" + tempName), ft, Brushes.White, 20, 200);
                                gp.DrawString(("时间:" + tempTime), ft, Brushes.White, 20, 250);
                                button1.Visible = true;
                            }
                        }
                    }
                    else
                        tr.Read();
                }
                tr.Close();
                fs.Close();
            }
            else
            {
                blockHeight += 30;
                for (int m = 3; m >= 0; m--)
                {
                    for (int n = 0; n < 4; n++)
                    {
                        if (blockHeight > 0 && (blockShape[0, presentBlock, m, n] == 1) && (blockHeight + 30 * m < 360))
                        {
                            if (testBellow())
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        if (1 == blockShape[0, presentBlock, i, j])
                                        {
                                            disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + j] = true;
                                        }
                                    }
                                }
                                drawBlock();
                                killOneRow();
                                drawAbove();
                                drawNext();
                                blockHeight = -60;
                                blockWidth = 120;
                                presentBlock = tempBlock;
                                tempBlock = nextBlock;
                                drawBlock();
                            }
                        }
                        if ((blockShape[0, presentBlock, m, n] == 1) && (blockHeight + 30 * m >= 360))
                        {
                            blockHeight = -30 * m + 360;
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (1 == blockShape[0, presentBlock, i, j])
                                    {
                                        disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + j] = true;
                                    }
                                }
                            }
                            drawBlock();
                            killOneRow();
                            drawAbove();
                            drawNext();
                            blockHeight = -60;
                            blockWidth = 120;
                            presentBlock = tempBlock;
                            tempBlock = nextBlock;
                            drawBlock();
                        }
                        else
                            drawBlock();
                    }
                }
            }
        }
        /// <summary>
        /// 菜单栏选项按钮
        /// </summary>
        #region 菜单栏选项按钮
        private void 简单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerDown.Interval = 1000;
            label8.Text = "1格/1000ms";
            nandu = 1;
            label5.Text = "简单";
        }

        private void 一般ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerDown.Interval = 800;
            label8.Text = "1格/800ms";
            nandu = 2;
            label5.Text = "一般";
        }

        private void 困难ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerDown.Interval = 500;
            label8.Text = "1格/500s";
            nandu = 3;
            label5.Text = "困难";
        }

        private void 帮助HToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help hp = new Help();
            hp.Show();
        }

        private void 退出EToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 开始EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics gp = label1.CreateGraphics();
            gp.Clear(Color.Blue);
            if (hasStarted)//点击结束
            {
                timerDown.Stop();
                gameScore = 0;
                blockHeight = -60;
                blockWidth = 120;
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        disAreaState[i, j] = false;//游戏区域全部初始化没有方块
                    }
                }
                暂停PToolStripMenuItem.Enabled = false;
                timerDown.Interval = 1000;
                难度CToolStripMenuItem.Enabled = true;
            }
            else//点击开始
            {
                this.Focus();
                score.Text = "0";
                Random random = new Random();
                presentBlock = random.Next(4) + random.Next(4);//产生第一个方块
                drawNext();//在预览区域画出方块
                drawBlock();
                tempBlock = nextBlock;
                timerDown.Start();
                暂停PToolStripMenuItem.Enabled = true;
                button1.Visible = false;
                难度CToolStripMenuItem.Enabled = false;
            }
            hasStarted = !hasStarted;

            gp.Dispose();
        }

        private void 暂停PToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (timerDown.Enabled)
            {
                timerDown.Stop();
            }
            else
            {
                timerDown.Start();
            }
        }

        #endregion

        /// <summary>
        /// 打破纪录时姓名输入框
        /// </summary>
        private void inPutOk_Click(object sender, EventArgs e)
        {
            XmlWriter wr = XmlWriter.Create("Records.xml");
            wr.WriteStartElement("person");
            wr.WriteElementString("name", nameInput.Text);
            wr.WriteElementString("time", DateTime.Now.ToString());
            wr.WriteElementString("score", score.Text);
            wr.WriteEndElement();
            wr.Close();

            nameInput.Visible = false;
            inPutOk.Visible = false;
            Graphics gp = label1.CreateGraphics();
            SolidBrush br = new SolidBrush(Color.Blue);
            gp.FillRectangle(br, 0, 200, 360, 30);
            gp.Dispose();
            nameInput.Clear();
            this.Focus();
        }

        /// <summary>
        /// 清除记录按钮
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            XmlWriter wr = XmlWriter.Create("Records.xml");
            wr.WriteStartElement("person");
            wr.WriteElementString("name", "无");
            wr.WriteElementString("time", "无");
            wr.WriteElementString("score", "无");
            wr.WriteEndElement();
            wr.Close();

            button1.Visible = false;
            Graphics gp = label1.CreateGraphics();
            gp.Clear(Color.Blue);
            gp.DrawString(("纪录成功清除！"), new Font("Times new Roman", 30), Brushes.White, 20, 150);
            gp.Dispose();
            this.Focus();
        }

        /// <summary>
        /// 键盘事件
        /// 方向键控制
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyData.ToString());
            switch (e.KeyData)
            {
                case Keys.Space:
                case Keys.W:
                case Keys.Up:
                    {
                        clearLast();
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    blockShape[0, i, j, k] = blockShape[transformCount, i, j, k];
                                    if (blockWidth + 30 * j <= 0)
                                    {
                                        blockWidth = -30 * j;
                                    }
                                    else if (blockWidth + 30 * j >= 330)
                                    {
                                        blockWidth = 330 - 30 * j;
                                    }
                                }
                            }
                        }
                        drawBlock();
                        transformCount = (transformCount > 3 ? 1 : (transformCount + 1));
                        test();
                    }
                    break;
                case Keys.A:
                case Keys.Left:
                    {
                        int isLeftIndex = 0;
                        bool isLeft = false;
                        clearLast();
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if ((blockShape[0, presentBlock, i, j] == 1) && (blockWidth + 30 * j) <= 0)
                                {
                                    isLeft = true;
                                    isLeftIndex = j;
                                }
                            }
                        }
                        if (isLeft == true)
                        {
                            blockWidth = -30 * isLeftIndex;
                            clearLast();
                        }
                        else
                        {
                            if ((blockWidth > 30) && (blockHeight >= 0) && testLeft() > 0)
                            {
                                //blockWidth = blockWidth + 30 * (testLeft() - 2);
                                blockWidth -= 0;
                                clearLast();
                            }
                            else
                            {
                                blockWidth -= 30;
                                clearLast();
                            }

                        }
                        drawBlock();

                        test();
                    }
                    break;
                case Keys.D:
                case Keys.Right:
                    {
                        bool isRight = false;
                        int isRightIndex = 0;
                        clearLast();
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 3; j >= 0; j--)
                            {
                                if ((blockShape[0, presentBlock, i, j] == 1) && (blockWidth + 30 * j) >= 330)
                                {
                                    isRight = true;
                                    isRightIndex = j;
                                }
                            }
                        }
                        if (isRight == true)
                        {
                            blockWidth = 330 - 30 * isRightIndex;
                            clearLast();
                        }
                        else
                        {
                            if ((blockHeight >= 0) && testRight() > 0)
                            {
                                //blockWidth = blockWidth + 30 * (testRight()+1);
                                blockWidth += 0;
                                clearLast();
                            }
                            else
                            {
                                blockWidth += 30;
                                clearLast();
                            }

                        }
                        drawBlock();
                        test();
                    }
                    break;
                case Keys.S:
                case Keys.Down:
                    {
                        clearLast();
                        for (int m = 3; m >= 0; m--)
                        {
                            for (int n = 0; n < 4; n++)
                            {
                                if (blockHeight + 60 > 0 && (blockShape[0, presentBlock, m, n] == 1) && (blockHeight + 30 * m < 360))
                                {
                                    if (!testBellow())
                                    {
                                        for (; ; )
                                        {
                                            blockHeight += 30;
                                            if ((blockShape[0, presentBlock, m, n] == 1) && (blockHeight + 30 * m >= 360))
                                            {
                                                blockHeight = -30 * m + 360;
                                                for (int i = 0; i < 4; i++)
                                                {
                                                    for (int j = 0; j < 4; j++)
                                                    {
                                                        if (1 == blockShape[0, presentBlock, i, j])
                                                        {
                                                            disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + j] = true;
                                                        }
                                                    }
                                                }
                                                drawBlock();
                                                killOneRow();
                                                drawAbove();
                                                drawNext();
                                                blockHeight = -60;
                                                blockWidth = 120;
                                                presentBlock = tempBlock;
                                                tempBlock = nextBlock;
                                                drawBlock();
                                                break;
                                            }
                                            if ((blockHeight + 30 * m < 360) && testBellow())
                                            {
                                                for (int i = 0; i < 4; i++)
                                                {
                                                    for (int j = 0; j < 4; j++)
                                                    {
                                                        if (1 == blockShape[0, presentBlock, i, j])
                                                        {
                                                            disAreaState[(blockHeight / 30) + i, (blockWidth / 30) + j] = true;
                                                        }
                                                    }
                                                }
                                                drawBlock();
                                                killOneRow();
                                                drawAbove();
                                                drawNext();
                                                blockHeight = -60;
                                                blockWidth = 120;
                                                presentBlock = tempBlock;
                                                tempBlock = nextBlock;
                                                drawBlock();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        drawBlock();
                    }
                    break;
                case Keys.F5:
                    暂停PToolStripMenuItem1_Click(sender, e);
                    break;
                case Keys.F1:
                    开始EToolStripMenuItem_Click(sender, e);
                    nameInput.Visible = false;
                    inPutOk.Visible = false;
                    break;

            }
        }

        private void nameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Space)
            {
                inPutOk_Click(sender, e);
            }
            this.Focus();
        }

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            帮助HToolStripMenuItem1_Click(sender, e);
        }

        private void score_TextChanged(object sender, EventArgs e)
        {
            //分数每上升2000下降速率就加快一格/100ms
            if (Convert.ToInt32(score.Text) % 1000 == 0 && Convert.ToInt32(score.Text) >= 1000)
            {
                switch (nandu)
                {
                    case 1:
                        timerDown.Interval = (timerDown.Interval < 500 ? 500 : (1000 - (Convert.ToInt32(score.Text) / 2000 ) * 50));
                        break;
                    case 2:
                        timerDown.Interval = (timerDown.Interval < 500 ? 500 : (800 - (Convert.ToInt32(score.Text) / 2000 ) * 50));
                        break;
                    case 3:
                        timerDown.Interval = (timerDown.Interval < 500 ? 500 : (500 - (Convert.ToInt32(score.Text) / 2000 ) * 50));
                        break;
                }
                label8.Text = "1格/" + timerDown.Interval.ToString() + "ms";
            }
        }

        private void 最高记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempScore = null, tempName = null, tempTime = null;
            FileStream fs = new FileStream("Records.xml", FileMode.Open);
            XmlReader tr = XmlReader.Create(fs);
            while (!tr.EOF)
            {
                if ((tr.MoveToContent() == XmlNodeType.Element) && tr.Name == "name")
                {
                    tempName = tr.ReadString();
                }
                if ((tr.MoveToContent() == XmlNodeType.Element) && tr.Name == "time")
                {
                    tempTime = tr.ReadString();
                }
                if ((tr.MoveToContent() == XmlNodeType.Element) && tr.Name == "score")
                {
                    tempScore = tr.ReadString();
                    if (tempScore == "无")
                    {
                        MessageBox.Show("目前还没有纪录！", "纪录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("最高纪录:" + tempScore + "\r\n纪录保持者:" + tempName + "\r\n时间:" + tempTime, "纪录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    tr.Read();
            }
            tr.Close();
            fs.Close();
        }
    }
}
