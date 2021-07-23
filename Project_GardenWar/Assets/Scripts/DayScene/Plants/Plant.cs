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
    bool levelUp;

    SpriteRenderer spriteRend;
    private void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
    }
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
        if (timer.textTime.text == "0:0")
        {
            if (levelUp == false)
            {
                levelUp = true;
                level += 1;
                spriteRend.color = Color.green;
            }
        }
        if (addedSeed && addedWater && level == 0 )
        {
            spriteRend.color = Color.cyan;
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
