using UnityEngine;
using UnityEngine.UI;

public class ModelClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        ModelTransformChange.Get().NeedChangeObject = gameObject;
    }
}