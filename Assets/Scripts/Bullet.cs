using UnityEngine;
public class Bullet: ObjectsActions
{
    private float speed = 10;
    private float lifetime = 0.5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!MaxSize())
            ChangeSize();

        if (Input.GetMouseButtonUp(0))
        {
            Move();
        }
    }
    
    private bool MaxSize()
    {
        if(transform.localScale.x >= maxBulletSize)
        {
            return true;
        }

        return false;
    }
    
    protected override void Move()
    {
        rb.isKinematic = false;
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
}
