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

   public void OnDrag(PointerEventData eventData)
    {
        var pos = Camera.main.ScreenToWorldPoint(eventData.position);
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
        plant.GetComponent<BoxCollider2D>().enabled = true;
    }


}
