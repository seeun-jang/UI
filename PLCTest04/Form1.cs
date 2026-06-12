using ACTMULTILIB_K;
using System;
using System.Windows.Forms;

namespace PLCTest04
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        Timer autoTimer = new Timer();

        bool isConnected = false;
        bool isAutoMode = false;

        int step = 0;

        // X 센서 입력 - 현재 시뮬레이터 동작 기준
        int SENSOR_B_FWD = 1 << 2;  // X02 : B실린더 전진 완료
        int SENSOR_B_BWD = 1 << 3;  // X03 : B실린더 후진 완료

        int SENSOR_C_FWD = 1 << 5;  // X05 : C실린더 전진 완료
        int SENSOR_C_BWD = 1 << 4;  // X04 : C실린더 후진 완료

        int STAGE_A = 1 << 10;      // XA : 리프트센서 A
        int STAGE_B = 1 << 11;      // XB : 리프트센서 B

        // X 센서 입력 - 교수님 시뮬레이터 정보 기준
        // int SENSOR_B_BWD = 1 << 2;  // X02 : B실린더 후진 완료
        // int SENSOR_B_FWD = 1 << 3;  // X03 : B실린더 전진 완료

        // int SENSOR_C_FWD = 1 << 4;  // X04 : C실린더 전진 완료
        // int SENSOR_C_BWD = 1 << 5;  // X05 : C실린더 후진 완료

        // int STAGE_A = 1 << 10;      // XA : 리프트센서 A
        // int STAGE_B = 1 << 11;      // XB : 리프트센서 B

        // Y 출력
        int OUT_B_FWD = 1 << 1;     // Y01 : B실린더 전진
        int OUT_B_BWD = 1 << 2;     // Y02 : B실린더 후진

        int OUT_C_FWD = 1 << 3;     // Y03 : C실린더 전진
        int OUT_C_BWD = 1 << 4;     // Y04 : C실린더 후진

        public Form1()
        {
            InitializeComponent();

            button1.Text = "연결";
            button2.Text = "시작";
            button3.Text = "정지";

            label1.AutoSize = true;
            label1.Text = "초기상태";

            autoTimer.Interval = 100;
            autoTimer.Tick += autoTimer_Tick;
        }

        // 버튼 1 : 연결
        private void button1_Click(object sender, EventArgs e)
        {
            int result = control.Open();

            if (result == 0)
            {
                isConnected = true;

                MessageBox.Show("연결 성공!");
                label1.Text = "연결 완료. 시작 버튼을 누르세요.";
            }
            else
            {
                isConnected = false;

                MessageBox.Show("연결 실패!");
                label1.Text = "연결 실패";
            }
        }

        // 버튼 2 : 자동운전 시작
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("먼저 연결 버튼을 누르세요.");
                return;
            }

            isAutoMode = true;
            step = 0;

            // 시작하면 B, C 실린더를 후진 상태로 잡아둠
            SetOutput(false, true, false, true);

            autoTimer.Start();

            label1.Text = "자동운전 시작\n위쪽 리프트센서 A에 물건을 올려주세요.";
        }

        // 버튼 3 : 자동운전 정지
        private void button3_Click(object sender, EventArgs e)
        {
            isAutoMode = false;
            step = 0;

            autoTimer.Stop();
            StopAll();

            label1.Text = "자동운전 정지됨.";
        }

        // 타이머 : 자동운전 처리
        private void autoTimer_Tick(object sender, EventArgs e)
        {
            if (!isConnected || !isAutoMode)
                return;

            short sensor = 0;

            int readResult = control.ReadDeviceBlock2("X0", 1, out sensor);

            if (readResult != 0)
            {
                label1.Text = "센서 읽기 실패";
                return;
            }

            bool bForwardSensor = (sensor & SENSOR_B_FWD) != 0;
            bool bBackwardSensor = (sensor & SENSOR_B_BWD) != 0;

            bool cForwardSensor = (sensor & SENSOR_C_FWD) != 0;
            bool cBackwardSensor = (sensor & SENSOR_C_BWD) != 0;

            bool liftA = (sensor & STAGE_A) != 0;
            bool liftB = (sensor & STAGE_B) != 0;

            switch (step)
            {
                case 0:
                    // 리프트센서 A에 물건이 올라오면 B실린더 전진
                    if (liftA)
                    {
                        SetOutput(true, false, false, true);

                        step = 1;
                        label1.Text = "[1단계] 리프트센서 A 감지\nB실린더 전진 중";
                    }
                    break;

                case 1:
                    // B실린더 전진 완료
                    if (bForwardSensor)
                    {
                        SetOutput(false, true, false, true);

                        step = 2;
                        label1.Text = "[2단계] B실린더 전진 완료\nB실린더 후진 중";
                    }
                    break;

                case 2:
                    // B실린더 후진 완료 + 물건이 아래쪽 리프트센서 B에 도착
                    if (bBackwardSensor && liftB)
                    {
                        SetOutput(false, true, true, false);

                        step = 3;
                        label1.Text = "[3단계] 리프트센서 B 감지\nC실린더 전진 중";
                    }
                    break;

                case 3:
                    // C실린더 전진 완료
                    if (cForwardSensor)
                    {
                        SetOutput(false, true, false, true);

                        step = 4;
                        label1.Text = "[4단계] C실린더 전진 완료\nC실린더 후진 중";
                    }
                    break;

                case 4:
                    // C실린더 후진 완료
                    if (cBackwardSensor)
                    {
                        SetOutput(false, true, false, true);

                        step = 0;
                        label1.Text = "다음 물건을 올려주세요.";
                    }
                    break;
            }
        }

        // 출력 제어 함수
        private void SetOutput(bool bFwd, bool bBwd, bool cFwd, bool cBwd)
        {
            short yValue = 0;

            if (bFwd)
                yValue += (short)OUT_B_FWD;

            if (bBwd)
                yValue += (short)OUT_B_BWD;

            if (cFwd)
                yValue += (short)OUT_C_FWD;

            if (cBwd)
                yValue += (short)OUT_C_BWD;

            control.WriteDeviceBlock2("Y0", 1, ref yValue);
        }

        // 모든 출력 OFF
        private void StopAll()
        {
            short yValue = 0;
            control.WriteDeviceBlock2("Y0", 1, ref yValue);
        }

        // 디자이너 이벤트 오류 방지용
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
        }

        // 폼 종료 시 출력 OFF
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isConnected)
            {
                StopAll();
                control.Close();
            }

            base.OnFormClosing(e);
        }
    }
}