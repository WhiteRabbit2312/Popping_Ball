using System.Collections;
using UnityEngine;

public class InfectedObstacles : MonoBehaviour
{
    public Material _explodeMaterial;
    private GameObject[] infectedGameO;


    void Start()
    {
        Obstacles.onObstacleInfected += FindInfectedObstacles;
    }

    private void FindInfectedObstacles()
    {
        infectedGameO = GameObject.FindGameObjectsWithTag("Infected");

        StartCoroutine("Explosion");
    }

    private IEnumerator Explosion()
    {
        foreach (var item in infectedGameO)
        {
            if(item != null)
            {
                item.GetComponent<Animator>().Play("Explode");
                item.GetComponent<Renderer>().material = _explodeMaterial;

                Destroy(item, 0.2f);
                yield return new WaitForSeconds(0.1f);
            }
            
        }
    }
}
