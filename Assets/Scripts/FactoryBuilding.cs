using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using UnityEngine;



    class FactoryBuilding : Building
    {
        protected string unitsProduced;

        public string propUnitsProd
        {
            get
            {
                return unitsProduced;
            }

            set
            {
                unitsProduced = value;
            }
        }

        protected int spawnX;

        public int propSpawnX
        {
            get
            {
                return spawnX;
            }

            set
            {
                spawnX = value;
            }
        }

        protected int spawnY;

        public int propSpawnY
        {
            get
            {
                return spawnY;
            }

            set
            {
                spawnY = value;
            }
        }

        protected char meleeUnitSym;

        public char propMeleeSym
        {
            get
            {
                return meleeUnitSym;
            }

            set
            {
                meleeUnitSym = value;
            }
        }

        protected char rangeUnitSym;

        public char propRangeSym
        {
            get
            {
                return rangeUnitSym;
            }

            set
            {
                rangeUnitSym = value;
            }
        }

        

        

        //the speed variable acts as production rate

        


        

        public FactoryBuilding(string unitsProd,int health ,char team, char symbol, int spX, int spY) : base(5)
        {
            this.propBuildingType = "Factory";
            this.propUnitsProd = unitsProd;
            this.propSpawnX = spX;
            this.propSpawnY = spY;
            this.propHp = health;
            this.propFaction = team;
            this.propSymbol = symbol;
            unitSymChoice();
        }

        public override bool isDead()
        {
            bool ded = false;
            if (this.propHp <= 0)
            {
                ded = true;
            }
            return ded;
        }

        public void unitSymChoice()             // decides the symbol used by produced units
        {
            if(this.propFaction == 'R')
            {
                this.propMeleeSym = 'M';
                this.propRangeSym = 'A';
            }
            else
            {
                if(this.propFaction == 'B')
                {
                    this.propMeleeSym = 'm';
                    this.propRangeSym = 'a';
                }
            }
        }

        public override string toString()
        {
            string info = "This is a Factory Building that Produces " + this.propUnitsProd + " Units For The " + this.propFaction + " Faction. It has " + this.propHp + " HP left";
            Console.WriteLine(info);
            return info; 
        }

        public override string saveString()
        {
            string saveInfo = this.propUnitsProd + "," + this.propHp + "," + this.propFaction + "," + this.propSymbol + "," + this.propPosX + "," + this.propPosY + "," + this.propSpawnX + "," + this.propSpawnY;
            return saveInfo;
        }

        public override Unit generateUnit()     // Unit generator method
        {
            Unit newUnit = new MeleeUnit(0, 't', '.');
            switch(this.propUnitsProd)
            {
                case "Melee":
                    newUnit = new MeleeUnit(100, this.propFaction, this.propMeleeSym);
                    newUnit.propX = this.spawnX; newUnit.propY = this.spawnY;
                    Console.WriteLine("Spawned new melee unit for Faction :" + this.propFaction);
                    break;
                case "Ranged":
                    newUnit = new RangedUnit(60, this.propFaction, this.propRangeSym);
                    newUnit.propX = this.spawnX; newUnit.propY = this.spawnY;
                    Console.WriteLine("Spawned new ranged unit for Faction :" + this.propFaction);
                    break;
            }
            return newUnit;
        }

        public override void generateResource()
        {
            Console.WriteLine("This AINT No Resource Building");  //never gonna be used
        }

     

    }

