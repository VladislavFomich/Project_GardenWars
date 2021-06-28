using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class GeneralBullet : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<ReturnToPool>().Death();
    }
}
