using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public Button SelfButton;

    public List<Sprite> m_ImageBuffer = new List<Sprite>();

    public AudioClip InfoAudio;

    public event Action<InfoButton> OnButtonClick;

    private int imageIndex = 0;

    public void Start()
    {
        SelfButton.onClick.AddListener(() =>
        {
            OnButtonClick?.Invoke(this);
        });
    }

    public void NextImage()
    {
        if (m_ImageBuffer == null || m_ImageBuffer.Count == 0)
        {
            imageIndex = 0;
            return;
        }
        imageIndex = (imageIndex + 1) % m_ImageBuffer.Count;
    }

    public void PreviImage()
    {
        if (m_ImageBuffer == null || m_ImageBuffer.Count == 0)
        {
            imageIndex = 0;
            return;
        }
        imageIndex = (imageIndex - 1 + m_ImageBuffer.Count) % m_ImageBuffer.Count;
    }

    public Sprite GetCurrSprite()
    {
        return m_ImageBuffer[imageIndex];
    }
}
