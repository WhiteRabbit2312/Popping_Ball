using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfectedObstacles : MonoBehaviour
{
    public Material _explodeMaterial;
    GameObject[] infectedGameO;


    void Start()
    {
        Obstacles.onObstacleInfected += FindInfectedObstacles;
    }

    private void FindInfectedObstacles()
    {
        Debug.Log("Done");
        infectedGameO = GameObject.FindGameObjectsWithTag("Infected");

        if(infectedGameO != null)
            StartCoroutine("Explosion");
    }

    private IEnumerator Explosion()
    {
        foreach (var item in infectedGameO)
        {
            item.GetComponent<Animator>().Play("Explode");
            item.GetComponent<Renderer>().material = _explodeMaterial;

            Destroy(item, 0.2f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
