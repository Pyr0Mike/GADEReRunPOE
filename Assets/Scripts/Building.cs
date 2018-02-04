using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using UnityEngine;



    abstract class Building : MonoBehaviour
    {

    protected string buildPicName;

    public string propBuildPicName
    {
        get
        {
            return buildPicName;
        }

        set
        {
            buildPicName = value;
        }
    }

    protected string buildingType;

        public string propBuildingType
        {
            get
            {
                return buildingType;
            }

            set
            {
                buildingType = value;
            }
        }

        protected int posX;

        public int propPosX           //variables and properties
        {
            get
            {
                return posX;
            }

            set
            {
                posX = value;
            }
        }

        protected int posY;

        public int propPosY
        {
            get
            {
                return posY;
            }

            set
            {
                posY = value;
            }
        }

        protected int hp;

        public int propHp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

    int maxHp;

    public int propMaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }


    protected char faction;

        public char propFaction
        {
            get
            {
                return faction;
            }

            set
            {
                faction = value;
            }
        }

        protected char symbol;

        public char propSymbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
            }
        }

        int speed;

        public int propSpeed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
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

    

    public Building(int sped)            //constructor
        {
            
            this.propSpeed = sped;
        }

        public abstract bool isDead();

        public abstract string toString();

        public abstract string saveString();

        public abstract Unit generateUnit();

        public abstract void generateResource();

        

        

        

        



        
    }

