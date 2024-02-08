using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Text resultOfGameText;
    [SerializeField] private GameObject endGamePanel;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            animator.SetTrigger("OpenDoor");

            endGamePanel.SetActive(true);
            resultOfGameText.text = "You win!";

        }
    }
}
