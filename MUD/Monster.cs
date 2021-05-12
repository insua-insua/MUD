using System;

namespace MUD
{
    public class Monster
    {
        static Random random = new Random();

        public string name;
        public int power;
        public int hp;


        public Monster(int dungeonLevel)
        {

        }

        internal void OnAttack(Player player)
        {
            
        }
    }

    public class PinkSlime : Monster
    {
        public PinkSlime(int dungeonLevel) : base(dungeonLevel)
        {
            name = "핑크 슬라임";
            power += dungeonLevel;
        }
        virtual public void OnAttack(Player targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 공격으로 {targetPlayer.playerName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }
    public class YellowSlime : Monster
    {
        public YellowSlime(int dungeonLevel) : base(dungeonLevel)
        {
            name = "옐로우 슬라임";
            power += dungeonLevel;
        }
        virtual public void OnAttack(Player targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 공격으로 {targetPlayer.playerName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }
    public class LavenderSlime : Monster
    {
        public LavenderSlime(int dungeonLevel) : base(dungeonLevel)
        {
            name = "라벤더 슬라임";
            power += dungeonLevel;
        }
        virtual public void OnAttack(Player targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 공격으로 {targetPlayer.playerName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }
    public class CharcoalSlime : Monster
    {
        public CharcoalSlime(int dungeonLevel) : base(dungeonLevel)
        {
            name = "차콜 슬라임";
            power += dungeonLevel;
        }
        virtual public void OnAttack(Player targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 공격으로 {targetPlayer.playerName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }
}
