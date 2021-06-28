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
    }
    public void Start()
    {
        CustomStart();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, house.target.position, bulletSpeed * Time.deltaTime);
        if (FieldManager.Instance.enemy.Count == 0)
        {
            gameObject.GetComponent<ReturnToPool>().Death();
        }
    }


}
