using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField]
    private Button m_ButtonScript = null;
    [SerializeField]
    private Text m_ButtonText = null;

    private AnswerOption m_AnswerOption;

    public AnswerOption AnswerOption
    {
        get
        {
            return m_AnswerOption;
        }
        set
        {
            m_AnswerOption = value;
            ButtonSetup();
        }
    }

    private void OnButtonClick()
    {
        //Completar a frase da resposta (interface)
    }

    private void ButtonSetup()
    {
        m_ButtonScript = GetComponent<Button>();
        m_ButtonText = GetComponentInChildren<Text>();

        m_ButtonText.text = m_AnswerOption.title;

        m_ButtonScript.onClick.AddListener(OnButtonClick);
    }    
}
