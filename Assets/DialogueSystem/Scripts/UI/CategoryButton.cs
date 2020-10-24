using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    [SerializeField]
    private Button m_ButtonScript = null;
    [SerializeField]
    private Text m_ButtonText = null;
    [SerializeField]
    private AnswerCategories m_ButtonCategory = AnswerCategories.NULL;

    private UnityAction m_DisplayCategory;

    private void Awake()
    {
        m_ButtonScript = GetComponent<Button>();
        m_ButtonText = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        m_DisplayCategory += OnButtonClick;
        
        m_ButtonScript.onClick.AddListener(m_DisplayCategory);

        ButtonSetup();
    }

    void OnButtonClick()
    {
        InterfaceManager.singleton.ChangePanel(m_ButtonCategory);
    }

    void ButtonSetup()
    {
        switch(m_ButtonCategory)
        {
            case AnswerCategories.ACTION:
                m_ButtonText.text = "Actions";
                break;
            case AnswerCategories.LOCATION:
                m_ButtonText.text = "Locations";
                break;
            case AnswerCategories.COMPANION:
                m_ButtonText.text = "Companions";
                break;
        }
    }
}
