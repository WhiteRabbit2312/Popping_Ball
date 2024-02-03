using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float scaleSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        scaleSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                

                // ��������� ������ �� �������� �������
                while (transform.localScale.x > 0.0f)
                {
                    // ��������� ����� ������ �������
                    Vector3 newScale = transform.localScale - new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;

                    // ��������� ����� ������ �������
                    transform.localScale = newScale;

                    // ���� ��������� ����
                    
                }

                Debug.Log("������� �� �����: " + touch.position);

                // ����� �� ������ �������� ��� ��� ��������� �������
            }
        
            else if (touch.phase == TouchPhase.Ended)
            {

            }
        }
    }

    private void Shoot()
    {

    }
}
