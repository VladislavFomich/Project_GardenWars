using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public delegate void HitTheTargetDelegate(ReturnToPool bullet);
    public event HitTheTargetDelegate OnObjectHit;
  
       public void Death() 
        {
            OnObjectHit?.Invoke(this);
        }
     
}
