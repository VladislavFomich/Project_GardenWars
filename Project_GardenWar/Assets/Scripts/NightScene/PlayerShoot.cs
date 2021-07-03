using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShoot : MonoBehaviour
{
    public ObjectPool houseBullet;
    public Vector2 dir;
    private bool startAttack;
    public float spawnTime;
    public Transform spawnPoint;
    public Camera cam;

    private void Start()
    {
        StartCoroutine(SpawnBullet());
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject())
            {
                startAttack = true;
                Vector2 touchPos = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                dir = touchPos - (new Vector2(transform.position.x, transform.position.y));
                dir.Normalize();              
            }
        }
       else if (Input.touchCount == 0)
        {
            startAttack = false;
        }
    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            if (startAttack)
            {
                houseBullet.ObjectAwake(spawnPoint.position);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
