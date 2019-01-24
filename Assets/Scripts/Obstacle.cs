﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Obstacle : MonoBehaviour
{
    Collider2D[] colliders;
    public ObstacleCube[] cubes;
    public bool[] wallsEnabled;
    [SerializeField] Vector3 playerPos;
    public int playerLayer;
    public int centerLayer;
    public float speed;
    Random rand;


    private void Start()
    {
        rand = new Random((int)(Time.realtimeSinceStartup * 10.0f));
        playerPos = new Vector3(0, 0, 0);
        wallsEnabled = new bool[4];
        ResetBools();
        DisableRandomWall();
    }

    private void Update()
    {
        Vector3 scale = new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, -speed * Time.deltaTime);
        foreach(ObstacleCube cube in cubes)
        {
            Vector3 direction = (playerPos - cube.transform.position).normalized;
            cube.transform.position += direction * speed * Time.deltaTime;

            cube.transform.localScale = new Vector3(cube.transform.localScale.x - speed * 2 * Time.deltaTime,
                                                    cube.transform.localScale.y,
                                                    cube.transform.localScale.z);
        }
    }

    public void ResetObstacles()
    {
        foreach(ObstacleCube cube in cubes)
        {
            cube.ResetObstacle();
        }
        DisableRandomWall();
    }

    public void ResetBools()
    {
        for (int i = 0; i < 4; i++)
        {
            wallsEnabled[i] = true;
        }
    }

    public void DisableRandomWall()
    {
        rand = new Random((int)(Time.realtimeSinceStartup * 10.0f));
        int wallToDisable = rand.Next(cubes.Length);
        cubes[wallToDisable].DisableWall();
        wallsEnabled[wallToDisable] = false;
    }
}
