using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePlant : MonoBehaviour
{
    public int numOnGround;
    public int level;
    public float bulletSpawnTime;
    public int damage;
    public float bulletSpeed;

    Button button;
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        if (level == 0)
        {
            button.interactable = false;
        }
    }
    public void LoadData(ChoiceSaveLoad.Save.PlantSaveData save)
    {
        level = save.level;
        bulletSpawnTime = save.bulletSpawnTime;
        damage = save.damage;
        bulletSpeed = save.bulletSpeed;
    }

}
