using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public InfoPanel InfoPanelInstance;

    public void Start()
    {
        CloseInfoPanel();
    }

    public void CloseInfoPanel()
    {
        InfoPanelInstance.gameObject.SetActive(false);
    }

    public void OpenInfoPanel()
    {
        InfoPanelInstance.gameObject.SetActive(true);
    }
}
