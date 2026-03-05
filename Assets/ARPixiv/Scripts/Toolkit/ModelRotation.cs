using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    public float rotationSpeed = 0.3f;

    void Update()
    {
        // 仅当恰好只有一根手指触摸时旋转
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x;
                transform.Rotate(0, -deltaX * rotationSpeed, 0, Space.Self);
            }
        }
    }
}