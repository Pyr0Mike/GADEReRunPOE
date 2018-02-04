using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using UnityEngine;



    class ResourceBuilding : Building
    {

        string resourceType;

        public string propResourceType
        {
            get
            {
                return resourceType;
            }

            set
            {
                resourceType = value;
            }
        }

        int generatedResources;

        public int propGenResources
        {
            get
            {
                return generatedResources;
            }

            set
            {
                generatedResources = value;
            }
        }


        int resourcePerTick;

        public int propResourcePerTick
        {
            get
            {
                return resourcePerTick;
            }

            set
            {
                resourcePerTick = value;
            }
        }

        int remResources;

        public int propRemResources
        {
            get
            {
                return remResources;
            }

            set
            {
                remResources = value;
            }
        }

        

        public ResourceBuilding(string pic ,int health, int maxhealth ,char team, char sym, string resType, int resPT, int remRes) : base(1) // constructor
        {
        this.propBuildPicName = pic;
            this.propBuildingType = "Resource";
            this.propHp = health;
        this.propMaxHp = maxhealth;
            this.propFaction = team;
            this.propSymbol = sym;
            this.propResourceType = resType;
            this.propResourcePerTick = resPT;
            this.propRemResources = remRes;
            this.propGenResources = 0;
        }

        public override bool isDead()                                               //methods
        {
            bool ded = false;
            if(this.propHp <= 0)
            {
                ded = true;
            }
            return ded;
        }

        public override void generateResource()
        {
            if(propRemResources > 0)
            {
                propGenResources = propGenResources + resourcePerTick;
                propRemResources = propRemResources - propResourcePerTick;
                Debug.Log("Produced " + this.propResourcePerTick + this.propResourceType +  " For Team " + this.propFaction);
            }
            else
            {
                Debug.Log("No more " + this.propResourceType + " Left to Produce ");
            }

        }

        public override string toString()
        {
            string info = "This is a Resource Building. It Produces " + this.propResourcePerTick + this.propResourceType + " Per Tick. It has Produced " + propGenResources + ", And Can Produce " + propRemResources + " More";
            Debug.Log(info);
            return info;
        }

        public override string saveString()
        {
            string info = "Resource" + "," + this.propHp + "," + this.propFaction + "," + this.propSymbol + "," + this.propResourceType + "," + this.propResourcePerTick + "," + this.propRemResources + "," + this.propPosX + "," + this.propPosY + "," + this.propGenResources;
            return info;
                
        }
        public override Unit generateUnit()
        {
            Unit notGonnaBeUsed = new MeleeUnit("Is no unit here" ,0, 't', '.'); // just in case it gets used, it can only create a basically no-existant unit
            notGonnaBeUsed = null;                            //pretty much producing a dead body
            return notGonnaBeUsed;
        }



    }

