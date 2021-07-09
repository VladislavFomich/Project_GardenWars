using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour
{
    public GameObject plantMenu;
    public bool isItColl;
    public int numOfPlant;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var plant = collision.gameObject.GetComponent<Plant>();
        if (plant.isItTouched)
        {
            numOfPlant = plant.numOnGround;
            isItColl = true;
            collision.gameObject.GetComponent<Plant>().isItTouched = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var plant = collision.gameObject.GetComponent<Plant>();
        if (plant.isItTouched)
        {
            numOfPlant = plant.numOnGround;
            isItColl = true;
            collision.gameObject.GetComponent<Plant>().isItTouched = false;
        }
    }


    private void Update()
    {
        if (isItColl)
        {
            isItColl = false;
           plantMenu.SetActive(true);
        }
    }
}
