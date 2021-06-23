using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlant : MonoBehaviour, IPoolable
{

    public ObjectPool bulletPool;
    public GameObject spawn;
    public float speedAttack;
    public Transform target;
    private bool startAttack;

   public bool enemyTakeIt;

    public void Start()
    {
        var obj = GameObject.FindGameObjectsWithTag("BulletManager");
        bulletPool = obj[0].GetComponent<ObjectPool>();
        StartCoroutine(SpawnBullet());
    }
    private void Update()
    {
        FindTarget();
        if (enemyTakeIt == true)
        {
            transform.position = target.position;
        }
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            if (startAttack)
            {
                bulletPool.ObjectAwake(spawn.transform.position);
            }
            yield return new WaitForSeconds(speedAttack);
        }
    }
    private void FindTarget() 
    {
        if (FieldManager.Instance.enemy.Count > 0)
        {
            startAttack = true;
            target = FieldManager.Instance.enemy[0];
            foreach (var item in FieldManager.Instance.enemy)
            {
                float distance = Vector2.Distance(transform.position, item.transform.position);
                if (distance < Vector2.Distance(transform.position, target.position))
                {
                    target = item; 
                }
            }
        }
        if (FieldManager.Instance.enemy.Count == 0)
        {
            startAttack = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.gameObject.transform;
        enemyTakeIt = true;
   
    }

    public void Reset()
    {
        enemyTakeIt = false;
        target = null;
        startAttack = false;
    }
}
