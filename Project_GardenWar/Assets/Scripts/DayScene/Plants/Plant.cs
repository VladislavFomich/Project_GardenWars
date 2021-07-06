using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int numOnGround;
    public int level;
    public float bulletSpawnTime;
    public int damage;
    public float bulletSpeed;


    
    public bool isItTouched;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
    }

}
