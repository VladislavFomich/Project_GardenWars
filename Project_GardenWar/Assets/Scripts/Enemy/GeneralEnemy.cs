using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int damage;

    private  Transform moveTarget;
    private bool addedInList;
    private bool takePlant;
   

    private void Update()
    {
        FindTarget();
        Move(moveTarget);
       
    }

    private void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (addedInList == false)
        {
            FieldManager.Instance.enemy.Add(gameObject.transform);
            addedInList = true;
        }
        if (collision.GetComponent<GeneralPlant>())
        {
            Debug.Log("Take plant");
            takePlant = true;
        }
    }
    private void FindTarget()
    {
        if (FieldManager.Instance.plants.Count == 0)
        {
            moveTarget = FieldManager.Instance.house;
        }
        else if (FieldManager.Instance.plants.Count > 0)
        {
            moveTarget = FieldManager.Instance.plants[0];
            foreach (var item in FieldManager.Instance.plants)
            {
                float distance = Vector2.Distance(transform.position, item.transform.position);
                if (distance < Vector2.Distance(transform.position, moveTarget.position))
                {
                    moveTarget = item;
                }
            }
        }
        if (takePlant)
        {
            moveTarget = FieldManager.Instance.spawn;
        }
    }

}
    