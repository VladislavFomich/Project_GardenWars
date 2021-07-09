using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSeed : MonoBehaviour
{
    public TextManager manager;
    public Button button;
    void Start()
    {
        button.onClick.AddListener(Click);
    }

    void Click()
    {
        PlantManager.Instance.plants[manager.num].GetComponent<Plant>().addedSeed = true;
    }
}
