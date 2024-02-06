using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Action
{
    [SerializeField] private Text resultOfGameText;
    [SerializeField] private GameObject endGamePanel;
    public GameObject bullet;
    public Transform spawnPoint;
    //private float scaleSpeed;
    //public float minScale = 0.1f;  

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
        if (!IsGameOver())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, spawnPoint);
            }
            ChangeSize();
            FindObstacle();
            
        }
    }

    public override void Move()
    {
        Vector3 movement = Vector3.forward * 2f * Time.deltaTime;
        transform.Translate(movement);

        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float distance = 0.1f;
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
            Move();
        }
        
    }

    private bool FindHit(Ray[] rayArray)
    {
        RaycastHit hit;
        float detectionDistance = 3f;

        foreach (var ray in rayArray)
        {
            if (Physics.Raycast(ray, out hit, detectionDistance))
            {
                if (hit.collider.gameObject.tag == "Obstacle")
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

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
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
