using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlant : MonoBehaviour, IPoolable
{

    public ObjectPool bulletPool;
    public GameObject spawn;
    public float bulletSpawnTime;
    public Transform target;
    private bool startAttack;

   public bool enemyTakeIt;
    BoxCollider2D coll;
   

    public void CustomStart()
    {
        coll = gameObject.GetComponent<BoxCollider2D>();
        bulletPool = GameObject.Find("PlantBulletManager").GetComponent<ObjectPool>();
        StartCoroutine(SpawnBullet());
    }
    private void Update()
    {
        FindTarget();
        if (enemyTakeIt == true)
        {
            transform.position = target.transform.position;
        }
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            if (startAttack && coll.enabled == true)
            {
                bulletPool.ObjectAwake(spawn.transform.position);
            }
            yield return new WaitForSeconds(bulletSpawnTime);
        }
    }
    private void FindTarget() 
    {
            startAttack = FieldManager.Instance.enemy.Count != 0;
            var distanceToTarget = float.MaxValue;
            foreach (var item in FieldManager.Instance.enemy)
            {
                float distance = Vector2.Distance(transform.position, item.transform.position);
                if (distance < distanceToTarget)
                {
                    distanceToTarget = distance;
                    target = item; 
                }
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        target = collision.gameObject.transform;
        if (gameObject.transform == collision.gameObject.GetComponent<GeneralEnemy>().moveTarget)
        {
            enemyTakeIt = true;
        }
        
        ReturnToPool returnToPool = collision.gameObject.GetComponent<ReturnToPool>();
        returnToPool.OnObjectHit += GoToPool;
    }

    void GoToPool(ReturnToPool returnToPool)
    {
        if(target.gameObject.GetComponent<GeneralEnemy>().stayOnGround)
        {
            returnToPool.OnObjectHit -= GoToPool;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Reset();          
        }
        else 
        {
            WinManager.Instance.stealPlantCount += 1;
            returnToPool.OnObjectHit -= GoToPool;
            FieldManager.Instance.plants.Remove(gameObject.transform);
            gameObject.GetComponent<ReturnToPool>().Death();
        }
        
    }

    public void Reset()
    {
        enemyTakeIt = false;
        target = null;
        startAttack = false;
        CustomStart();
    }
}
