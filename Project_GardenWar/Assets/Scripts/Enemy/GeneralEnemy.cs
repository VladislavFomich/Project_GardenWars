using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour, IPoolable
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int damage;
    [SerializeField]
    public  Transform moveTarget;
    private bool addedInList;
    public bool takePlant;

    public GeneralPlant plant;

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
        if (collision.GetComponent<GeneralPlant>() && takePlant == false)
        {
                takePlant = true;
                plant = collision.GetComponent<GeneralPlant>();

        }
        if (collision.tag == "EndPoint")
        {
            FieldManager.Instance.enemy.Remove(gameObject.transform);
            gameObject.GetComponent<ReturnToPool>().Death();
        }
    }
    private void FindTarget()
    {
        moveTarget = null;

            if (takePlant)
            {
                moveTarget = FieldManager.Instance.spawn;
            return;
            }
            

        if (FieldManager.Instance.plants.Count > 0)
        {
            //  moveTarget = FieldManager.Instance.plants[0];
            var distanceToTarget = float.MaxValue;
            foreach (var item in FieldManager.Instance.plants)
            {
                if (item.gameObject.GetComponent<GeneralPlant>().enemyTakeIt == false)
                {
                    float distance = Vector2.Distance(transform.position, item.transform.position);
                    if (distance <= distanceToTarget)
                    {
                        distanceToTarget = distance;
                        moveTarget = item;
                    }
                }
                
               
            }
        }
        if (moveTarget == null)
        {
            moveTarget = FieldManager.Instance.house;
        }
    }

    public void Reset()
    {
        takePlant = false;
        moveTarget = null;
        addedInList = false;
        
    }
}
    