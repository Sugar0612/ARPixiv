using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private List<InfoButton> m_InfoBuffer = new List<InfoButton>();

    // UI Components
    public Image ContentImage;

    [HideInInspector] public InfoButton CurrSelectedButton;

    public void Awake()
    {
        for (int i = 0; i < m_InfoBuffer.Count; i++)
        {
            int index = i;
            m_InfoBuffer[index].OnButtonClick += SelectedInfoButton;
        }
    }

    public void SelectedInfoButton(InfoButton button)
    {
        for (int i = 0; i < m_InfoBuffer.Count; i++)
        {
            m_InfoBuffer[i].transform.localScale = Vector3.one;
        }
        CurrSelectedButton = button;
        button.transform.localScale = Vector3.one * 1.2f;
        ContentImage.sprite = button.GetCurrSprite();
        //AudioManager.Get().Play(button.InfoAudio);
    }

    public InfoButton GetCurrSelectedButton()
    {
        return CurrSelectedButton;
    }
}
