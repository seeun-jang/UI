using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ACTMULTILIB_K;

namespace PCLTest02
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        bool isConnected = false;
        bool isAutoMode = false;

        // 전진 = 1, 후진 = 0, 정지 = -1
        int currentState = -1;

        // 실제 장비 기준
        // Y01 = 전진 출력
        // Y02 = 후진 출력
        // X02 = 전진 센서
        // X03 = 후진 센서
        const int MASK_FWD = 0x04; // X02 전진 센서
        const int MASK_BWD = 0x08; // X03 후진 센서

        public Form1()
        {
            InitializeComponent();

            label1.Text = "초기상태";
            label2.Text = "2601110299 장세은";

            timer1.Interval = 500; // 너무 느리면 반응 답답해서 0.5초
            timer1.Enabled = false;

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Properties.Resources.cylinderoff;

            InitChart();
        }

        private void InitChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            ChartArea area = new ChartArea("ChartArea1");
            chart1.ChartAreas.Add(area);

            Series series = new Series("Series1");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 1;
            series.MarkerStyle = MarkerStyle.None;

            chart1.Series.Add(series);

            Legend legend = new Legend("Legend1");
            chart1.Legends.Add(legend);
            chart1.Series["Series1"].Legend = "Legend1";

            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 8;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 20;

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = System.Drawing.Color.Black;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = System.Drawing.Color.Black;

            chart1.ChartAreas["ChartArea1"].AxisX.LineColor = System.Drawing.Color.Black;
            chart1.ChartAreas["ChartArea1"].AxisY.LineColor = System.Drawing.Color.Black;
        }

        // button1 : 연결
        private void button1_Click(object sender, EventArgs e)
        {
            int result = control.Open();

            if (result == 0)
            {
                isConnected = true;
                timer1.Enabled = true;

                label1.Text = "PLC 연결 성공";
                MessageBox.Show("PLC 연결 성공");
            }
            else
            {
                isConnected = false;
                timer1.Enabled = false;

                label1.Text = "PLC 연결 실패";
                MessageBox.Show("PLC 연결 실패");
            }
        }

        // button2 : 전진
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            isAutoMode = false;
            Forward();

            label1.Text = "전진 명령";
        }

        // button3 : 후진
        private void button3_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            isAutoMode = false;
            Backward();

            label1.Text = "후진 명령";
        }

        // button4 : 시작
        private void button4_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            isAutoMode = true;
            timer1.Enabled = true;

            // 시작 누르면 무조건 전진부터
            Forward();

            label1.Text = "자동 운전 시작";
        }

        // button5 : 정지
        private void button5_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            isAutoMode = false;
            StopMotor();

            label1.Text = "정지";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunTimerLogic();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            RunTimerLogic();
        }

        private void RunTimerLogic()
        {
            if (!isConnected) return;

            short sensor = 0;
            int readResult = control.ReadDeviceBlock2("X0", 1, out sensor);

            if (readResult != 0)
            {
                label1.Text = "센서 읽기 실패";
                return;
            }

            bool forwardSensor = (((int)sensor & MASK_FWD) != 0);
            bool backwardSensor = (((int)sensor & MASK_BWD) != 0);

            if (isAutoMode)
            {
                // 현재 전진 중이고 전진 센서에 닿으면 후진
                if (currentState == 1 && forwardSensor)
                {
                    Backward();
                    label1.Text = "전진 완료 → 후진 / 센서값: " + sensor.ToString();
                }
                // 현재 후진 중이고 후진 센서에 닿으면 전진
                else if (currentState == 0 && backwardSensor)
                {
                    Forward();
                    label1.Text = "후진 완료 → 전진 / 센서값: " + sensor.ToString();
                }
                else
                {
                    if (currentState == 1)
                    {
                        label1.Text = "전진중 / 센서값: " + sensor.ToString();
                    }
                    else if (currentState == 0)
                    {
                        label1.Text = "후진중 / 센서값: " + sensor.ToString();
                    }
                    else
                    {
                        label1.Text = "대기중 / 센서값: " + sensor.ToString();
                    }
                }
            }
            else
            {
                if (forwardSensor)
                {
                    label1.Text = "전진 완료 / 센서값: " + sensor.ToString();
                }
                else if (backwardSensor)
                {
                    label1.Text = "후진 완료 / 센서값: " + sensor.ToString();
                }
                else
                {
                    label1.Text = "센서 감지 없음 / 센서값: " + sensor.ToString();
                }
            }

            if (currentState == 1)
            {
                pictureBox2.Image = Properties.Resources.cylinderon;
                AddChartData(1);
            }
            else if (currentState == 0)
            {
                pictureBox2.Image = Properties.Resources.cylinderoff;
                AddChartData(0);
            }
        }

        private bool CheckConnection()
        {
            if (!isConnected)
            {
                MessageBox.Show("먼저 연결 버튼을 누르세요.");
                return false;
            }

            return true;
        }

        private void Forward()
        {
            // Y01 = 전진
            short value = 0x01 << 1;
            int result = control.WriteDeviceBlock2("Y0", 1, ref value);

            if (result != 0)
            {
                label1.Text = "전진 출력 실패";
                return;
            }

            currentState = 1;
            pictureBox2.Image = Properties.Resources.cylinderon;
        }

        private void Backward()
        {
            // Y02 = 후진
            short value = 0x01 << 2;
            int result = control.WriteDeviceBlock2("Y0", 1, ref value);

            if (result != 0)
            {
                label1.Text = "후진 출력 실패";
                return;
            }

            currentState = 0;
            pictureBox2.Image = Properties.Resources.cylinderoff;
        }

        private void StopMotor()
        {
            // 출력 전체 OFF
            short value = 0;
            int result = control.WriteDeviceBlock2("Y0", 1, ref value);

            if (result != 0)
            {
                label1.Text = "정지 출력 실패";
                return;
            }

            currentState = -1;
            pictureBox2.Image = Properties.Resources.cylinderoff;
        }

        private void AddChartData(int value)
        {
            Series series = chart1.Series["Series1"];

            int chartValue;

            if (value == 1)
            {
                chartValue = 100;
            }
            else
            {
                chartValue = 0;
            }

            series.Points.AddY(chartValue);

            if (series.Points.Count > 8)
            {
                series.Points.RemoveAt(0);
            }

            for (int i = 0; i < series.Points.Count; i++)
            {
                series.Points[i].XValue = i + 1;
            }

            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 8;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
