using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Material _explodeMaterial;
    Renderer obstacleRenderer;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            StartCoroutine(Infection());
            
            /*
            obstacleRenderer.material = _explodeMaterial;
            animator.Play("Explode");
            Destroy(gameObject, 0.4f);*/
            Explosion(gameObject);

            Destroy(other.gameObject);
        }
    }

    private int numberOfRays = 30;
    private float rayLength = 0.7f;
    private IEnumerator Infection()
    {
        float angleStep = 360f / numberOfRays;

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = i * angleStep;
            float radians = angle * Mathf.Deg2Rad;

            Vector3 rayDirection = new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));

            Ray ray = new Ray(transform.position, rayDirection);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.black, 200f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayLength))
            {
                if (hit.collider.gameObject.tag == "Obstacle")
                {
                    Explosion(hit.collider.gameObject);
                    yield return new WaitForSeconds(0.1f);
                }
            }

        }


    }

    private void Explosion(GameObject go)
    {
        go.GetComponent<Animator>().Play("Explode");
        go.GetComponent<Renderer>().material = _explodeMaterial;
        Destroy(go, 0.4f);
    }
}
