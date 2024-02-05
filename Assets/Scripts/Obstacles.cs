using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Material _explodeMaterial;
    Renderer renderer;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
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
            renderer.material = _explodeMaterial;
            animator.Play("Explode");
            Destroy(gameObject, 0.4f);
        }
    }
}
