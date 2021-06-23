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
            OnObjectHit?.Invoke(this);
        }
        if (collision.tag == "EndPoint")
        {
            
            if (gameObject.GetComponent<GeneralPlant>())
            {
                FieldManager.Instance.plants.Remove(gameObject.transform);
                Debug.Log("Plant Remove");
            }
            if (gameObject.GetComponent<GeneralEnemy>())
            {
                FieldManager.Instance.enemy.Remove(gameObject.transform);
            }
            OnObjectHit?.Invoke(this);
        }

    }

}
