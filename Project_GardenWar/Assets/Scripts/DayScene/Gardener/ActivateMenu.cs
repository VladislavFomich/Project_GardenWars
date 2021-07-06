using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour
{
    public GameObject plantMenu;
    public bool isItColl;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Plant>().isItTouched)
        {
            isItColl = true;
            collision.gameObject.GetComponent<Plant>().isItTouched = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Plant>().isItTouched)
        {
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
