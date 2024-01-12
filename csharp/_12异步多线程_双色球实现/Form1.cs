namespace _12异步多线程_双色球实现
{
    /// <summary>
    /// 多线程双色球项目
    /// 双色球：投注号码由6个红色号码和一个蓝色号码组成
    /// 红色球号码从01--33中选择（不重复）
    /// 蓝色球号码从01--16中选择
    /// 7个球杂乱无章的变化：球的号码来自于复杂数据计算
    ///                  可能需要纳斯达克股票指数 + 全球气象指数 + .....（费时间）
    /// 
    /// 随机的规则是远程获取一个数据的，这个会有较长的事件损耗
    /// Random 同一时间随机不靠谱
    /// </summary>
    public partial class Form1 : Form
    {
        private static readonly string[] RedNum = RandomHelper.GetNums(33);
        private static readonly string[] BlueNum = RandomHelper.GetNums(16);
        private readonly object Red_Lock = new object();

        private bool GoIn = true;
        public Form1()
        {
            InitializeComponent();

            btnStop.Enabled = false;
        }

        /// <summary>
        /// 开始方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            List<Task> lstTask = new List<Task>();
            GoIn = true;
            lblRed1.Text = "00";
            lblRed2.Text = "00";
            lblRed3.Text = "00";
            lblRed4.Text = "00";
            lblRed5.Text = "00";
            lblRed6.Text = "00";
            lblBlue.Text = "00";
            btnStart.Enabled = false;
            Thread.Sleep(1000);
            btnStop.Enabled = true;
            TaskFactory taskFactory = Task.Factory;
            // 获取数字数控件
            foreach (var ctrl in groupBox.Controls)
            {
                if (ctrl is Label)
                {
                    Label label = (Label)ctrl;
                    //蓝色
                    if (label.Name.Contains("Blue"))
                    {
                        lstTask.Add(taskFactory.StartNew(() =>
                        {
                            while (GoIn)
                            {
                                var index = RandomHelper.GetAsyncRandom(0, BlueNum.Length);
                                UpdateLabel(label, BlueNum[index]);
                            }
                        }));
                    }
                    //红色
                    else
                    {
                        lstTask.Add(taskFactory.StartNew(() =>
                        {
                            while (GoIn)
                            {
                                var index = RandomHelper.GetAsyncRandom(0, RedNum.Length);
                                string red = RedNum[index];
                                lock (Red_Lock)
                                {
                                    if (!GetRedLabelArr().Contains(red))
                                    {
                                        UpdateLabel(label, red);
                                    }
                                }
                            }
                        }));
                    }
                    taskFactory.ContinueWhenAll(lstTask.ToArray(), t => { ShowMessageBox(); });
                }
            }
        }

        /// <summary>
        /// 停止方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            GoIn = false;

        }

        /// <summary>
        /// 子线程更新Label
        /// </summary>
        /// <param name="label"></param>
        /// <param name="name"></param>
        private void UpdateLabel(Label label, string name)
        {
            if (label.InvokeRequired)
            {
                this.Invoke(new Action(() => {
                    label.Text = name;
                }));
            }
            else
            {
                label.Text = name;
            }
        }

        /// <summary>
        /// 获取当前lable值
        /// </summary>
        /// <returns></returns>
        private string[] GetRedLabelArr()
        {
            List<string> strings = new List<string>()
            {
                lblRed1.Text,
                lblRed2.Text,
                lblRed3.Text,
                lblRed4.Text,
                lblRed5.Text,
                lblRed6.Text,
                lblBlue.Text
            };

            return strings.ToArray();
        }

        /// <summary>
        /// 获取当前lable值
        /// </summary>
        /// <returns></returns>
        private void ShowMessageBox()
        {
            MessageBox.Show($"当前结果 红色球：{lblRed1.Text} {lblRed2.Text} {lblRed3.Text} {lblRed4.Text} {lblRed5.Text} {lblRed6.Text} 蓝色球：{lblBlue.Text}");
            
        }
    }
}