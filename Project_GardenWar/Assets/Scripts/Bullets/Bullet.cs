using UnityEngine;

public class Bullet : MonoBehaviour,IPoolable
{
    public float speed;
    House house;

    public void Reset()
    {

        CustomStart();
        house.target = null;
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
        transform.position = Vector3.MoveTowards(transform.position, house.target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<ReturnToPool>().Death();
    }


}
