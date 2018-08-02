using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MonopoLogic
{
    class Bank
    {
        //Shit is pretty self explanatory here

        public static int BanksGold = 2147483647;
        public static int ComunityChest;

        public static void PayBank(PlayerObject p, int debit)
        {
            p.gold -= debit;
            BanksGold += debit;
        }
        public static void ChargeBank(PlayerObject p, int credit)
        {
            p.gold += credit;
            BanksGold -= credit;
        }
        public static void PayPlayer(PlayerObject p, int amount)
        {
            p.gold += amount;
        }
        public static void ChargePlayer(PlayerObject p, int i)
        {
            p.gold -= i;
        }
    }
}