using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    private int health;
    public ObjectPool bulletPool;
    public GameObject spawn;
    public float speedAttack;
    public Transform target;
    private bool startAttack;

    private void Start()
    {
        StartCoroutine(SpawnBullet());
    }
    private void Update()
    {

        if (FieldManager.Instance.enemy.Count > 0)
        {
            startAttack = true;
                target = FieldManager.Instance.enemy[0];
            foreach(var item in FieldManager.Instance.enemy)
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

}

