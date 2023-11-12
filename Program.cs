﻿namespace IndividualTask
{
    internal class Program
    {
        private static Character player;
        private static Item weapon1;
        private static Item weapon2;


        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
            DisplayInventory();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            weapon1 = new Item("무쇠갑옷",5, "무쇠로 만들어져 튼튼한 갑옷입니다.");
            weapon2 = new Item("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.");
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.\n >>");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    // 작업해보기
                    DisplayInventory();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("상태보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.\n >>");


            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static void DisplayInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.Write($"-{weapon1.ItemName}    ");
            Console.Write($"|방어력 +{weapon1.ItemStats}| ");
            Console.Write($"{weapon1.ItemDescription}");
            Console.WriteLine();
            Console.Write($"-{weapon2.ItemName}    ");
            Console.Write($"|공격력 +{weapon2.ItemStats}| ");
            Console.Write($"{weapon2.ItemDescription}");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.\n >>");


            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    Console.WriteLine("[E]"); 
                    break;
                    
                
         
            }
        }

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Item
    {
        public string ItemName { get; } //프로퍼티, get 접근자 -필드를 반환하거나 다른 로직 수행
        public int ItemStats { get; set; } //프로퍼티, set 접근자 -필드에 값을 설정하거나 다른 로직 수행
        public string ItemDescription { get; }
        public Item(string iname, int istats, string idescription) //아이템 클래스와 객체
        {
            ItemName = iname;
            ItemStats = istats;
            ItemDescription = idescription;

        }
    }

}

