using droid.Runtime.Prototyping.Internals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Obstacle : Resetable
{
    public ObstacleCube[] cubes;
    public bool[] wallsEnabled;
    [SerializeField] Vector3 playerPos;
    public int playerLayer;
    public int centerLayer;
    public float speed;
    Random rand;
    GameManager gameManager;
    private bool reset = false;
    
    public override string PrototypingTypeName => "Obstacle";

    Vector3[] positions;
    float[] scale;


    private new void Start()
    {
        base.Start();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cubes = transform.GetComponentsInChildren<ObstacleCube>();

        positions = new Vector3[cubes.Length];
        scale = new float[cubes.Length];
        for (int i = 0; i < cubes.Length; i++)
        {
            positions[i] = cubes[i].transform.position;
            scale[i] = cubes[i].transform.localScale.x;
        }

        playerPos = new Vector3(0, 0, 0);
        wallsEnabled = new bool[4];
        ResetBools();
        DisableRandomWall();
    }

    protected override void Setup()
    {
        
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

        if (reset)
        {
            foreach (ObstacleCube cube in cubes)
            {
                cube.ResetObstacle();
            }
            ResetBools();
            DisableRandomWall();
            gameManager.RegisterResetWall(wallsEnabled);
            reset = false;
        }

    }

    public void ResetObstacles()
    {
        reset = true;
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
        rand = new Random((int)(Time.realtimeSinceStartup * 10.0f + gameObject.GetInstanceID()));
        int wallToDisable = rand.Next(cubes.Length);
        cubes[wallToDisable].DisableWall();
        wallsEnabled[wallToDisable] = false;
    }

    public override void EnvironmentReset()
    {
        Debug.Log("WHAT");
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = positions[i];
            cubes[i].transform.localScale = new Vector3(scale[i], 1, 1);
        }
    }
}
