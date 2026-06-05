using System;
using System.Drawing;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace PCLTest03
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        bool isConnected = false;

        // 현재 출력 상태 저장
        short yValue = 0;

        // 출력 비트
        // Y0 = B전진
        // Y1 = B후진
        // Y2 = C전진
        // Y3 = C후진
        const short Y_B_FWD = 0x0001;
        const short Y_B_BWD = 0x0002;
        const short Y_C_FWD = 0x0004;
        const short Y_C_BWD = 0x0008;

        // 센서 비트
        // X0 = B전진 센서
        // X1 = B후진 센서
        // X2 = C전진 센서
        // X3 = C후진 센서
        // X4 = Stage Sensor-A
        // X5 = Stage Sensor-B
        const short X_B_FWD = 0x0001;
        const short X_B_BWD = 0x0002;
        const short X_C_FWD = 0x0004;
        const short X_C_BWD = 0x0008;
        const short X_STAGE_A = 0x0010;
        const short X_STAGE_B = 0x0020;

        Label lblState = new Label();

        public Form1()
        {
            InitializeComponent();
            SetupDesign();
        }

        private void SetupDesign()
        {
            this.Text = "전진";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(520, 330);

            // 버튼 글자 설정
            button1.Text = "연결";
            button2.Text = "센서읽기";
            button3.Text = "B전진";
            button4.Text = "B후진";
            button5.Text = "C전진";
            button6.Text = "C후진";

            // 버튼 위치 설정
            button1.SetBounds(220, 45, 115, 60);
            button2.SetBounds(390, 45, 100, 60);

            button3.SetBounds(100, 120, 115, 55);
            button5.SetBounds(255, 120, 115, 55);

            button4.SetBounds(100, 190, 115, 55);
            button6.SetBounds(255, 190, 115, 55);

            // 상태 표시 라벨
            lblState.Text = "대기";
            lblState.TextAlign = ContentAlignment.MiddleCenter;
            lblState.SetBounds(210, 260, 130, 30);
            this.Controls.Add(lblState);

            // 이벤트 연결
            button1.Click -= button1_Click;
            button1.Click += button1_Click;

            button2.Click -= button2_Click;
            button2.Click += button2_Click;

            button3.Click -= button3_Click;
            button3.Click += button3_Click;

            button4.Click -= button4_Click;
            button4.Click += button4_Click;

            button5.Click -= button5_Click;
            button5.Click += button5_Click;

            button6.Click -= button6_Click;
            button6.Click += button6_Click;

            this.FormClosing -= Form1_FormClosing;
            this.FormClosing += Form1_FormClosing;
        }

        // 연결 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            int result = control.Open();

            if (result == 0)
            {
                isConnected = true;
                button1.Text = "연결됨";
                lblState.Text = "연결 완료";
                MessageBox.Show("PLC 연결 성공");
            }
            else
            {
                isConnected = false;
                lblState.Text = "연결 실패";
                MessageBox.Show("PLC 연결 실패");
            }
        }

        // 센서읽기 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            short xValue = 0;

            int result = control.ReadDeviceBlock2("X0", 1, out xValue);

            if (result != 0)
            {
                MessageBox.Show("센서 읽기 실패");
                return;
            }

            string sensorText =
                $"B-전진 센서 X0 : {OnOff(xValue, X_B_FWD)}\n" +
                $"B-후진 센서 X1 : {OnOff(xValue, X_B_BWD)}\n" +
                $"C-전진 센서 X2 : {OnOff(xValue, X_C_FWD)}\n" +
                $"C-후진 센서 X3 : {OnOff(xValue, X_C_BWD)}\n" +
                $"Stage Sensor-A X4 : {OnOff(xValue, X_STAGE_A)}\n" +
                $"Stage Sensor-B X5 : {OnOff(xValue, X_STAGE_B)}";

            lblState.Text = "센서 읽기 완료";
            MessageBox.Show(sensorText, "센서 상태");
        }

        // B전진 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            // B전진 ON, B후진 OFF
            yValue = (short)(yValue & ~(Y_B_FWD | Y_B_BWD));
            yValue = (short)(yValue | Y_B_FWD);

            WriteOutput();
            lblState.Text = "B 전진";
        }

        // B후진 버튼
        private void button4_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            // B후진 ON, B전진 OFF
            yValue = (short)(yValue & ~(Y_B_FWD | Y_B_BWD));
            yValue = (short)(yValue | Y_B_BWD);

            WriteOutput();
            lblState.Text = "B 후진";
        }

        // C전진 버튼
        private void button5_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            // C전진 ON, C후진 OFF
            yValue = (short)(yValue & ~(Y_C_FWD | Y_C_BWD));
            yValue = (short)(yValue | Y_C_FWD);

            WriteOutput();
            lblState.Text = "C 전진";
        }

        // C후진 버튼
        private void button6_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) return;

            // C후진 ON, C전진 OFF
            yValue = (short)(yValue & ~(Y_C_FWD | Y_C_BWD));
            yValue = (short)(yValue | Y_C_BWD);

            WriteOutput();
            lblState.Text = "C 후진";
        }

        private void WriteOutput()
        {
            short value = yValue;

            int result = control.WriteDeviceBlock2("Y0", 1, ref value);

            if (result != 0)
            {
                MessageBox.Show("출력 쓰기 실패");
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

        private string OnOff(short value, short mask)
        {
            if ((value & mask) != 0)
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                short stop = 0;
                control.WriteDeviceBlock2("Y0", 1, ref stop);
                control.Close();
            }
            catch
            {
                // 종료 중 오류 무시
            }
        }
    }
}