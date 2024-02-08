using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : ObjectsActions
{
    [SerializeField] private GameObject path;
    [SerializeField] private Text resultOfGameText;
    [SerializeField] private GameObject endGamePanel;
    public GameObject bullet;
    public Transform spawnPoint;

    private float scaleSpeedPath = 0.3f;

    public bool isGrounded = true;
    private Rigidbody rb;
    //private Bullet bulletObj = new Bullet();
    GameObject bulletOnScene;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bulletOnScene = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver())
        {
            if (Input.GetMouseButtonDown(0))
            {
                bulletOnScene = Instantiate(bullet, spawnPoint);
            }

            //if(bullet.transform.localScale.x < maxBulletSize)
            if (bulletOnScene != null)
            {
                if (bulletOnScene.transform.localScale.x < maxBulletSize)
                {
                    Debug.Log("Min size");
                    ChangeSize();
                    //path.transform.localScale -= new Vector3(scaleSpeedPath, 0, 0) * Time.deltaTime;
                }
            }
                
            FindObstacle();
        }
    }

    private float amplitude = 0.01f; 
    private float frequency = 1f; 
    private float startTime;
    public override void Move()
    {
        float offsetY = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - startTime));
        Vector3 movement = Vector3.forward * Time.deltaTime;
        //movement.y += offsetY;
        transform.Translate(movement);
        /*
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }*/
    }


    private bool IsGrounded()
    {
        RaycastHit hit;
        float distance = 1f;
        return Physics.Raycast(transform.position, Vector3.down, out hit, distance);
    }


    private void FindObstacle()
    {
        Vector3 playerPosition = transform.position;
        Vector3 forward = transform.forward;

        Ray[] rayArray = new Ray[5];
        
        float[] offset = 
        {
            0f, 
            -(gameObject.transform.localScale.x / 2.5f), 
             (gameObject.transform.localScale.x / 2.5f), 
             (gameObject.transform.localScale.x / 4), 
            -(gameObject.transform.localScale.x / 4)
        };

        for(int i = 0; i < rayArray.Length; ++i)
        {
            Vector3 a = new Vector3(playerPosition.x + offset[i], playerPosition.y, playerPosition.z);

            rayArray[i] = new Ray(new Vector3(playerPosition.x + offset[i], playerPosition.y, playerPosition.z), forward);
            Debug.DrawRay(a, Vector3.forward, Color.green, 100f);
        }


        if (!FindHit(rayArray))
        {
            Debug.Log("Hit");
            rb.velocity = Vector3.zero;
        }

        else
        {
            if (!Input.GetMouseButton(0))
            {
                Move();
            }   
        }
        
    }

    private bool FindHit(Ray[] rayArray)
    {
        RaycastHit hit;
        float detectionDistance = 2f;

        foreach (var ray in rayArray)
        {
            if (Physics.Raycast(ray, out hit, detectionDistance))
            {
                if (hit.collider.gameObject.tag == "Obstacle")//|| hit.collider.gameObject.tag == "Infected"
                {
                    return false;
                }
            }
        }
        return true;
    }

    private bool IsGameOver()
    {
        float minimalSize = 0.7f;
        if(gameObject.transform.localScale.x <= minimalSize)
        {
            endGamePanel.SetActive(true);
            resultOfGameText.text = "Game Over";
            return true;
        }

        return false;
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
