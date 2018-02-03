using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    private float offset = 2.56f;

    // Use this for initialization
    void Start () {

        float size = Camera.main.orthographicSize;


        float xPos = -4 * size + size + offset;
        float yPos = size + 1;


        
        Instantiate(Resources.Load("redKnight"), new Vector3(0*offset, 0*offset, -2), Quaternion.identity);
        Instantiate(Resources.Load("hp20"), new Vector3(0*offset, 0*offset, -3), Quaternion.identity);

        DrawMap(xPos, yPos);
        
    }



    
	
	// Update is called once per frame
	void Update () {
		
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
}
