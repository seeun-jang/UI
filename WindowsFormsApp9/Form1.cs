using System;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private Timer chartTimer;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            InitializeChartAndTimer();
        }

        private void InitializeChartAndTimer()
        {
            random = new Random();

            // 타이머 설정
            chartTimer = new Timer();
            chartTimer.Interval = 100;
            chartTimer.Tick += ChartTimer_Tick; 

            // 차트 Y축 고정 
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
        }

        // 타이머 이벤트
        private void ChartTimer_Tick(object sender, EventArgs e)
        {
            // 0~10 사이의 난수 생성
            double randomValue = random.NextDouble() * 10;

            // 흘러가는 효과
            if (chart1.Series[0].Points.Count > 50)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss.f"), randomValue);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button1_Click(object sender, EventArgs e) // High 버튼 
        {
            if (chart1.Series[0].Points.Count > 50)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss.f"), 1);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button2_Click(object sender, EventArgs e) // Low 버튼 
        {
            if (chart1.Series[0].Points.Count > 50)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss.f"), 0);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button3_Click(object sender, EventArgs e) // Start 버튼
        {
            chartTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e) // Stop 버튼
        {
            chartTimer.Stop();
        }
    }
}