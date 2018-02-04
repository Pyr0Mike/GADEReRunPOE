using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using UnityEngine;



    abstract class Unit : MonoBehaviour
    {

    protected string picName;

    public string propPicName
    {
        get
        {
            return picName;
        }

        set
        {
            picName = value;
        }
    }


    protected string name;

        public string propName
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }



        protected int maxHp;

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

        

        protected int hp;                           //variables and properties

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

        protected int x;

        public int propX
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        protected int y;

        public int propY
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        protected int attack;

        public int propAttack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
            }
        }

        protected int range;

        public int propRange
        {
            get
            {
                return range;
            }

            set
            {
                range = value;
            }
        }

        protected int speed;

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

    

    public System.Random rando;// = new Random();

        

        public Unit(int maxhealth, int atk, int distRange, int sped) //constructor
        {
            rando = new System.Random();
            propMaxHp = maxhealth;
            
            propAttack = atk;
            propRange = distRange;
            propSpeed = sped;
            
        }

        

        public abstract string nameSelect();

        

        public abstract void move(string direction);          //Methods

        public abstract void combat(Unit enemy);

        public abstract void combatBuilding(Building tower);

        public abstract bool buildInRange(Building tower);

        public abstract Building closestBuilding(Building[] buildArray);

        public abstract string moveToClosestBuilding(Building closestBuilding);

        public abstract bool attackBuilding(Building closestBuilding, Unit closestUnit);

        public abstract bool combatFlag(Unit enemy);

        public abstract bool inRange(Unit enemy);

        public abstract Unit closestUnit(Unit[] unitArray);

        public abstract string moveToClosestUnit(Unit closestUnit);

        public abstract string runAway();

        public abstract bool isDead();

        public abstract string toString();

        public abstract string saveString();

        ~Unit() //destructor
        {

        }
    }

