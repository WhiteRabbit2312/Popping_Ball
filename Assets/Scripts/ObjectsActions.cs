using UnityEngine;
public abstract class ObjectsActions : MonoBehaviour
{
    [SerializeField] private bool isMousePressed;

    [SerializeField] private float scaleSpeed;
    [SerializeField] private float borderSize;

    protected float maxBulletSize = 1.5f;

    protected void ChangeSize()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }

        if (isMousePressed)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
        }
    }
    protected abstract void Move();
}
