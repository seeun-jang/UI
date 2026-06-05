using System;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private Timer chartTimer;
        private Random random;
        Random rnd = new Random();
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
            int randomValue = rnd.Next(0, 11); int randomValue2 = rnd.Next(0, 11);

            if (chart1.Series[0].Points.Count > 50)

            {

                chart1.Series[0].Points.RemoveAt(0);

            }


            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("ss.f"), randomValue);

            chart1.ChartAreas[0].RecalculateAxesScale();

            if (chart1.Series[1].Points.Count > 50)

            {

                chart1.Series[1].Points.RemoveAt(0);

            }


            chart1.Series[1].Points.AddXY(DateTime.Now.ToString("ss.f"), randomValue2);

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