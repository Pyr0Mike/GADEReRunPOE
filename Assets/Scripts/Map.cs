using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using UnityEngine;



    class Map
    {
       /* protected char[,] mapArray = new char[20, 20];

        public char[,] propMapArray
        {
            get
            {
                return mapArray;        // not needed anymore
            }

            set
            {
                mapArray = value;
            }
        }*/

        protected Unit[] unitArray;

        public Unit[] propUnitArray
        {
            get
            {
                return unitArray;
            }

            set
            {
                unitArray = value;
            }
        }

        protected Building[] buildArray;

        public Building[] propBuildArray
        {
            get
            {
                return buildArray;
            }

            set
            {
                buildArray = value;
            }
        }



        System.Random rng;// = new Random();

        public Map() //constructor
        {
            rng = new System.Random();

            propUnitArray = new Unit[10];
            propBuildArray = new Building[6];
            generateUnits(propUnitArray);
            populateBuildArray();
           // updateMap();

        }

        public void populateBuildArray()         //produces buildings.           locations are predecided
        {
            propBuildArray[0] = new ResourceBuilding("redResource",300, 300, 'R', 'S', "Iron", 2, 100);
            propBuildArray[0].propPosX = 10; propBuildArray[0].propPosY = 0;

            propBuildArray[1] = new ResourceBuilding("blueResource",300, 300, 'B', 'Q', "Iron", 2, 100);
            propBuildArray[1].propPosX = 10; propBuildArray[1].propPosY = 19;

            propBuildArray[2] = new FactoryBuilding("redFactory" ,"Melee", 300, 300, 'R', 'H', 1, 1);
            propBuildArray[2].propPosX = 0; propBuildArray[2].propPosY = 0;

            propBuildArray[3] = new FactoryBuilding("redFactory","Ranged", 300, 300, 'R', 'H', 18, 1);
            propBuildArray[3].propPosX = 19; propBuildArray[3].propPosY = 0;

            propBuildArray[4] = new FactoryBuilding("blueFactory" ,"Melee", 300, 300, 'B', 'T', 18, 18);
            propBuildArray[4].propPosX = 19; propBuildArray[4].propPosY = 19;

            propBuildArray[5] = new FactoryBuilding("blueFactory" ,"Ranged", 300, 300, 'B', 'T', 1, 18);
            propBuildArray[5].propPosX = 0; propBuildArray[5].propPosY = 19;
        }

     

        public void generateUnits(Unit[] arrayOfUnits) //method to generate units in the array
        {
            int i;
            for( i = 0; i < 10; i++ )
            {
                int unitRoll = rng.Next(1, 5);
                switch(unitRoll)                                     //deciding each units type and faction
                {
                    case 1:
                        arrayOfUnits[i] = new MeleeUnit("redKnight" ,100,'R', 'M');      
                        break;
                    case 2:
                        arrayOfUnits[i] = new RangedUnit("redArcher" ,60, 'R', 'A');
                        break;
                    case 3:
                        arrayOfUnits[i] = new MeleeUnit("blueKnight" ,100,'B', 'm');
                        break;
                    case 4:
                        arrayOfUnits[i] = new RangedUnit("blueArcher",60, 'B', 'a');
                        break;
                }

                arrayOfUnits[i].propX = rng.Next(0, 20);  //deciding the units starting x and y positions
                arrayOfUnits[i].propY = rng.Next(0, 20);

                int factionRoll = rng.Next(1, 3);

                
                
            }
        }

       /* public void updateMap()  //method to update the map array
        {
            int k;
            int l;
            
            for(k = 0; k < 20; k++)     
            {

                for(l = 0; l < 20; l++)
                {
                    propMapArray[k, l] = '.';
                }

            }

            foreach( Unit merc in propUnitArray)
            {
                propMapArray[merc.propX, merc.propY] = merc.propSymbol;
            }

            foreach( Building tower in propBuildArray)
            {
                propMapArray[tower.propPosX, tower.propPosY] = tower.propSymbol;        // not needed anymore
            }
        }

        public string drawMap()
        {
            string mapString = "";
            int k;
            int l;
            for(k = 0; k < 20; k++)
            {

                for(l = 0; l < 20; l++)
                {
                    mapString += propMapArray[k, l]; 
                }
                mapString += "\n";

            }

            return mapString;
        }*/



        
    }

