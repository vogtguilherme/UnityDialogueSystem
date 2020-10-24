using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dialogue.Vocabulary
{
    public class AnswerManager : MonoBehaviour
    {
        [SerializeField]
        TMP_Text text = null;
        [SerializeField]
        private string richText = null;

        public void DefineWord(string word)
        {
            string answer = null;

            answer = "Comendo " + richText + word + "<color=white> de curioso.";

            text.text = answer;
        }
    }
}