using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Action
{
    public GameObject bullet;
    public Transform spawnPoint;
    //private float scaleSpeed; // Скорость изменения размера
    //public float minScale = 0.1f;   // Минимальный размер, чтобы избежать отрицательных значений

    public float detectionDistance = 15f;
    //private bool isMousePressed = false;

    public float detectionRadius = 5f;

    public float jumpForce = 5.0f;
    public bool isGrounded = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPoint);
        }
        ChangeSize();
        FindObstacle();
       
    }

    public override void Move()
    {
        Vector3 movement = Vector3.forward * 2f * Time.deltaTime;
        transform.Translate(movement);

        // Обработка прыжка
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Проверка, касается ли персонаж земли
        RaycastHit hit;
        float distance = 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, out hit, distance);
    }


    private void FindObstacle()
    {
        // Получаем положение игрока
        Vector3 playerPosition = transform.position;

        // Задаем направление вперед от игрока
        Vector3 forward = transform.forward;

        // Создаем луч в направлении вперед от игрока
        /*
        Ray ray = new Ray(playerPosition, forward);
        Ray ray1 = new Ray(new Vector3(playerPosition.x - 0.72f, playerPosition.y, playerPosition.z), forward);
        Ray ray2 = new Ray(new Vector3(playerPosition.x + 0.72f, playerPosition.y, playerPosition.z), forward);
        Ray ray3 = new Ray(new Vector3(playerPosition.x + 0.4f, playerPosition.y, playerPosition.z), forward);
        Ray ray4 = new Ray(new Vector3(playerPosition.x - 0.4f, playerPosition.y, playerPosition.z), forward);
        */
        Ray[] rayArray = new Ray[5];
        
        float[] offset = 
        {
            0f, 
            -(gameObject.transform.localScale.x / 2), 
             (gameObject.transform.localScale.x / 2), 
             (gameObject.transform.localScale.x / 4), 
            -(gameObject.transform.localScale.x / 4)
        };

        for(int i = 0; i < rayArray.Length; ++i)
        {
            Vector3 a = new Vector3(playerPosition.x + offset[i], playerPosition.y, playerPosition.z);

            rayArray[i] = new Ray(new Vector3(playerPosition.x + offset[i], playerPosition.y, playerPosition.z), forward);
            Debug.DrawRay(a, Vector3.forward, Color.green, 100f);
        }
        /*
        rayArray[0] = new Ray(playerPosition, forward);
        rayArray[1] = new Ray(new Vector3(playerPosition.x + (gameObject.transform.localScale.x / 2), playerPosition.y, playerPosition.z), forward);
        rayArray[2] = new Ray(new Vector3(playerPosition.x - (gameObject.transform.localScale.x / 2), playerPosition.y, playerPosition.z), forward);
        rayArray[2] = new Ray(new Vector3(playerPosition.x + (gameObject.transform.localScale.x / 4), playerPosition.y, playerPosition.z), forward);
        rayArray[2] = new Ray(new Vector3(playerPosition.x - (gameObject.transform.localScale.x / 4), playerPosition.y, playerPosition.z), forward);

        

        for (int i = 0; i < rayArray.Length; ++i)
        {
            Debug.DrawRay(rayArray[i].direction, Vector3.forward, Color.green, 100f);
        }

        */

        // Создаем переменную для хранения информации о столкновении
        RaycastHit hit;

        

        foreach (var ray in rayArray)
        {
            if (Physics.Raycast(ray, out hit, detectionDistance))
            {
                if(hit.collider.gameObject.tag == "Obstacle")
                {
                    rb.velocity = Vector3.zero;
                }
                
            }

            else
            {
                Move();
            }
        }

        /*
        // Проверяем столкновение на определенном расстоянии
        if (!Physics.Raycast(ray, out hit, detectionDistance))
        {
            Move();
            // Объект находится в пределах заданного расстояния
            Debug.Log("Объект обнаружен на расстоянии: " + hit.distance);
            // Выполните дополнительные действия, если необходимо
        }

        

        else if (!Physics.Raycast(ray1, out hit, detectionDistance))
        {
            Move();
            // Объект находится в пределах заданного расстояния
            Debug.Log("Объект обнаружен на расстоянии: " + hit.distance);
            // Выполните дополнительные действия, если необходимо
        }

        else if (!Physics.Raycast(ray2, out hit, detectionDistance))
        {
            Move();
            // Объект находится в пределах заданного расстояния
            Debug.Log("Объект обнаружен на расстоянии: " + hit.distance);
            // Выполните дополнительные действия, если необходимо
        }


        else  if (!Physics.Raycast(ray3, out hit, detectionDistance))
        {
            Move();
            // Объект находится в пределах заданного расстояния
            Debug.Log("Объект обнаружен на расстоянии: " + hit.distance);
            // Выполните дополнительные действия, если необходимо
        }

      

        else if (!Physics.Raycast(ray4, out hit, detectionDistance))
        {
            Move();
            // Объект находится в пределах заданного расстояния
            Debug.Log("Объект обнаружен на расстоянии: " + hit.distance);
            // Выполните дополнительные действия, если необходимо
        }

        else
        {
            rb.velocity = Vector3.zero;
        }*/
    }
}
