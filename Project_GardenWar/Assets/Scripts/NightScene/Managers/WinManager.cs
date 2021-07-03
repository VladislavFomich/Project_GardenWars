using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : Singleton<WinManager>
{
    [HideInInspector]
    public int dieEnemyCount;
    [HideInInspector]
    public int stealPlantCount;
    public int houseHp;

    public int enemyCountCondition;
    public int plantCountCondition;
    public GameObject winMenu;
    public GameObject loseMenu;

    public House house;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (dieEnemyCount == enemyCountCondition)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (stealPlantCount == plantCountCondition)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (house.health <= 0 )
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
