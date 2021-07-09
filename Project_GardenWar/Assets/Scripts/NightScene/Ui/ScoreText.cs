using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text text;
   public House house;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();

    }
    private void Update()
    {
        text.text = "House Health = " + house.health;
    }

}
