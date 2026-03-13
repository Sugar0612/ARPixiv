using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTransformChange : MonoBehaviour
{

    [Header("Model Rotation")]
    public float rotationSpeed = 0.3f;

    [Header("Model Rotation")]
    public float scaleSpeed = 0.01f;      // 缩放灵敏度，可根据手感调整
    public float minScale = 0.5f;          // 最小缩放倍数
    public float maxScale = 2.0f;           // 最大缩放倍数

    private Touch touchZero;
    private Touch touchOne;
    private float previousDistance;         // 上一帧两指距离

    public GameObject NeedChangeObject;    

    private static ModelTransformChange _instance;

    public static ModelTransformChange Get()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<ModelTransformChange>();
        }
        return _instance;
    }

    public void FixedUpdate()
    {
        if (NeedChangeObject != null)
        {
            ModelRotation();
            PinchScale();
        }
    }

    private void ModelRotation()
    {
        // 仅当恰好只有一根手指触摸时旋转
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x;
                NeedChangeObject.transform.Rotate(0, -deltaX * rotationSpeed, 0, Space.Self);
            }
        }
    }

    private void PinchScale()
    {
        // 仅当有两根手指触摸时执行缩放
        if (Input.touchCount == 2)
        {
            touchZero = Input.GetTouch(0);
            touchOne = Input.GetTouch(1);

            // 计算当前两指在屏幕空间的距离
            float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            // 如果是双指刚开始触摸，只记录距离，不进行缩放
            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                previousDistance = currentDistance;
                return;
            }

            // 计算距离变化量（当前距离 - 上一帧距离）
            float deltaDistance = currentDistance - previousDistance;

            // 根据变化量调整缩放倍数
            // 距离变大（手指撑开）→ 正变化 → 放大
            // 距离变小（手指捏合）→ 负变化 → 缩小
            if (Mathf.Abs(deltaDistance) > 0.01f) // 忽略微小抖动
            {
                // 计算新的缩放倍数 = 当前倍数 + 变化量 × 灵敏度
                float newScale = NeedChangeObject.transform.localScale.x + deltaDistance * scaleSpeed;
                // 限制在最小/最大范围内
                newScale = Mathf.Clamp(newScale, minScale, maxScale);
                // 应用新的缩放（均匀缩放）
                NeedChangeObject.transform.localScale = Vector3.one * newScale;
            }

            // 更新上一帧距离供下一帧使用
            previousDistance = currentDistance;
        }
    }
}
