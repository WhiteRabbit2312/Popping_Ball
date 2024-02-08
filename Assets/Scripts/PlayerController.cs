using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ObjectsActions
{
    [SerializeField] private GameObject path;
    [SerializeField] private Text resultOfGameText;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;

    private Rigidbody rb;
    private GameObject bulletOnScene;
    private static float playerSize;

    public static float PlayerSize
    {
        get => playerSize;
        private set => playerSize = value;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bulletOnScene = new GameObject();
    }

    void Update()
    {
        if (!IsGameOver())
        {
            PlayerSize = transform.localScale.x;
            if (Input.GetMouseButtonDown(0))
            {
                bulletOnScene = Instantiate(bullet, spawnPoint);
            }

            if (bulletOnScene != null)
            {
                if (bulletOnScene.transform.localScale.x < maxBulletSize)
                {
                    ChangeSize();
                }
            }
                
            FindObstacle();
        }
    }

    public override void Move()
    {
        Vector3 movement = Vector3.forward * Time.deltaTime;
        transform.Translate(movement);
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

}
