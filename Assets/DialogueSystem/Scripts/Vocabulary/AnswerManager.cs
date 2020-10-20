using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text text = null;

    public void DefineWord(string word)
    {
        string answer = null;

        answer = "Comendo " + word + " de curioso.";

        text.text = answer;
    }
}
