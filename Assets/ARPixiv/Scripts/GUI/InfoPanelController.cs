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
        AudioManager.Get().ShutDown();
    }

    public void OpenInfoPanel()
    {
        InfoPanelInstance.gameObject.SetActive(true);
        InfoPanelInstance.SelectedInfoButton(InfoPanelInstance.GetCurrSelectedButton());
    }

    public void PlayAudio()
    {
        AudioManager.Get().Play(InfoPanelInstance.GetCurrSelectedButton().GetCurrInfo().Clip);
    }
}
