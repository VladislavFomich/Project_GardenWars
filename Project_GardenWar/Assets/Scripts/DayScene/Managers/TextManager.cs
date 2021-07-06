using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    //public GameObject levelText;
    //public GameObject damageText;
    //public GameObject attackSpeedtext;
    //public GameObject bulletSpeed;
    public GameObject[] plantStats;
    private Text[]  text;

    private void Start()
    {
        text = new Text[plantStats.Length];
        for (int i = 0; i < plantStats.Length; i++)
        {
            text[i] = plantStats[i].GetComponent<Text>();
        }

    }

}
