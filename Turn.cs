using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MonopoLogic
{
    // * <- simulating player interaction for now
    class Turn
    {
        public Turn(PlayerObject _player)
        {
            Thread.Sleep(1000);
            MovePlayer(_player);
            PlayBlock(Board.CallBlock(_player.position), _player);
        }
        
        //This is player roll and move
        private int _r = 0;
        private int a = 0;
        private int b = 0;
        private int _spaces = 0;
        private Random _roll = new Random();
        private void MovePlayer(PlayerObject p)
        {
            _Roll();
            while (a == b)
            {
                //p.badluck--;
                SetPos(p, _spaces);
                Console.WriteLine($"|{a}|{b}| Doubles Roll again...");
                _r++;
                if (_r == 3)
                {
                    _spaces = 0;
                    Console.WriteLine("Go back to JAIL!...");
                    p.position = 10;
                    _r = 0;
                }
                else
                    _Roll();
            }
            //if (_r == 0 && _spaces > 3)
            //{
            //    p.badluck++;
            //}
            //if (p.badluck > 10 && p.trips == 1)
            //{
            //    _spaces += 4;
            //    p.badluck = 0;
            //}
            //if (p.badluck > 10 && p.trips == 2)
            //{
            //    _spaces += 2;
            //    p.badluck = 0;
            //}
            SetPos(p, _spaces);
        }
        //Set players position based on roll results 
        private void SetPos(PlayerObject p, int _s)
        {
            p.position += _s;
            if (p.position >= 40)
            {
                p.position -= 40;
                p.trips++;
                Bank.PayPlayer(p, 200);
            }
            Console.WriteLine($"Name:        {p.name}       ");
            Console.WriteLine($"Gold:        {p.gold}       ");
            Console.WriteLine($"roll:        {_s}           ");
            Console.WriteLine($"badluck:     {p.badluck}    ");
            Console.WriteLine($"position:    {p.position}   ");
            Console.WriteLine($"trip:        {p.trips}      ");
            Console.WriteLine();
            foreach (KeyValuePair<string, int> col in p.colorI)
                Console.WriteLine($"{col.Key} {col.Value}");
            Console.WriteLine("--------------------------------------------------------------");
        }
        private void _Roll()
        {
            a = _roll.Next(6);
            b = _roll.Next(6);
            int[] one = new int[6] { 1, 2, 3, 4, 5, 6 };
            int[] two = new int[6] { 1, 2, 3, 4, 5, 6 };
            _spaces = (one[a] + two[b]);
        }
                
        //call block that player lands on / do shit
        private void PlayBlock(BlockObject b, PlayerObject p)
        {
            switch (b.type)
            {
                case BlockObject.Type.Property:
                    Console.WriteLine($"You landed on Block:{b.index} || {b.name}");
                    if (b.owned == false)
                    {
                        //Console.WriteLine($"Type 'y' to buy for {b.costToBuy} Gold");
                        //if (a == "y" || a == "Y")
                        //{
                        b.SetOwner(p);
                        //set rent
                        //Console.WriteLine($"you will get {b.rent} gold when a player lands here");
                        //}
                    }
                    else
                    {
                        if (b.ownerIndex != p.index)
                        {
                            Console.WriteLine($"{b.ownerName} Owns this place");
                            Console.WriteLine($"Rent:{b.rent}");
                            switch (b.property)
                            {
                                case BlockObject.Property.Plot:
                                    p.gold -= b.rent;
                                    Bank.PayPlayer(Players.CallPlayer(b.ownerIndex), b.rent);
                                    break;
                                case BlockObject.Property.Train:
                                    break;
                            }
                        }
                        else
                            Console.WriteLine("You own this place move do somthing or gtfo...");
                    }
                    break;
                case BlockObject.Type.Chance:// *
                    Console.WriteLine("Chance. Pick a card!");
                    break;
                case BlockObject.Type.ComunityChest:// *
                    Console.WriteLine("ComunityChest. Pick a card!");
                    break;
                case BlockObject.Type.Util:
                    Console.WriteLine($"Pay your {b.name}:{b.rent}");
                    Bank.PayBank(p, b.rent);
                    break;
                case BlockObject.Type.FreeParking:
                    Console.WriteLine($"Take all gold in ComunityChest : {Bank.ComunityChest} Gold");
                    p.gold += Bank.ComunityChest;
                    Bank.ComunityChest = 0; 
                    break;
            }
        }
        //Place holder logic to set ownership, im sure there is a better way to do this.
        //private void SetOwner(PlayerObject p, BlockObject b)
        //{
        //    p.gold -= b.costToBuy;
        //    b.owned = true;
        //    b.ownerIndex = p.index;
        //    b.ownerName = p.name;
        //    Console.WriteLine($"Buying {b.color}");
        //    switch (b.color)
        //    {
        //        case BlockObject.Color.Brown:
        //            p.colorI["Brown"]++;
        //            break;
        //        case BlockObject.Color.Lightblue:
        //            p.colorI["Lightblue"]++;
        //            break;
        //        case BlockObject.Color.Pink:
        //            p.colorI["Pink"]++;
        //            break;
        //        case BlockObject.Color.Orange:
        //            p.colorI["Orange"]++;
        //            break;
        //        case BlockObject.Color.Red:
        //            p.colorI["Red"]++;
        //            break;
        //        case BlockObject.Color.Yellow:
        //            p.colorI["Yellow"]++;
        //            break;
        //        case BlockObject.Color.Blue:
        //            p.colorI["Blue"]++;
        //            break;
        //    }
        //}
    }
}