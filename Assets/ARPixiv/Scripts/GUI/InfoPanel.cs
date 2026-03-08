using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private List<InfoButton> m_InfoBuffer = new List<InfoButton>();

    // UI Components
    
    public Text ContentText;

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
        button.transform.localScale = Vector3.one * 1.2f;
        ContentText.text = button.InfoContent;
    }
}
