using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float gameSeconds;
    public float gameMinutes;

    string stringSecond;
    string stringMinutes;

    public Text textTime;

    public Plant plant;


    public   bool startTimer;

    private void Update()
    {

        if (textTime.text == "0:0")
        {
            startTimer = false;
            textTime.gameObject.SetActive(false);
            return;
        }
        stringSecond = Mathf.Round(gameSeconds).ToString();
        stringMinutes = Mathf.Round(gameMinutes).ToString();

        textTime.text = stringMinutes + ":" + stringSecond;

        if (startTimer)
        {
        gameSeconds -= Time.deltaTime;
        }
        if (gameSeconds <= 0f)
        {
            gameMinutes -= 1f;
            gameSeconds = 60.0f;
        }
        if (plant.addedSeed && plant.addedWater && plant.level == 0)
        {
            textTime.gameObject.SetActive(true);
            startTimer = true;
        }

    }
}

