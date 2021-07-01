using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour, IPoolable
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float waitAttackSpeed;
    [SerializeField]
    public int damage;
    [SerializeField]
    public  Transform moveTarget;
    private bool addedInList;
    public bool takePlant;
    public bool stayOnGround;
    public GeneralPlant plant;
    int firstHealth;
    private bool attackHouse;
    private House house;
    private void Awake()
    {
        firstHealth = health;
    }
    
   private void CustomStart()
    {
        house = FieldManager.Instance.house.GetComponent<House>();
        StartCoroutine(AttackHouse());
    }
    private void Update()
    {
        FindTarget();
        Move(moveTarget);
        if (health <= 0)
        {
            FieldManager.Instance.enemy.Remove(gameObject.transform);
            gameObject.GetComponent<ReturnToPool>().Death();
        }
        if (Vector2.Distance(transform.position, FieldManager.Instance.house.position) > 0.2f)
        {
            attackHouse = false;
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
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
            stayOnGround = false;
            FieldManager.Instance.enemy.Remove(gameObject.transform);
            gameObject.GetComponent<ReturnToPool>().Death();
        }
        if (collision.GetComponent<GeneralBullet>())
        {
            health -= collision.GetComponent<GeneralBullet>().damage;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Ground")
        {
            stayOnGround = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.GetComponent<House>())
        {
            attackHouse = true;
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
    IEnumerator AttackHouse()
    {
        while (true)
        {
            if (attackHouse)
            {
                house.health -= damage;
            }
            yield return new WaitForSeconds(waitAttackSpeed);
        }
    }

    public void Reset()
    {
        attackHouse = false;
        stayOnGround = false;
        takePlant = false;
        moveTarget = null;
        addedInList = false;
        health = firstHealth;
        CustomStart();
    }
}
    