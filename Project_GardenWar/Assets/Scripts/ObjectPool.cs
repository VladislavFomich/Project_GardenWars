using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject poolForObject;
    public int amount;

    private List<GameObject> objectPool = new List<GameObject>();

    private void Awake()
    {
        AddObjectsInPool();
    }

    void AddObjectsInPool()
    {
        if (poolForObject != null)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(poolForObject);
                instance.transform.SetParent(transform);
                instance.SetActive(false);
                objectPool.Add(instance);
            }
        }
    }
    public GameObject ObjectAwake(Vector2 pos)
    {
        foreach (var item in objectPool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = pos;
                item.transform.SetParent(null);
                item.SetActive(true);
                ReturnToPool returnToPool = item.GetComponent<ReturnToPool>();
                returnToPool.OnObjectHit += GoToPool;
                
                return item;
            }
        }
        var instance = Instantiate(poolForObject);
        objectPool.Add(instance);
        return instance;
    }
    void GoToPool(ReturnToPool returnToPool)
    {
        returnToPool.gameObject.SetActive(false);
        returnToPool.OnObjectHit -= GoToPool;
        returnToPool.transform.SetParent(transform);
    }
}
