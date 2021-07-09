using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlantText : MonoBehaviour
{
    Text text;


    private void Start()
    {
        text = gameObject.GetComponent<Text>();

    }
    private void Update()
    {
        text.text = "Steal Plant = " + WinManager.Instance.stealPlantCount;
    }
}
