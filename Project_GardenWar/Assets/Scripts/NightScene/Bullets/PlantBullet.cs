using UnityEngine;

public class PlantBullet : GeneralBullet, IPoolable
{
    House house;
    public void Reset()
    { 
        CustomStart();
    }

    public void CustomStart()
    {
     
        house = FieldManager.Instance.house.GetComponent<House>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, house.target.position, bulletSpeed * Time.deltaTime);
    }

}
