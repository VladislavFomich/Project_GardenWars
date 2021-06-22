using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : Singleton<FieldManager>
{
    public Transform house;
    public Transform spawn;
    public List<Transform> plants;
    public List<Transform> enemy;
    public float overlapRadius = 10f;


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
