using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using UnityEngine;



    class RangedUnit : Unit
    {


       /* protected string name;

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
                                                         //these were causing alot of problems
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
        }*/

        public RangedUnit(string pic ,int health ,char team, char sym) : base(60, 10, 3, 2)
        {
        this.propPicName = pic;
            this.propName = nameSelect();
            this.propHp = health;
            this.propFaction = team;
            this.propSymbol = sym;

           
        }

        

        public override string nameSelect()  // method to choose name
        {
            string name = "Placeholder";
            int nameroll = rando.Next(1, 3);
            switch (nameroll)
            {
                case 1:
                    name = "Archer";

                    break;
                case 2:
                    name = "Sniper";

                    break;
            }
            return name;
        }

        

        public override void move(string direction)  //using directions given by other methods to move the unit.
        {
            switch (direction)
            {
                case "up":
                    if (this.propY > 0)
                    {
                        this.propY = this.propY - 1;
                    }
                    break;

                case "down":
                    if (this.propY < 19)
                    {
                        this.propY = this.propY + 1;
                    }
                    break;

                case "right":
                    if (this.propX < 19)
                    {
                        this.propX = this.propX + 1;
                    }
                    break;

                case "left":
                    if (this.propX > 0)
                    {
                        this.propX = this.propX - 1;
                    }
                    break;
            }
        }

        public override void combat(Unit enemy)  // combat method
        {
            if (inRange(enemy) == true)
            {
                enemy.propHp = enemy.propHp - this.propAttack;
            }
        }

        public override bool combatFlag(Unit enemy) //combat flag, if an enemy is in Range then the unit is in combat
        {
            bool inCombat = false;
            if (inRange(enemy) == true)
            {
                inCombat = true;
            }
            return inCombat;
        }

        public override bool inRange(Unit enemy) // checking if an enemy is in range
        {
            bool inRangeOf = false;
            int xDiff = Math.Abs(this.propX - enemy.propX);
            int yDiff = Math.Abs(this.propY - enemy.propY);
            if (xDiff <= this.propRange && yDiff <= this.propRange)
            {
                inRangeOf = true;
            }
            return inRangeOf;
        }

        public override Unit closestUnit(Unit[] unitArray) // method to determine closest unit
        {
            Unit closestUnit = new MeleeUnit("isNoHere" ,0, 't', 't');
            int closestDist = 3200;
            closestUnit.propX = 40; closestUnit.propY = 10;
            foreach (Unit target in unitArray)                                          //looping through array
            {
                if (target != null)                                                     //checking if target isnt null
                {
                    if (target != this)                                                 // checking that the target isnt this unit
                    {
                        if (target.propFaction != this.propFaction)                     //checking that the target isnt of the same faction
                        {
                            if (target.isDead() == false)                  // checking that the target isnt dead
                            {
                                int xDiff = Math.Abs(this.propX - target.propX);
                                int yDiff = Math.Abs(this.propY - target.propY);
                                int absDist = xDiff + yDiff;                          // finding the absolute distance
                                if (absDist > closestDist)                            // checking if the absolute distance is closer than the previous closest distance
                                {
                                    closestUnit = target;                             // setting new closest enemy unit and distance
                                    closestDist = absDist;
                                }

                            }
                        }
                    }
                }
            }

            return closestUnit;                                                      // returning the closest unit
        }

        public override string moveToClosestUnit(Unit closestUnit) //method used to decide what direction to go in to get to closest unit
        {
            string direction;
            int xDiff = Math.Abs(this.propX - closestUnit.propX);
            int yDiff = Math.Abs(this.propY - closestUnit.propY);

            if (xDiff >= yDiff && xDiff != 0)
            {
                if (this.propX - closestUnit.propX < 0)
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }
            }
            else
            {
                if (this.propY - closestUnit.propY < 0)
                {
                    direction = "down";
                }
                else
                {
                    direction = "up";
                }
            }
            return direction;
        }

        public override string runAway()
        {
          
            string direction = "";
            int moveRoll = rando.Next(1, 5);             //random runaway method

            switch (moveRoll)
            {
                case 1:
                    direction = "up";
                    break;
                case 2:
                    direction = "down";
                    break;
                case 3:
                    direction = "right";
                    break;
                case 4:
                    direction = "left";
                    break;
            }

            return direction;
        }

        public override bool isDead() // checking whether a unit is dead
        {
            bool amDead = false;
            if (this.propHp <= 0)
            {
                amDead = true;
            }

            return amDead;
        }

        public override string toString()
        {
            return "Hi I Am " + propName + ". I Am A " + this.GetType().ToString().Split('.')[1] + " For The " + this.propFaction + " Faction. I Have " + this.propHp + " Health Left, And I Do " + this.propAttack + " Damage from a Distance of " + this.propRange;
        }

        public override string saveString()
        {
            string saveString = this.GetType().ToString().Split('.')[1] + "," + this.propName + "," + this.propMaxHp + "," + this.propHp + "," + this.propAttack + "," + this.propRange + "," + this.propSpeed + "," + this.propFaction + "," + this.propSymbol + "," + this.propX + "," + this.propY;
            return saveString;
        }

    public override Building closestBuilding(Building[] buildArray)
    {
        Building closestBuilding = new FactoryBuilding("isNoHere", "noUnits", 0, 0, 't', 't', 21, 21);
        //closestUnit.propX = 40; closestUnit.propY = 10;
        int closestDist = 3200;
        foreach (Building target in buildArray)                                          //looping through array
        {
            if (target != null)                                                     //checking if target isnt null
            {
               // if (target != this)                                                 // checking that the target isnt this
                //{
                    if (target.propFaction != this.propFaction)                     //checking that the target isnt of the same faction
                    {
                        if (target.isDead() == false)                  // checking that the target isnt dead
                        {
                            int xDiff = Math.Abs(this.propX - target.propPosX);
                            int yDiff = Math.Abs(this.propY - target.propPosY);
                            int absDist = xDiff + yDiff;                          // finding the absolute distance
                            if (absDist < closestDist)                            // checking if the absolute distance is closer than the previous closest distance
                            {
                                closestBuilding = target;                             // setting new closest enemy unit and distance
                                closestDist = absDist;
                            }

                        }
                    }
               // }
            }
        }
        return closestBuilding;
    }

    public override bool buildInRange(Building tower)
    {
        bool inRangeOf = false;
        int xDiff = Math.Abs(this.propX - tower.propPosX);
        int yDiff = Math.Abs(this.propY - tower.propPosY);
        if (xDiff <= this.propRange && yDiff <= this.propRange)
        {
            inRangeOf = true;
        }
        return inRangeOf;
    }

    public override string moveToClosestBuilding(Building closestBuilding)
    {
        string direction;
        int xDiff = Math.Abs(this.propX - closestBuilding.propPosX);
        int yDiff = Math.Abs(this.propY - closestBuilding.propPosY);

        if (xDiff >= yDiff)
        {
            if (this.propX - closestBuilding.propPosX < 0)
            {
                direction = "right";
            }
            else
            {
                direction = "left";
            }
        }
        else
        {
            if (this.propY - closestBuilding.propPosY < 0)
            {
                direction = "down";
            }
            else
            {
                direction = "up";
            }
        }
        return direction;
    }

    public override void combatBuilding(Building tower)
    {
        if (buildInRange(tower) == true) //this range check may seem unneccessary, but these things were like snipers without it
        {
            tower.propHp = tower.propHp - this.propAttack;
            Debug.Log("my position" + this.propX + this.propY + " attacking enemy at position " + tower.propPosX + "X: " + tower.propPosY + "Y");
        }
    }

    public override bool attackBuilding(Building closestBuilding, Unit closestUnit)
    {
        bool goForIt = false;
        int buildAbsDist;
        int unitAbsDist;

        //find building abs distance
        int buildXDiff = Math.Abs(this.propX - closestBuilding.propPosX);
        int buildYDiff = Math.Abs(this.propY - closestBuilding.propPosY);
        buildAbsDist = buildXDiff + buildYDiff;
        // find unit abs distance
        int unitXDiff = Math.Abs(this.propX - closestUnit.propX);
        int unitYDiff = Math.Abs(this.propY - closestUnit.propY);
        unitAbsDist = unitXDiff + unitYDiff;

        if (buildAbsDist < unitAbsDist)
        {
            goForIt = true;
        }
        else
        {
            goForIt = false;
        }
        return goForIt;
    }

}

