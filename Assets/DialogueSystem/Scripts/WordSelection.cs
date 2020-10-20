using Dialogue.Vocabulary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSelection : MonoBehaviour
{
    [Header("UI")]
    public Text selectedText = null;
    [Space(2)]
    [Header("Word Data")]
    [SerializeField]
    private WordData wordData;
    private Word[] words;

    private AnswerManager m_AnswerManager = null;

    [SerializeField]
    private int wordIndex = 0;
    [SerializeField]
    private int wordCount;

    private void Awake()
    {
        m_AnswerManager = GetComponent<AnswerManager>();

        VocabularySetup();
    }

    private void Start()
    {
        DisplayWord(words[wordIndex]);
    }

    public void DisplayWord(Word displayWord)
    {
        Debug.Log("Word Index: " + wordIndex);
        
        selectedText.text = displayWord.word;

        m_AnswerManager.DefineWord(displayWord.word);
    }

    public void Bttn_NextWord()
    {
        wordIndex++;

        if(wordIndex >= wordCount)
        {
            wordIndex = 0;
        }

        DisplayWord(words[wordIndex]);
    }

    public void Bttn_PreviousWord()
    {
        wordIndex--;

        if (wordIndex <= 0)
        {
            wordIndex = wordCount;
        }

        DisplayWord(words[wordIndex]);
    }

    private void VocabularySetup()
    {
        words = new Word[wordData.words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = new Word(wordData.words[i].word, wordData.words[i].wordClass);
            Debug.Log(words[i].Show());
        }

        wordCount = words.Length;
        Debug.Log("Word count: " + wordCount);
    }
}