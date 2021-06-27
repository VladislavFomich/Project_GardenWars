using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBullet : MonoBehaviour, IPoolable
{
    public float bulletSpeed;
    public PlayerShoot playerShoot;
    public void Reset()
    {
        CustomStart();
    }

    void CustomStart()
    {
        playerShoot = FieldManager.Instance.house.GetComponent<PlayerShoot>();
        gameObject.GetComponent<Rigidbody2D>().velocity = playerShoot.dir * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<ReturnToPool>().Death();
    }
}
