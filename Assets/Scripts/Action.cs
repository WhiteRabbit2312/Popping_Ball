using UnityEngine;
public abstract class Action : MonoBehaviour
{
    [SerializeField] private bool isMousePressed;

    [SerializeField] private float scaleSpeed;

    protected void ChangeSize()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(bullet, spawnPoint);
            isMousePressed = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }

        if (isMousePressed)
        {

            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;


            //transform.localScale = Vector3.Max(transform.localScale, new Vector3(minScale, minScale, minScale));
        }
    }
    public abstract void Move();
}
