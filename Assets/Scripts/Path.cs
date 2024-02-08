using UnityEngine;

public class Path : MonoBehaviour
{
    private float scaleSpeedPath = 0.07f;
    private bool isMousePressedPath = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressedPath = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressedPath = false;
        }

        if (isMousePressedPath)
        {
            transform.localScale -= new Vector3(scaleSpeedPath, 0, 0) * Time.deltaTime;
        }
    }
}
