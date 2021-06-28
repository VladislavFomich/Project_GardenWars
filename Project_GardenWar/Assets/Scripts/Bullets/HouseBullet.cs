using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBullet : GeneralBullet, IPoolable
{
    
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

   
}
