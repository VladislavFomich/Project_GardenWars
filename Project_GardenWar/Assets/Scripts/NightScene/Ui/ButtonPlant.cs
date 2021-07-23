using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonPlant : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public ObjectPool plantsManager;
    public GameObject plant;
    private bool addedInList;
    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }


    public void OnDrag(PointerEventData eventData)
    {
        var pos = cam.ScreenToWorldPoint(eventData.position);
        pos.z = 0;
        plant.transform.position = pos;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
         plant = plantsManager.ObjectAwake(eventData.position);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (addedInList == false)
        {
            FieldManager.Instance.plants.Add(plant.transform);
        }
        WinManager.Instance.daysPlant -= 1;
        plant.GetComponent<BoxCollider2D>().enabled = true;
    }


}
