using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    private float offset = 2.56f;
    // Map gameMap = new Map();    not actually needed
    Unit[] unitArray;
    Building[] buildingArray;

    public int gameTime = 0;
    public int seconds = 0;
    private const int REFRESH = 60;

    System.Random rng;

    // Use this for initialization
    void Start () {

        rng = new System.Random();
        float size = Camera.main.orthographicSize;

        unitArray = new Unit[10];
        buildingArray = new Building[6];

        float xPos = -4 * size + size + offset;
        float yPos = size + 1;



        
        //gameMap = new Map();
        DrawMap(xPos, yPos);
        Debug.Log("game start");
        generateUnits(unitArray);
        populateBuildArray();
       // drawUnits(gameMap.propUnitArray);
       // drawBuildings(gameMap.propBuildArray);
        
    }

     void generateUnits(Unit[] arrayOfUnits) //method to generate units in the array
    {
        int i;
        System.Random pls = new System.Random();
        for (i = 0; i < 10; i++)
        {
            int unitRoll = pls.Next(1, 5);
            switch (unitRoll)                                     //deciding each units type and faction
            {
                case 1:
                    arrayOfUnits[i] = new MeleeUnit("redKnight", 100, 'R', 'M');
                    break;
                case 2:
                    arrayOfUnits[i] = new RangedUnit("redArcher", 60, 'R', 'A');
                    break;
                case 3:
                    arrayOfUnits[i] = new MeleeUnit("blueKnight", 100, 'B', 'm');
                    break;
                case 4:
                    arrayOfUnits[i] = new RangedUnit("blueArcher", 60, 'B', 'a');
                    break;
            }

            arrayOfUnits[i].propX = rng.Next(0, 20);  //deciding the units starting x and y positions
            arrayOfUnits[i].propY = rng.Next(0, 20);

            



        }
    }

    public void populateBuildArray()         //produces buildings.           locations are predecided
    {
        buildingArray[0] = new ResourceBuilding("redResource", 300, 300, 'R', 'S', "Iron", 2, 100);
        buildingArray[0].propPosX = 10; buildingArray[0].propPosY = 0;

        buildingArray[1] = new ResourceBuilding("blueResource", 300, 300, 'B', 'Q', "Iron", 2, 100);
        buildingArray[1].propPosX = 10; buildingArray[1].propPosY = 19;

        buildingArray[2] = new FactoryBuilding("redFactory", "Melee", 300, 300, 'R', 'H', 1, 1);
        buildingArray[2].propPosX = 0; buildingArray[2].propPosY = 0;

        buildingArray[3] = new FactoryBuilding("redFactory", "Ranged", 300, 300, 'R', 'H', 18, 1);
        buildingArray[3].propPosX = 19; buildingArray[3].propPosY = 0;

        buildingArray[4] = new FactoryBuilding("blueFactory", "Melee", 300, 300, 'B', 'T', 18, 18);
        buildingArray[4].propPosX = 19; buildingArray[4].propPosY = 19;

        buildingArray[5] = new FactoryBuilding("blueFactory", "Ranged", 300, 300, 'B', 'T', 1, 18);
        buildingArray[5].propPosX = 0; buildingArray[5].propPosY = 19;
    }





    // Update is called once per frame
    void Update () {

        if ((gameTime % REFRESH == 0))
        {
            PlayGame(unitArray, buildingArray);
            Debug.Log("Unit Array Lenght: " + unitArray.Length);
            redraw(unitArray, buildingArray);
            Debug.Log("Unit Array Lenght: " + unitArray.Length);
            seconds++;
            Debug.Log(seconds);

        }
        
        gameTime++;


    }

    void DrawMap(float x, float y)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int k = 0; k < 20; k++)
            {
                Instantiate(Resources.Load("grass"), new Vector3((i * offset), -k * offset, -1), Quaternion.identity);
            }
        }
    }

    void PlayGame(Unit[] arrayOfUnits, Building[] arrayOfBuildings)
    {
        
        Debug.Log("Running through playGame function");
        foreach (Unit merc in arrayOfUnits)               //going through the units
        {
            Debug.Log("Starting unit run");
            if (merc != null)//check if unit is not null
            {
                
                Debug.Log("merc is not null");
                if (merc.isDead() == false)//check that unit is not dead
                {

                    if (seconds % merc.propSpeed == 0)
                    {

                        if (merc.propHp > merc.propMaxHp * 0.25)//check that unit is above 25% health
                        {
                            if(merc.attackBuilding(merc.closestBuilding(arrayOfBuildings), merc.closestUnit(arrayOfUnits)) == true) //check whether to attack buildings instead of units
                            {
                                if(merc.buildInRange(merc.closestBuilding(arrayOfBuildings)) == true)
                                {
                                    merc.combatBuilding(merc.closestBuilding(arrayOfBuildings));
                                    Debug.Log("Unit Attacks building");
                                }
                                else
                                {
                                    merc.move(merc.moveToClosestBuilding(merc.closestBuilding(arrayOfBuildings)));
                                    Debug.Log("Unit moves towards building");
                                }
                            }
                            else
                            {
                                if(merc.inRange(merc.closestUnit(arrayOfUnits)) == true)
                                {
                                    merc.combat(merc.closestUnit(arrayOfUnits));
                                    Debug.Log("unit attacks another unit");
                                }
                                else
                                {
                                    merc.move(merc.moveToClosestUnit(merc.closestUnit(arrayOfUnits)));
                                    Debug.Log("unit moves towards another unit");
                                }
                            }

                        }
                        else
                        {
                            merc.move(merc.runAway());
                            Debug.Log("Unit runs away");
                        }

                    }

                }

                else
                {
                   // Debug.Log(merc.toString());
                    Debug.Log("unit has died");
                    merc.propSymbol = 'X';
                }
            }
            else
            {
                Debug.Log("unit is null");
            }
            Debug.Log("done with unit functions");
        }

        Debug.Log("Unit Loop done");

        foreach (Building tower in arrayOfBuildings)  //going through the buildings
        {
            if (tower != null)
            {

                if (tower.isDead() == false)
                {

                    if (seconds % tower.propSpeed == 0)
                    {
                        if (tower.propBuildingType == "Factory")
                        {
                             Unit newUnit = tower.generateUnit();
                            //arrayResize(unitArray.Length + 1, ref unitArray, newUnit);
                             Array.Resize(ref unitArray, unitArray.Length + 1);              //increasing array size and adding new units to the array
                            unitArray[unitArray.Length - 1] = newUnit;
                            if(newUnit == null || newUnit.isDead() == true) //trying to find out why new units arent showing up
                            {
                                Debug.Log("new Unit is null or dead");
                            }
                            Debug.Log("Made a unit: " + newUnit.propPicName + " at X: " + newUnit.propX + " Y:" + newUnit.propY);
                           // Debug.Log("Unit Array Lenght" + arrayOfUnits.Length);
                        }
                        else
                        {
                            if (tower.propBuildingType == "Resource")
                            {
                                tower.generateResource();
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("Building got wrecked");
                    tower.propSymbol = 'U';
                }
            }
            Debug.Log("done with building functions");
        }
        Debug.Log("building loop done");

        Debug.Log("done with playgame function");

        
    }

    //put new methods here
    void drawUnits(Unit[] arrayOfUnits)
    {
        foreach(Unit merc in arrayOfUnits)
        {
            if(!merc.isDead())
            {
                Instantiate(Resources.Load(merc.propPicName), new Vector3(merc.propX * offset, -merc.propY * offset, -2), Quaternion.identity);
                Instantiate(Resources.Load(getHpName(merc.propHp, merc.propMaxHp)), new Vector3(merc.propX * offset, -merc.propY * offset, -3), Quaternion.identity);
            }
        }
    }

    void drawBuildings(Building[] arrayOfBuidings)
    {
        foreach(Building tower in arrayOfBuidings)
        {
            if(!tower.isDead())
            {
                Instantiate(Resources.Load(tower.propBuildPicName), new Vector3(tower.propPosX * offset, -tower.propPosY * offset, -2), Quaternion.identity);
                Instantiate(Resources.Load(getHpName(tower.propHp, tower.propMaxHp)), new Vector3(tower.propPosX * offset, -tower.propPosY * offset, -3), Quaternion.identity);
                
            }
        }
    }
    
    void redraw(Unit[] arrayOfUnits, Building[] arrayOfBuildings)
    {
        GameObject[] forDeletion = GameObject.FindGameObjectsWithTag("redrawSprite");
        foreach (GameObject temp in forDeletion)
        {
            Destroy(temp.gameObject);
        }
        drawUnits(arrayOfUnits);
        drawBuildings(arrayOfBuildings);
        Debug.Log("Objects redrawn");
    }

    public string getHpName(int hp, int maxHp)
    {
        string returnHp = "hp";

        double hpPercentage = ((double)hp / (double)maxHp) * 20;
        int roundedHp = Mathf.CeilToInt((float)hpPercentage);
        returnHp += roundedHp;
        return returnHp;
    }

    void arrayResize(int Size, ref Unit[] array, Unit genUnit)
    {

        Unit[] temp = new Unit[Size];
        for (int c = 1; c < Mathf.Min(Size, array.Length); c++)
        {
            temp[c] = array[c];
        }
        array = temp;
        array[array.Length - 1] = genUnit;
    }





}
