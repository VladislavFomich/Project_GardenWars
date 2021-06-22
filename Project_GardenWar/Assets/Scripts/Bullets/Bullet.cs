using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    House house;


    private void Start()
    {
        house = FieldManager.Instance.house.GetComponent<House>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, house.target.position, speed * Time.deltaTime);
    }
    
}
