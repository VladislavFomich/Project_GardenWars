 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    public int health;
    public Transform target;


    private void Update()
    {

        if (FieldManager.Instance.enemy.Count > 0)
        {
            var distanceToTarget = float.MaxValue;
            foreach (var item in FieldManager.Instance.enemy)
            {
                float distance = Vector2.Distance(transform.position, item.transform.position);
                if (distance <= distanceToTarget)
                {
                    distanceToTarget = distance;
                    target = item;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= collision.gameObject.GetComponent<GeneralEnemy>().damage;
        Debug.Log(health);
    }

}

