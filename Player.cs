using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Logic
{
    class Players
    {
        private static int count;//Track turns
        private static int NumOfPlayers = 2;//set playercount
        private static List<PlayerObject> PlayerList = new List<PlayerObject>(NumOfPlayers);//list of players
        
        //makeshift* need to listen for client setPlayers based on init player count set on server
        public static void SetNewPlayers()
        {
            for (int i = 0; i < PlayerList.Capacity; i++)
            {
                Console.Write($"Player {PlayerList.Count + 1}: Please type a name:");
                PlayerList.Add(new PlayerObject(Console.ReadLine(), i));
            }
        }
        
        //Checks and retuens for next turn
        public static PlayerObject CheckTurn()
        {
            if (count > Players.NumOfPlayers - 1)
                count = 0;
            PlayerObject _curPlayer = Players.PlayerList[count];
            count++;
            return _curPlayer;
        }
        
        //Call a player, based on index
        public static PlayerObject CallPlayer(int i)
        {
            return PlayerList[i];
        }
    }

    //Player Object Template
    public class PlayerObject
    {
        public string name;
        public int position;
        public int gold;
        public double badluck;
        public int trips;
        public int index;
        public int trainsOwned;

        public Dictionary<string, int> colorI = new Dictionary<string, int>()
        {
            ["Brown"] = 0,
            ["Lightblue"] = 0,
            ["Pink"] = 0,
            ["Orange"] = 0,
            ["Red"] = 0,
            ["Yellow"] = 0,
            ["Green"] = 0,
            ["Blue"] = 0
        };

        public PlayerObject(string n, int i)
        {
            name = n;
            position = 0;
            gold = 1600;
            badluck = 0;
            trips = 0;
            index = i;            
        }
    }
}