using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItems : MonoBehaviour
{
    public TextManager manager;
    public Button buttonWater;
    public Button buttonSeed;
    void Start()
    {
        buttonWater.onClick.AddListener(ClickWater);
        buttonSeed.onClick.AddListener(ClickSeed);
    }

    void ClickWater()
    {
        PlantManager.Instance.plants[manager.num].GetComponent<Plant>().addedWater = true;
    }
    void ClickSeed()
    {
        PlantManager.Instance.plants[manager.num].GetComponent<Plant>().addedSeed = true;
    }
}
