using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Collider2D[] colliders;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider2D>();
        //colliders[Random.Range(0, colliders.Length)].isTrigger = true;
        

    }
}
