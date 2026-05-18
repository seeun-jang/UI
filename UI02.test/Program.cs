using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace UI02.test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            if (DateTime.Now.Hour < 11)
            //            {
            //                Console.WriteLine("아침 먹을 시간입니다.");
            //            }
            //            else if (DateTime.Now.Hour < 10)
            //            {
            //                Console.WriteLine("점심 먹을 시간입니다.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("저녁 먹을 시간입니다.");
            //            }
            //        }
            //    }
            //}

            //            Console.Write("숫자를 입력하세요 :");
            //            string s_input = Console.ReadLine();
            //            int input = int.Parse(s_input);
            //            int remain = input % 2;

            //            // 조건문
            //            switch (remain)
            //            {
            //                case 0:
            //                    Console.WriteLine("짝수입니다.");
            //                    break;
            //                case 1:
            //                    Console.WriteLine("홀수입니다.");
            //                    break;
            //            }
            //        }
            //    }
            //}

            //            Console.Write("숫자를 입력하세요 :");
            //            string s_input = Console.ReadLine();
            //            int input = int.Parse(s_input);
            //            int remain = input % 2;

            //            if (remain == 0) Console.WriteLine("짝수입니다.");
            //            else if (remain == 1) Console.WriteLine("홀수입니다.");

            //        }
            //    }
            //}
            //Console.Write("이번 달은 몇 월 인가요 : ");

            //int input = int.Parse(Console.ReadLine());

            //            switch (input)
            //            {
            //                case 12:
            //                case 1:
            //                case 2:

            //                    Console.WriteLine("겨울입니다.");
            //                    break;
            //                case 3:
            //                case 4:
            //                case 5:

            //                    Console.WriteLine("봄입니다.");
            //                    break;

            //                case 6:
            //                case 7:
            //                case 8:
            //                    Console.WriteLine("여름입니다.");
            //                    break;

            //                case 9:
            //                case 10:
            //                case 11:
            //                    Console.WriteLine("가을입니다.");
            //                    break;

            //                default:
            //                    Console.WriteLine("대체 어떤 행성에 살고 계신가요?");
            //                    break;
            //            }

            //        }
            //    }
            //}

            //            if (DateTime.Now.Month < 3)
            //            {
            //                Console.WriteLine("겨울입니다.");
            //            }
            //            else if (DateTime.Now.Month < 6)
            //            {
            //                Console.WriteLine("봄입니다."); // 어디가 잘못 되었는지 문제점을 찾기.
            //            }
            //            if (DateTime.Now.Month < 9)
            //            {
            //                Console.WriteLine("여름입니다.");
            //            }
            //            else if (DateTime.Now.Month < 12)   
            //            {
            //                Console.WriteLine("가을입니다.");
            //            }
            //        }
            //    }
            //}
            //            if (input == 12 || (input > 0 && input < 3)) // 교수님 풀이방식.
            //            {
            //                Console.WriteLine("겨울입니다.");
            //            }
            //            else if (input < 6)
            //            {
            //                Console.WriteLine("봄입니다.");
            //            }
            //            else if (input < 9)
            //            {
            //                Console.WriteLine("여름입니다.");
            //            }
            //            else if (input < 12)
            //            {
            //                Console.WriteLine("가을입니다.");
            //            }
            //        }
            //    }
            //}
            //            Console.Write("입력 :");

            //            string line = Console.ReadLine();
            //            if (line.Contains("안녕"))
            //            {
            //                Console.WriteLine("안녕하세요...!");
            //            }
            //            else
            //            {
            //                Console.WriteLine("^^");
            //            }
            //        }
            //    }
            //}
            //            Console.WriteLine("출력");
            //            Console.WriteLine("출력");
            //            Console.WriteLine("출력");
            //            Console.WriteLine("출력");
            //            Console.WriteLine("출력");
            //        }
            //    }
            //}
            //            for (int i = 0; i < 1000; i++)
            //            {
            //                Console.WriteLine("출력"); // for문  구조 1. 초기화 2. 조건 3. 반복구문 4. 증감 
            //            }
            //        }
            //    }
            //}
            //int[] intArray = { 52, 273, 32, 65, 103 };
            //            Console.WriteLine(intArray[0]);
            //            Console.WriteLine(intArray[1]);
            //            Console.WriteLine(intArray[2]);
            //            Console.WriteLine(intArray[3]);
            //            Console.WriteLine(intArray[4]);
            //        }
            //    }
            //}
            //            int[] array = new int[100];
            //            for (int i = 0; i < array.Length; i++)
            //            {
            //                array[i] = i;
            //            }
            //            for (int i = 0; i < array.Length; i++)
            //            {
            //                Console.WriteLine(array[i]);
            //            }
            //        }
            //    }
            //}
            //            int[] intArray = { 52, 273, 32, 65, 103 };
            //            int cnt = 0;

            //            while (cnt < intArray.Length)
            //            {
            //                Console.WriteLine(cnt + "번째 출력: " + intArray[cnt]);
            //                cnt++;
            //            }
            //        }
            //    }
            //}
            //            string[] array = { "사과", "배", "포도", "딸기", "바나나" };
            //            foreach (string item in array)
            //            {
            //                Console.WriteLine(item);
            //            }
            //        }
            //    }
            //}
            while (true)
            {
                Console.Write("숫자 입력(짝수입력시 종료): ");
                int input = int.Parse(Console.ReadLine());
                if (input % 2 == 0)
                {
                    break; // 반복을 아예 그만두는 것. * Continue는 현재 반복을 멈추고 다음 반복을 진행하는 것.
                }
            }
        }
    }
}
            