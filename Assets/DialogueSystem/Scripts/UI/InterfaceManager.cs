using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager singleton { get; set; } 

    [SerializeField]
    AnswerCategories m_ActivePanelCategory = AnswerCategories.NULL;
    [SerializeField]
    private AnswerOptionsPanel m_AnswerOptionsPanel = null;
    [SerializeField]
    private AnswerOptionManager m_AnswerOptionsManager = null;

    public AnswerOptionsPanel answerOptionsPanel
    {
        get { return m_AnswerOptionsPanel; }
        set { m_AnswerOptionsPanel = value; }
    }

    public AnswerOptionManager answerOptionsManager
    {
        get { return m_AnswerOptionsManager; }
        set { m_AnswerOptionsManager = value; }
    }


    private void Awake()
    {
        SingletonSetup();

        if(m_AnswerOptionsPanel == null)
        {
            m_AnswerOptionsPanel = GetComponent<AnswerOptionsPanel>();
        }
    }

    public void ChangePanel(AnswerCategories category)
    {
        if(category == m_ActivePanelCategory)
        //Se a categoria que o jogador selecionou é a mesma que já foi selecionada
        {
            //Ocultar o painel de respostas
            HideAnswersPanel();
        }
        else
        //Senão... (selecionou outra categoria)
        {
            /*Sistema deve:
            - fazer animação do painel
            - modificar o conteúdo dos botões
            */

            if(category != AnswerCategories.NULL)
            {
                HideAnswersPanel();
            }

            ShowAnswersPanel(category);
        }
    }

    private void ShowAnswersPanel(AnswerCategories category)
    {
        /*Função deve abrir o painel de ações do jogador com base no contexto
         * Ou seja, um botão de categoria de "Locais" fará com que os botões de ações sejam
         * criados nesse contexto (ex.: casa, trabalho, faculdade, etc.)*/       

        m_ActivePanelCategory = category;

        SetupOptionsPanel(category);
    }

    private void HideAnswersPanel()
    {
        m_AnswerOptionsPanel.DeactivatePanel();

        m_ActivePanelCategory = AnswerCategories.NULL;
    }

    void SetupOptionsPanel(AnswerCategories category)
    {
        AnswerOption[] options = m_AnswerOptionsManager.GetPlayerOptions(category).ToArray();

        m_AnswerOptionsPanel.ActivatePanel(options);
    }

    void SingletonSetup()
    {
        if (singleton == null && singleton != this)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
