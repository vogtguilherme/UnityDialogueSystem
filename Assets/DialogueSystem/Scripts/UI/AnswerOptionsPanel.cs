using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerOptionsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Panel = null;
    [SerializeField]
    private GameObject m_ButtonList = null;
    [SerializeField]
    private List<GameObject> m_AnswersButtons = null;

    private GameObject m_AnswerButton = null;   //Prefab do botão de resposta
    [SerializeField]
    private int m_OptionCount = 0;  //Essa variável é responsável por indicar quantas opções o jogador pode escolher

    public GameObject Panel
    {
        get { return m_Panel; }
    }

    public int OptionCount
    {
        get { return m_OptionCount; }
        set { m_OptionCount = value; }
    }

    public void ActivatePanel(AnswerOption[] options)
    {
        //Determina quantos botões serão habilitados
        OptionCount = options.Length;
        //Habilitar e instanciar mais botões se necerrário
        SetupButtons();
        //Percorrer a lista de botões e determinar o conteúdo de cada um
        for (int i = 0; i < options.Length; i++)
        {
            var button = m_AnswersButtons[i].GetComponent<AnswerButton>();

            button.AnswerOption = options[i];

            button.gameObject.SetActive(true);
        }
        //Ativa o painel com os botões de ação
        m_Panel.SetActive(true);
    }

    public void DeactivatePanel()
    {
        m_Panel.SetActive(false);
    }   

    private void Awake()
    {
        DeactivatePanel();
    }

    void SetupButtons()
    {
        m_AnswerButton = m_ButtonList.transform.GetChild(0).gameObject;

        for (int i = 0; i < m_ButtonList.transform.childCount; i++)
        {
            m_AnswersButtons.Add(m_ButtonList.transform.GetChild(i).gameObject);

            m_AnswersButtons[i].gameObject.SetActive(false);
        }

        if (m_AnswersButtons.Count < m_OptionCount)
        {
            do
            {
                GameObject bttn = Instantiate(m_AnswerButton, m_ButtonList.transform);
                m_AnswersButtons.Add(bttn);

            } while (m_AnswersButtons.Count < m_OptionCount);
        }       
    }
}