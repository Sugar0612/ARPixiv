using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public Button SelfButton;

    public List<InfoStruct> m_InfoBuffer = new List<InfoStruct>();

    public event Action<InfoButton> OnButtonClick;

    private int infoIndex = 0;

    public void Start()
    {
        SelfButton.onClick.AddListener(() =>
        {
            OnButtonClick?.Invoke(this);
        });
    }

    public void NextInfo()
    {
        if (m_InfoBuffer == null || m_InfoBuffer.Count == 0)
        {
            infoIndex = 0;
            return;
        }
        infoIndex = (infoIndex + 1) % m_InfoBuffer.Count;
    }

    public void PreviInfo()
    {
        if (m_InfoBuffer == null || m_InfoBuffer.Count == 0)
        {
            infoIndex = 0;
            return;
        }
        infoIndex = (infoIndex - 1 + m_InfoBuffer.Count) % m_InfoBuffer.Count;
    }

    public InfoStruct GetCurrInfo()
    {
        return m_InfoBuffer[infoIndex];
    }
}
