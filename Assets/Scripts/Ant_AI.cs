using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Ant_AI : MonoBehaviour
{
    private float minX, maxX;
 
    private float minZ, maxZ;
 
    [SerializeField]
    private float speed;
 
    private SpawnAnts moving;
    private Vector3 targetPosition;
 
    private Vector3 GetRandomTarget()
    {
        return new Vector3(Random.Range(-13, 14), 0f, Random.Range(-29, 30));
    }
 
    private void Start()
    {
        moving = FindObjectOfType<SpawnAnts>();
        targetPosition = GetRandomTarget();
    }
 
    private void Update()
    {
        if (moving.isMoving)
        {
            if (transform.position.x == targetPosition.x && transform.position.z == targetPosition.z)
            {
                targetPosition = GetRandomTarget();
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
        }
    }
}