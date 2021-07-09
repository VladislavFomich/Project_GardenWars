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

    bool levelUp;
 public   bool startTimer;
    private void Update()
    {

        if (startTimer)
        {
        gameSeconds -= Time.deltaTime;

        }

        stringSecond = Mathf.Round(gameSeconds).ToString();
        stringMinutes = Mathf.Round(gameMinutes).ToString();

        textTime.text = stringMinutes + ":" + stringSecond;

        if (gameSeconds <= 0f)
        {
            gameMinutes -= 1f;
            gameSeconds = 60.0f;
        }
        if (textTime.text == "0:0")
        {
            if (levelUp == false)
            {
                levelUp = true;
                plant.level += 1;
                plant.GetComponent<SpriteRenderer>().color = Color.green;
                PlantManager.Instance.levelUpPlant += 1;
            }
            textTime.gameObject.SetActive(false);
            startTimer = false;
        }
    }
}
