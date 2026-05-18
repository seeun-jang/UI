using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI03.test
{
    class FirstClass { }

    class SecondClass { }

    internal class Program
    {
        static void Main(string[] args)
        {
            FirstClass myClass = new FirstClass();
            SecondClass mySecondClass = new SecondClass();
            ThirdClass myThirdClass = new ThirdClass();
            {

            }
        }
    }
}
            //string input = "Potato Tomato";
            //Console.WriteLine(input.ToUpper());
            //Console.WriteLine(input.ToLower());

//Console.WriteLine(input);


//            // 문자열 자르기 
//            String input = "감자 고구마 토마토";
//            string[] output = input.Split(' ');

//            for (int i = 0; i < output.Length; i++)
//            {
//                Console.WriteLine(output[i]);
//            }
//        }
//    }
//}

// 배열을 문자열로 변환
//            string[] array = { "감자", "고구마", "토마토" };
//            Console.WriteLine(string.Join("----", array));
//        }
//    }
//}

// 특정 시간 만큼 스레드 정지
//            string[] array = { "Girl", "you", "can", "do", "it", "!"};

//            for (int i = 0; i < array.Length; i++)
//            {
//                Console.WriteLine(array[i]);
//                Thread.Sleep(1000);
//            }
//        }
//    }
//}

//  switch문과 반복문
//            bool state = true;

//            while (state)
//            {
//                ConsoleKeyInfo info = Console.ReadKey();
//                switch (info.Key)
//                {
//                    case ConsoleKey.UpArrow:
//                        Console.WriteLine("위로");
//                        break;
//                    case ConsoleKey.RightArrow:
//                        Console.WriteLine("우로");
//                        break;
//                    case ConsoleKey.LeftArrow:
//                        Console.WriteLine("좌로");
//                        break;
//                    case ConsoleKey.DownArrow:
//                        Console.WriteLine("아래로");
//                        break;
//                    case ConsoleKey.X:
//                        state = false;
//                        break;
//                }
//            }
//        }
//    }
//}

// Random 클래스를 이용한 정수 생성
//Random random = new Random();
//Random random2 = new Random();

//Console.WriteLine(random.Next());
//Console.WriteLine(random2.Next());

//Random rnd = new Random();
//Console.WriteLine(rnd.Next());
// 로또 번호 추천 1 - 45 5개 중복 허용 
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine(rnd.Next(1, 46));
//}

//            int j = 0;
//            while (j < 6)
//            {
//                Console.WriteLine(rnd.Next(1, 46));
//                j++;
//            }
//        }
//    }
//}

// Random 클래스를 이용한 실수(0.0~1.0) 생성
//            Random random = new Random();

//            Console.WriteLine(random.NextDouble());
//            Console.WriteLine(random.NextDouble());
//            Console.WriteLine(random.NextDouble());
//            Console.WriteLine(random.NextDouble());
//            Console.WriteLine(random.NextDouble());
//        }
//    }
//}
//            Random random = new Random();

//            for (int i = 0; i < 6; i++)
//            {
//                int num = random.Next(0, 10);
//                double num2 = random.NextDouble();
//                Console.WriteLine(num + num2);
//                Console.WriteLine(random.NextDouble() * 10);
//            }
//        }
//    }
//}

//            // List 요소 제거 
//            List<int> list = new List<int>();
//            list.Add(52);
//            list.Add(273);
//            list.Add(32);
//            list.Add(64);
//            Random random = new Random();
//            for (int i = 0; i < 100; i++)
//            {
//                list.Add(random.Next(500));
//                list.RemoveAt(0);
//                Console.WriteLine("Count : " + list.Count + "\t Item : " + list[0]);
//            }
//        }
//    }
//}

//list.RemoveAt(0);
//foreach (var item in list)
//{
//    Console.WriteLine("Count: " + list.Count + "\t Item: " + item);
//}
//        }
//    }
//}


