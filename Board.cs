using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MonopoLogic
{
    class Board 
    {
        //Sets initial block values, need to rewriting this.
        private static List<BlockObject> BlockList = new List<BlockObject>(40);
        public static void SetNewBlocks()
        {
            for (int i = 0; i < BlockList.Capacity; i++)
            {
                BlockObject _block = new BlockObject("block" + i, i);
                SetBlockValues(_block);
                BlockList.Add(_block);
            }
        }
        private static void SetBlockValues(BlockObject b)
        {
            switch (b.index)
            {
                case 0://Start
                    break;
                case 1://Brown1: 10 	30 	90 	160 	250
                    b.name = "Old Kent Road";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Brown;
                    b.costToBuy = 60;
                    b.rent = 2;
                    break;
                case 2://Chance
                    b.type = BlockObject.Type.Chance;
                    break;
                case 3://Brown2: 20 	60 	180 	320 	450
                    b.name = "Whitechapel Road";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Brown;
                    b.costToBuy = 60;
                    b.rent = 4;
                    break;
                case 4://Tax
                    b.name = "Tax";
                    b.type = BlockObject.Type.Util;
                    b.rent = 200;
                    break;
                case 5://Train (25 if 1 owned, 50 if 2 owned, 100 if 3 owned, 200 if all 4 owned)
                    b.name = "Kings Cross Station";
                    b.type = BlockObject.Type.Property;
                    b.costToBuy = 200;
                    break;
                case 6://Lightblue 1 30 	90 	270 	400 	550
                    b.name = "The Angel Islington";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Lightblue;
                    b.costToBuy = 100;
                    b.rent = 6;
                    break;
                case 7://Chance
                    b.type = BlockObject.Type.Chance;
                    break;
                case 8://Lightblue 2 30 	90 	270 	400 	550
                    b.name = "Euston Road";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Lightblue;
                    b.costToBuy = 100;
                    b.rent = 6;
                    break;
                case 9://Lightblue 3 40 	100 	300 	450 	600
                    b.name = "Pentonville Road";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Lightblue;
                    b.costToBuy = 120;
                    b.rent = 8;
                    break;
                case 10://In jail
                    b.type = BlockObject.Type.Jail;
                    break;
                case 11://Pink 1  50 	150 	450 	625 	750
                    b.name = "Highgarden";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Pink;
                    b.costToBuy = 140;
                    b.rent = 10;
                    break;
                case 12://ElectricityBill (4xdice if 1 owned, 10xdice if both owned)
                    b.name = "Electric Company";
                    b.type = BlockObject.Type.Util;
                    b.rent = 100;
                    break;
                case 13://Pink 2 50 	150 	450 	625 	750
                    b.name = "Whitehall";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Pink;
                    b.costToBuy = 140;
                    b.rent = 10;
                    break;
                case 14://Pink 3 60 	180 	500 	700 	900
                    b.name = "Northumberland Avenue";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Pink;
                    b.costToBuy = 160;
                    b.rent = 12;
                    break;
                case 15://Train (25 if 1 owned, 50 if 2 owned, 100 if 3 owned, 200 if all 4 owned)
                    b.name = "Bow Street";
                    b.type = BlockObject.Type.Property;
                    b.property = BlockObject.Property.Train;
                    b.costToBuy = 160;
                    b.rent = 25;
                    break;
                case 16://Orange 1 70 	200 	550 	750 	950
                    b.name = "King's Landing";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Orange;
                    b.costToBuy = 180;
                    b.rent = 14;
                    break;
                case 17:
                    b.type = BlockObject.Type.ComunityChest;
                    break;
                case 18://Orange 2 70 	200 	550 	750 	950
                    b.name = "Marlborough Street";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Orange;
                    b.costToBuy = 180;
                    b.rent = 14;
                    break;
                case 19://Orange 3 80 	220 	600 	800 	1000
                    b.name = "Vine Street";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Orange;
                    b.costToBuy = 200;
                    b.rent = 16;
                    break;
                case 20:
                    b.type = BlockObject.Type.FreeParking;
                    break;
                case 21://Red 1 90 	250 	700 	875 	1050
                    b.name = "The Strand";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Red;
                    b.costToBuy = 220;
                    b.rent = 18;
                    break;
                case 22:
                    b.type = BlockObject.Type.Chance;
                    break;
                case 23://Red 2 90 	250 	700 	875 	1050
                    b.name = "Ashemark";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Red;
                    b.costToBuy = 220;
                    b.rent = 18;
                    break;
                case 24://Red 3 100 	300 	750 	925 	1100
                    b.name = "Golden Tooth";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Red;
                    b.costToBuy = 240;
                    b.rent = 20;
                    break;
                case 25://Train 25 if 1 owned, 50 if 2 owned, 100 if 3 owned, 200 if all 4 owned 	
                    b.name = "Fenchurch St Station";
                    b.type = BlockObject.Type.Property;
                    b.costToBuy = 200;
                    break;
                case 26://Yellow 1 110 	330 	800 	975 	1150
                    b.name = "Leicester Square";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Yellow;
                    b.costToBuy = 260;
                    b.rent = 22;
                    break;
                case 27://Yellow 2 110 	330 	800 	975 	1150
                    b.name = "Coventry Street";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Yellow;
                    b.costToBuy = 260;
                    b.rent = 22;
                    break;
                case 28://WaterWorks
                    b.name = "Water Bill";
                    b.type = BlockObject.Type.Util;
                    b.rent = 100;
                    break;
                case 29://Yellow 3 120 	360 	850 	1025 	1200
                    b.name = "Piccadilly";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Yellow;
                    b.costToBuy = 250;
                    b.rent = 24;
                    break;
                case 30://Go To Jail!
                    b.type = BlockObject.Type.Jail;
                    break;
                case 31://Green 1 130 	390 	900 	1100 	1275
                    b.name = "Regent Street";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Green;
                    b.costToBuy = 300;
                    b.rent = 26;
                    break;
                case 32://Green 2 130 	390 	900 	1100 	1275
                    b.name = "Oxford Street";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Green;
                    b.costToBuy = 300;
                    b.rent = 26;
                    break;
                case 33:
                    b.type = BlockObject.Type.ComunityChest;
                    break;
                case 34://Green 3 150 	450 	1000 	1200 	1400
                    b.name = "Bond Street";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Green;
                    b.costToBuy = 320;
                    b.rent = 28;
                    break;
                case 35://Train 25 if 1 owned, 50 if 2 owned, 100 if 3 owned, 200 if all 4 owned
                    b.name = "Liverpool Street Station";
                    b.type = BlockObject.Type.Property;
                    b.property = BlockObject.Property.Train;
                    b.costToBuy = 200;
                    break;
                case 36://Chance
                    b.type = BlockObject.Type.Chance;
                    break;
                case 37://Blue 1  175 	500 	1100 	1300 	1500
                    b.name = "Park Lane";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Blue;
                    b.costToBuy = 350;
                    b.rent = 35;
                    break;
                case 38://Tax
                    b.name = "Super Tax";
                    b.type = BlockObject.Type.Util;
                    b.rent = 250;
                    break;
                case 39://Blue 2  200 	600 	1400 	1700 	2000
                    b.name = "Mayfair";
                    b.type = BlockObject.Type.Property;
                    b.color = BlockObject.Color.Blue;
                    b.costToBuy = 400;
                    b.rent = 50;
                    break;
            }
        }

        //Call block based in index
        public static BlockObject CallBlock(int p)
        {
           return BlockList[p];            
        }

    }

    class BlockObject
    {
        public enum Type { Property, ComunityChest, Chance, FreeParking, Jail, Util };
        public Type type;
        public enum Property { Plot, House, Hotel, Train };
        public Property property;
        public enum Color { None , Brown, Lightblue, Pink, Orange, Red, Yellow, Green, Blue };
        public Color color;

        public int index;
        public string name;    
        public string ownerName;
        public int ownerIndex;
        public int costToBuy;
        public int costToSell;
        public int rent;
        public int payOut;
        public bool owned = false;

        public BlockObject(string n, int i)
        {
            this.name = n;
            this.index = i;
        }
        
        public void SetRent(int i)
        {
            this.rent = i;
        }


        public void SetOwner(PlayerObject p)
        {
            this.ownerName = p.name;
            this.SetRent(this.costToBuy / 10);            
            this.owned = true;
            this.ownerIndex = p.index;
            this.ownerName = p.name;
            this.costToSell = this.costToBuy / 2;
            p.gold -= this.costToBuy;

            Console.WriteLine($"Buying{this.name} - {this.color}");
            switch (this.color)
            {
                case BlockObject.Color.Brown:
                    p.colorI["Brown"]++;
                    break;
                case BlockObject.Color.Lightblue:
                    p.colorI["Lightblue"]++;
                    break;
                case BlockObject.Color.Pink:
                    p.colorI["Pink"]++;
                    break;
                case BlockObject.Color.Orange:
                    p.colorI["Orange"]++;
                    break;
                case BlockObject.Color.Red:
                    p.colorI["Red"]++;
                    break;
                case BlockObject.Color.Yellow:
                    p.colorI["Yellow"]++;
                    break;
                case BlockObject.Color.Blue:
                    p.colorI["Blue"]++;
                    break;
            }
        }

    }
}

        
