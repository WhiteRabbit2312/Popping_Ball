using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    private float scaleSpeed; // �������� ��������� �������
    public float minScale = 0.1f;   // ����������� ������, ����� �������� ������������� ��������

    public float detectionDistance = 5f;
    private bool isMousePressed = false;

    public float detectionRadius = 5f;

    public float jumpForce = 5.0f;
    public bool isGrounded = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        scaleSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSize();
        FindObstacle();
    }

    public void ChangeSize()
    {

        //Touch touch = Input.GetTouch(0);

        //if (touch.phase == TouchPhase.Began || )
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPoint);
            isMousePressed = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }

        if (isMousePressed)
        {
          
            transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;

       
            transform.localScale = Vector3.Max(transform.localScale, new Vector3(minScale, minScale, minScale));
        }
        //touch.phase == TouchPhase.Ended || 
        

    }

    public void Move()
    {

        Vector3 movement = Vector3.forward * 2f * Time.deltaTime;
        transform.Translate(movement);

        // ��������� ������
        if ( IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // ��������, �������� �� �������� �����
        RaycastHit hit;
        float distance = 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, out hit, distance);
    }

    private void FindObstacle()
    {
        // �������� ��������� ������
        Vector3 playerPosition = transform.position;

        // ������ ����������� ������ �� ������
        Vector3 forward = transform.forward;

        // ������� ��� � ����������� ������ �� ������
        Ray ray = new Ray(playerPosition, forward);
        Ray ray1 = new Ray(new Vector3(playerPosition.x - 0.72f, playerPosition.y, playerPosition.z), forward);
        Ray ray2 = new Ray(new Vector3(playerPosition.x + 0.72f, playerPosition.y, playerPosition.z), forward);
        Ray ray3 = new Ray(new Vector3(playerPosition.x + 0.4f, playerPosition.y, playerPosition.z), forward);
        Ray ray4 = new Ray(new Vector3(playerPosition.x - 0.4f, playerPosition.y, playerPosition.z), forward);

        // ������� ���������� ��� �������� ���������� � ������������
        RaycastHit hit;

        // ��������� ������������ �� ������������ ����������
        if (!Physics.Raycast(ray, out hit, detectionDistance))
        {
            Move();
            // ������ ��������� � �������� ��������� ����������
            Debug.Log("������ ��������� �� ����������: " + hit.distance);
            // ��������� �������������� ��������, ���� ����������
        }

        

        else if (!Physics.Raycast(ray1, out hit, detectionDistance))
        {
            Move();
            // ������ ��������� � �������� ��������� ����������
            Debug.Log("������ ��������� �� ����������: " + hit.distance);
            // ��������� �������������� ��������, ���� ����������
        }

        else if (!Physics.Raycast(ray2, out hit, detectionDistance))
        {
            Move();
            // ������ ��������� � �������� ��������� ����������
            Debug.Log("������ ��������� �� ����������: " + hit.distance);
            // ��������� �������������� ��������, ���� ����������
        }


        else  if (!Physics.Raycast(ray3, out hit, detectionDistance))
        {
            Move();
            // ������ ��������� � �������� ��������� ����������
            Debug.Log("������ ��������� �� ����������: " + hit.distance);
            // ��������� �������������� ��������, ���� ����������
        }

      

        else if (!Physics.Raycast(ray4, out hit, detectionDistance))
        {
            Move();
            // ������ ��������� � �������� ��������� ����������
            Debug.Log("������ ��������� �� ����������: " + hit.distance);
            // ��������� �������������� ��������, ���� ����������
        }

        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
