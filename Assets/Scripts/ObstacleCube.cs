using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCube : MonoBehaviour
{
    public Obstacle obstacle;
    public Vector3 orignalPosition;
    public Vector3 originalScale;
    public Rigidbody rb;
    public BoxCollider2D coll;
    public MeshRenderer meshRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider2D>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ResetObstacle()
    {
        transform.position = orignalPosition;
        transform.localScale = originalScale;
        coll.isTrigger = true;
        meshRenderer.enabled = true;
    }

    public void DisableWall()
    {
        coll.isTrigger = false;
        meshRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        //Debug.Log("GameObject layer: " + collision.gameObject.layer + " center layer: " + obstacle.centerLayer.value);
        if (collision.gameObject.layer == obstacle.centerLayer)
        {
            Debug.Log("Hit center");
            obstacle.ResetObstacles();
        }
    }
}
