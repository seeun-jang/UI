using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // 프로그램 시작 시 사용자 정의 UI 디자인을 적용한다.
            ApplySeeunDesign();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // 라벨 클릭 시 실행될 이벤트입니다.
        }

        // 게임의 진행 시간을 저장하는 정수형 변수
        private int elapsedTime = 0;
        
        private void timer1_Tick(object sender, EventArgs e) //타이머의 설정된 간격마다 반복 실행되는 이벤트입니다.
        {
            elapsedTime++;
            // 계산된 시간을 소수점 둘째 자리(F2)까지 문자열로 변환하여 출력한다.
            textBox1.Text = (elapsedTime * 0.005).ToString("F2") + "초 경과";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (textBox1.Text == "3.00초 경과")
            {
                textBox2.Text = "당첨♥!";
            }
            else
            {
                textBox2.Text = "실패..ㅜ_ㅜ";
            }
        }

        
        // 리셋 버튼: 타이머를 멈추고 측정된 시간과 화면 표시를 초기화한다.
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            textBox1.Text = " ";
            elapsedTime = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        // 결과 출력창의 텍스트가 변경될 때 실행되는 이벤트
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ApplySeeunDesign()
        {
            // 1. 배경 설정 (파일 경로 오류 방지를 위해 시도/예외 처리)
            try
            {
                this.BackgroundImage = Image.FromFile(@"image_0dc39f.jpg"); // 👈 파일이 실행 폴더에 꼭 있어야 해!
                this.BackgroundImageLayout = ImageLayout.Tile;
            }
            catch
            {
                this.BackColor = Color.LavenderBlush; // 이미지 없으면 예쁜 핑크색으로!
            }

            // 2. 텍스트 박스 (뽀얀 느낌)
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.HotPink;
            textBox1.Font = new Font("맑은 고딕", 25, FontStyle.Bold);

            textBox2.BackColor = Color.LavenderBlush;
            textBox2.ForeColor = Color.DeepPink;

            // 3. 버튼 (리본 느낌을 내기 위한 둥근 폰트와 파스텔 색상)
            SetSoftButton(button1, "🎀 START", Color.MistyRose);
            SetSoftButton(button2, "📍 STOP!", Color.Pink);
            SetSoftButton(button3, "🧸 RESET", Color.White);
        }

        private void SetSoftButton(Button btn, string text, Color color)
        {
            btn.Text = text;
            btn.BackColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.HotPink;
            btn.FlatAppearance.BorderSize = 2;
            btn.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 아무 내용도 안 써도 돼! 그냥 존재하기만 하면 오류는 사라진단다.
        }
    }
}


