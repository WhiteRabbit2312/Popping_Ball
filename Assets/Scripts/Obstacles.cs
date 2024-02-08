
using UnityEngine;
using System;

public class Obstacles : MonoBehaviour
{
    private float rayLength;
    public static Action onObstacleInfected;
    private int numberOfRays = 50;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            rayLength = other.gameObject.transform.localScale.x;
            gameObject.tag = "Infected";
            Infection();
            onObstacleInfected?.Invoke();
            Destroy(other.gameObject);
        }
    }

    private void Infection()
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
                    hit.collider.gameObject.tag = "Infected";
                }
            }
        }
    } 
}
