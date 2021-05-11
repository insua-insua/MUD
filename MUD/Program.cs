using System;
using System.Collections.Generic;

namespace MUD
{
    class Program
    {
        static void Main()
        {
            // 플레이어 이름 자동생성
            string playerRandomName = SetRandomPlayerName();

            // 환영합니다
            Console.WriteLine($"환영합니다 {playerRandomName}님!\n");


            // 플레이어 능력치 입력. power, hp
            Console.WriteLine($"공격력을 입력해주세요");
            string userPower = Console.ReadLine();
            int power = int.Parse(userPower);

            Console.WriteLine($"HP를 입력해주세요");
            string userHP = Console.ReadLine();
            int hp = int.Parse(userHP);

            Player player = new Player(playerRandomName, power, hp);


            // 몬스터 공격
            Monster monster = new Monster();
            monster.hp -= player.power;
        }

        private static string SetRandomPlayerName()
        {
            List<string> names = new List<string>();
            Dictionary<string, string> nameMap = new Dictionary<string, string>();
            nameMap["레드"] = "권투사";
            nameMap["블루"] = "검사";
            nameMap["퍼플"] = "마법사";
            nameMap["그린"] = "성기사";
            nameMap["블랙"] = "궁사";

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

 
