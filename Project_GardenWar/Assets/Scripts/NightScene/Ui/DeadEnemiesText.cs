using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeadEnemiesText : MonoBehaviour
{
    Text text;


    private void Start()
    {
        text = gameObject.GetComponent<Text>();

    }
    private void Update()
    {
        text.text = "Dead Enemies = " + WinManager.Instance.dieEnemyCount;
    }
}
