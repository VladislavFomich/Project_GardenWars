using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public delegate void HitTheTargetDelegate(ReturnToPool bullet);
    public event HitTheTargetDelegate OnObjectHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            Debug.Log("Hit!");
            OnObjectHit?.Invoke(this);
        }
        if (collision.tag == "EndPoint")
        {
            OnObjectHit?.Invoke(this);
        }
    }

}
