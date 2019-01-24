using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Collider2D[] colliders;
    public GameObject[] cubes;
    public float speed;
    [SerializeField] Vector3 playerPos;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider2D>();
        //colliders[Random.Range(0, colliders.Length)].isTrigger = true;
        playerPos = new Vector3(0, 0, 0);


    }

    private void Update()
    {
        Vector3 scale = new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, -speed * Time.deltaTime);
        foreach(GameObject cube in cubes)
        {
            Vector3 direction = (playerPos - cube.transform.position).normalized;
            cube.transform.position += direction * speed * Time.deltaTime;

            cube.transform.localScale = new Vector3(cube.transform.localScale.x - speed * 2 * Time.deltaTime,
                                                    cube.transform.localScale.y,
                                                    cube.transform.localScale.z);
        }
    }
}
