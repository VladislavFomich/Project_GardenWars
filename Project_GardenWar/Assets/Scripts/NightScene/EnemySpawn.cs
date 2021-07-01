using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed;
    private bool isItInEnd;

    private void Awake()
    {
        transform.position = start.position;
    }

    private void Update()
    {
        CheckPoint();
        MovePoint();   
    }
    void MovePoint()
    {
        if (isItInEnd == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, end.position, speed * Time.deltaTime);
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
    }
    void CheckPoint()
    {
        if (transform.position == end.position)
        {
            isItInEnd = true;
        }
        else if (transform.position == start.position)
        {
            isItInEnd = false;
        }
    }
}
