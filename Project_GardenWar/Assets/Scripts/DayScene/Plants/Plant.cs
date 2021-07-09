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

    public Timer timer;

    public bool addedWater;
    public bool addedSeed;
    
    public bool isItTouched;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
    }

    private void Update()
    {

        if (level == 1)
        {
            bulletSpawnTime = 1f;
            damage = 3;
            bulletSpeed = 1f;
        }
        if (addedSeed && addedWater && level == 0 )
        {
            addedSeed = false;
            addedWater = false;
            
            timer.textTime.gameObject.SetActive(true);
            timer.startTimer = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
    //public void LoadData(SaveLoadManager.Save.PlantSaveData save)
    //{
    //    level = save.level;
    //    bulletSpawnTime = save.bulletSpawnTime;
    //    damage = save.damage;
    //    bulletSpeed = save.bulletSpeed;
    //}

}
