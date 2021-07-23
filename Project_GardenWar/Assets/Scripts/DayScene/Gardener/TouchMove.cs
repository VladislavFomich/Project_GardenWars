using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMove : MonoBehaviour
{
    private Vector2 touchPos;
    private Camera cam;
    public float speed;
    public bool isItWalk;

    int layerMask = 1 << 7;
    private void Start()
    {
        Time.timeScale = 1;
        cam = Camera.main;
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchPos = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero, Mathf.Infinity, layerMask);
                if (hit)
                {
                    
                  hit.collider.gameObject.GetComponent<Plant>().isItTouched = true;
                }
                isItWalk = true;
            }
        }

        if (isItWalk)
        {
        transform.position = Vector2.MoveTowards(transform.position, touchPos, speed * Time.deltaTime);
        }

    }

}
