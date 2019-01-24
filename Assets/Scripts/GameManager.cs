using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public droid.Runtime.Prototyping.Observers.WallObserver wallObserver;
	public List<Transform> walls;
    
    void Start()
    {
    	foreach (Transform trans in transform.Find("Obstacles"))
    	{
    		walls.Add(trans);
    	}    
    }

    void RegisterResetWall(bool[] side)
    {
    	float[] shiftBuffer = new float[walls.Count-4];
    	for (int i = 0, j = shiftBuffer.Length-1 -side.Length; j < shiftBuffer.Length; i++, j++)
    	{
    		shiftBuffer[j] = (side[i] ? 1 : 0);
    	}
    	wallObserver.wallStates = new List<float>(shiftBuffer);
    }
}