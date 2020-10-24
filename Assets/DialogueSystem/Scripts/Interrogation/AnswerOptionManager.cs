using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOptionManager : MonoBehaviour
{
    private AnswerOption option1, option2, option3, option4;

    public List<AnswerOption> playerOptions = new List<AnswerOption>();

    private void Awake()
    {
        option1 = new AnswerOption("Casa", AnswerCategories.LOCATION);
        option2 = new AnswerOption("Trabalho", AnswerCategories.ACTION);
        option3 = new AnswerOption("Faculdade", AnswerCategories.LOCATION);
        option4 = new AnswerOption("Rogerinho", AnswerCategories.COMPANION);

        playerOptions.Add(option1);
        playerOptions.Add(option2);
        playerOptions.Add(option3);
        playerOptions.Add(option4);
    }

    private void Start()
    {
        InterfaceManager.singleton.answerOptionsManager = this;
    }

    //Função que cria uma lista de opções de uma determinada categoria
    public List<AnswerOption> GetPlayerOptions(AnswerCategories category)
    {
        List<AnswerOption> filteredOptions = new List<AnswerOption>();

        AnswerOption[] answerOptions = playerOptions.ToArray();

        for (int i = 0; i < answerOptions.Length; i++)
        {
            if (answerOptions[i].category == category)
            {
                filteredOptions.Add(answerOptions[i]);
                Debug.Log(answerOptions[i].GetAnswerData());
            }
        }

        return filteredOptions;
    }
}
