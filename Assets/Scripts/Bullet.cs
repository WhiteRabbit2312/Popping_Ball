using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: Action
{
    //public float scaleSpeed = 0.5f; // �������� ��������� �������
    //public float minScale = 0.1f;   // ����������� ������, ����� �������� ������������� ��������

    //private bool isMousePressed = true;

    public float speed = 100f; // �������� ������ ����
    public float lifetime = 2f;

    void Update()
    {
        ChangeSize();

        if (Input.GetMouseButtonUp(0))
        {
            Move();
        }
    }


    public override void Move()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
}
