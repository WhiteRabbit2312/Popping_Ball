using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Bullet: ObjectsActions
{
    public float speed = 100f; // Скорость полета пули
    public float lifetime = 2f;

    private void Awake()
    {
        
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
            Debug.Log("Max");
            return true;
        }
        Debug.Log("Min");

        return false;
    }
    
    public override void Move()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
}
