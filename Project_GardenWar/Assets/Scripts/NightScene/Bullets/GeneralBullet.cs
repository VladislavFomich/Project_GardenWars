using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class GeneralBullet : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;
    ReturnToPool returnToPool;
    private void Start()
    {
        returnToPool = gameObject.GetComponent<ReturnToPool>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        returnToPool.Death();
    }
}
