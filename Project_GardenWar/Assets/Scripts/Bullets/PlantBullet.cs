using UnityEngine;

public class PlantBullet : GeneralBullet, IPoolable
{
    House house;

    public void Reset()
    {

        CustomStart();
        //house.target = null;
    }

    public void CustomStart()
    {
        house = FieldManager.Instance.house.GetComponent<House>();
        ReturnToPool returnToPool = house.target.GetComponent<ReturnToPool>();
        returnToPool.OnObjectHit += GoToPool;
    }
    public void Start()
    {
        CustomStart();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, house.target.position, bulletSpeed * Time.deltaTime);
    }
    void GoToPool(ReturnToPool returnToPool)
    {
        returnToPool.OnObjectHit -= GoToPool;
        gameObject.GetComponent<ReturnToPool>().Death();
    }

}
