using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public droid.Runtime.Prototyping.Observers.WallObserver wallObserver;
	public List<Obstacle> obstacles;
    private bool[] walls;

    void Start()
    {
    	foreach (Obstacle obstacle in transform.Find("Obstacles").GetComponentsInChildren<Obstacle>())
    	{
    		obstacles.Add(obstacle);
    	}
        walls = new bool[obstacles.Count * 4];
        for (int i = 0; i < obstacles.Count; i++)
        {
            for (int j = 0; j < obstacles[i].wallsEnabled.Length; j ++)
            {
                walls[i * 4 + j] = obstacles[i].wallsEnabled[j];
            }
        }
    }

    public void RegisterResetWall(bool[] side)
    {
        
        float[] shiftBuffer = new float[walls.Length];

        for (int i = 0; i < walls.Length - side.Length; i++)
        {
            shiftBuffer[i] = (walls[i + side.Length] ? 1 : 0); 
        }

        for (int i = 0, j = shiftBuffer.Length - side.Length; i < 4; i++, j++)
    	{
    		shiftBuffer[j] = (side[i] ? 1 : 0);
    	}
    	wallObserver.wallStates = new List<float>(shiftBuffer);

        //Debug print:
        string wallState = "";
        for (int i = 0; i < wallObserver.wallStates.Count; i++)
        {
            wallState += wallObserver.wallStates[i];
            if (i+1 % 4 == 0) wallState += "    ";
            wallState += ", ";
        }
        Debug.Log("POST Wall states: " + wallState);
        
    }
}