using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private List<InfoButton> m_InfoButtonBuffer = new List<InfoButton>();

    // UI Components
    public Image ContentImage;

    [HideInInspector] public InfoButton CurrSelectedButton;

    public void Awake()
    {
        for (int i = 0; i < m_InfoButtonBuffer.Count; i++)
        {
            int index = i;
            m_InfoButtonBuffer[index].OnButtonClick += SelectedInfoButton;
        }
    }

    public void Start()
    {
        if (m_InfoButtonBuffer.Count > 0)
            CurrSelectedButton = m_InfoButtonBuffer[0];
    }

    public void SelectedInfoButton(InfoButton button)
    {
        if (button == null) return;

        AudioManager.Get().Pause();
        for (int i = 0; i < m_InfoButtonBuffer.Count; i++)
        {
            m_InfoButtonBuffer[i].transform.localScale = Vector3.one;
        }
        CurrSelectedButton = button;
        button.transform.localScale = Vector3.one * 1.2f;

        InfoStruct infoStruct = button.GetCurrInfo();
        ContentImage.sprite = infoStruct.Image;
        //AudioManager.Get().Play(button.InfoAudio);
    }

    public InfoButton GetCurrSelectedButton()
    {
        return CurrSelectedButton;
    }

    public void ClickLeftButton()
    {
        // 如果InfoButton中只存储了一张图片那么不需要然Audio暂停
        Action audioAction = CurrSelectedButton.m_InfoBuffer.Count == 1 ? null : () => AudioManager.Get().Pause();
        audioAction?.Invoke();

        CurrSelectedButton.PreviInfo();

        InfoStruct infoStruct = CurrSelectedButton.GetCurrInfo();
        ContentImage.sprite = infoStruct.Image;
    }

    public void ClickRightButton()
    { 
        Action audioAction = CurrSelectedButton.m_InfoBuffer.Count == 1 ? null : () => AudioManager.Get().Pause();
        audioAction?.Invoke();

        CurrSelectedButton.NextInfo();

        InfoStruct infoStruct = CurrSelectedButton.GetCurrInfo();
        ContentImage.sprite = infoStruct.Image;
    }
}
