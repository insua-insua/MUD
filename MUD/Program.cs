using System;
using System.Collections.Generic;

namespace MUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("슬라임 사냥 Ver0.1\n");

            bool quit = false;
            do
            {
                Player player = MakePlayer();

                Console.WriteLine("");
                Console.WriteLine("탐험을 시작합니다. Press any key");
                Console.ReadKey(); 

                quit = ProcessBattle(player);

            } while (quit == false);
        }

        private static Player MakePlayer()
        {
            bool isReset = true;
            int power = 0, hp = 0;
            string playerRandomName = SetRandomPlayerName();
            string playerRandomJop = SetRandomPlayerJop();

            while (isReset)
            {
                Random random = new Random();

                Console.WriteLine($"환영합니다. {playerRandomName}님.\n");

                power = random.Next(5, 10);
                hp = random.Next(5, 10);
                Console.WriteLine($"{playerRandomName}님. {playerRandomName}님은 {playerRandomJop}이며, 공격력:{power}, 체력:{hp} 입니다. 다시 생성 하시겠습니까? (Y/N)\n");
                string resetAnswer = Console.ReadLine();
                isReset = resetAnswer.ToLower() == "y";
            };

            Player player = new Player(playerRandomName, playerRandomJop, power, hp);

            return player;
        }

       
        private static bool ProcessBattle(Player player)
        {
            int dungeonLevel = 1;

            do
            {
                Random random = new Random();

                int monsterCount = random.Next(1, 3);
                List<Monster> monsters = new List<Monster>();
                for (int i = 0; i < monsterCount; i++)
                {
                    monsters.Add(new Monster(dungeonLevel));
                }

                Console.WriteLine($"슬라임 {monsters.Count}마리를 만났습니다.");


                while (monsters.Count > 0)
                {
                    foreach (var m in monsters)
                    {
                        Console.WriteLine($"{m.name} 공격력:{m.power}, 체력:{m.hp}");
                    }

                    Console.WriteLine($"{player.DisplayName} 공격력:{player.power}, 체력:{player.hp}");

                    PlayerTurn(player, monsters);

                    MonsterTurn(player, monsters);

                    if (player.hp <= 0)
                    {
                        Console.WriteLine($"{player.DisplayName}는 고작 슬라임에게 졌습니다. 처음부터 다시 하시겠습니까? (Y/N)");

                        bool isQuit = GetAllowedAnswer("y", "n") == "n";
                        return isQuit;
                    }
                }

                Console.WriteLine($"슬라임 사냥을 종료하시겠습니까? (Y/N)");
                if (GetAllowedAnswer("y", "n") == "y")
                {
                    return true;
                }

                dungeonLevel++;

            } while (true);
        }

        private static void MonsterTurn(Player player, List<Monster> monsters)
        {
            Console.WriteLine("");

            MonsterAttackToPlayer(player, monsters);
        }

        private static void PlayerTurn(Player player, List<Monster> monsters)
        {
            Console.WriteLine("");
            Console.WriteLine("1:공격, 2:회복, 3:도망");
            char userInput = GetAllowedAnswer("1", "2", "3")[0];
            switch (userInput)
            {
                case '1':// 공격
                    PlayerAttack(player, monsters);
                    break;
                case '2': // 회복
                    player.RestoreHp();
                    break;
                case '3': // 도망.
                    bool successRun = TryRun();
                    break;
                default:
                    Console.WriteLine("없는 명령어 입니다" + userInput);
                    break;
            }
        }

        private static void MonsterAttackToPlayer(Player player, List<Monster> monsters)
        {
            Console.WriteLine("슬라임들이 플레이어 공격");
            foreach (var m in monsters)
            {
                m.OnAttack(player);
            }
        }

        private static void PlayerAttack(Player player, List<Monster> monsters)
        {
            Console.WriteLine("\n공격할 슬라임을 선택하세요");

            List<string> allowedAnswer = new List<string>();
            for (int i = 0; i < monsters.Count; i++)
            {
                var m = monsters[i];
                int monsterNumber = i + 1;
                Console.WriteLine($"{monsterNumber} : {m.name} 공격력:{m.power}, 체력:{m.hp}");

                allowedAnswer.Add(monsterNumber.ToString());
            }


            int selected;

            string userInput = GetAllowedAnswer(allowedAnswer.ToArray());

            selected = int.Parse(userInput) - 1;

            var selectedMonster = monsters[selected];
            selectedMonster.hp -= player.power;

            Console.WriteLine($"{selectedMonster.name}의 체력이 {selectedMonster.hp}가 되었다");

            
            if (selectedMonster.hp <= 0)
            {
                Console.WriteLine($"{selectedMonster.name}이 패배했다.");
                monsters.Remove(selectedMonster);

            }
        }

        private static bool TryRun()
        {
            Random random = new Random();

            int result = random.Next(0, 10);
            bool successRun = result > 3;
            return successRun;
        }

        private static string GetAllowedAnswer(params string[] alllowsAnserStringArray)
        {
            string retryOrQuit;
            List<string> allowedAnswer = new List<string>(alllowsAnserStringArray);
            do
            {
                retryOrQuit = Console.ReadLine().ToUpper();
            } while (allowedAnswer.Contains(retryOrQuit) == false);
            return retryOrQuit;
        }

        private static string SetRandomPlayerJop()
        {
           List<string> jops = new List<string>();
           jops.Add("권사");
           jops.Add("검사");
           jops.Add("마법사");
           jops.Add("성기사");
           jops.Add("궁사");
    
           Random random = new Random();

           int index = random.Next(jops.Count);
           string playerjop = jops[index];
           return playerjop;
        }

        private static string SetRandomPlayerName()
        {
           List<string> names = new List<string>();
           names.Add("레드");
           names.Add("블루");
           names.Add("퍼플");
           names.Add("그린");
           names.Add("블랙");
            

           Random random = new Random();

           int index = random.Next(names.Count);
           string playerName = names[index];
           return playerName;
        }
    }
}

 
