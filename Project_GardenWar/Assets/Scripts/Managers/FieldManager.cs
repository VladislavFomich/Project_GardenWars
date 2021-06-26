using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldManager : Singleton<FieldManager>
{
    public Transform house;
    public Transform spawn;
    public List<Transform> plants;
    public List<Transform> enemy;
    public float overlapRadius = 10f;

   // public List<Wave> waves;

    private void Awake()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, overlapRadius);
        foreach (var item in cols)
        {
            if (item.GetComponent<House>())
                house = item.transform;
        }
    }


}
//[Serializable]
//public struct Wave
//{
//    public float timeToNextWave;
//    public int enemise;
//}
