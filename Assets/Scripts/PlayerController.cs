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
                

                // Уменьшаем объект до нулевого размера
                while (transform.localScale.x > 0.0f)
                {
                    // Вычисляем новый размер объекта
                    Vector3 newScale = transform.localScale - new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;

                    // Применяем новый размер объекта
                    transform.localScale = newScale;

                    // Ждем следующий кадр
                    
                }

                Debug.Log("Нажатие на экран: " + touch.position);

                // Здесь вы можете добавить ваш код обработки нажатия
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
