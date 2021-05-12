using System;

namespace MUD
{
    public class Player
    {
        public string DisplayName
        {
            get { return $"({playerJop} {playerName}님)"; }
        }

        public string playerName;
        public string playerJop;
        public int power;
        public int hp;
        int maxHp = 10;

        public Player(string playerName, string playerJop, int power, int _hp)
        {
           
            this.playerName = playerName;
            
            this.playerJop = playerJop;

            this.power = power;
            maxHp = _hp;
            this.hp = maxHp;
        }
        internal void RestoreHp()
        {
            if (hp < maxHp)
                hp++;
        }
    }
}
