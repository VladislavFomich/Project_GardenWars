using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public delegate void HitTheTargetDelegate(ReturnToPool objectt);
    public event HitTheTargetDelegate OnObjectHit;

    public void Death()
    {
        Debug.Log(gameObject.name);
        OnObjectHit?.Invoke(this);
    }
}
