using Dialogue.Vocabulary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordsData", menuName = "ScriptableObjects/Vocab")]
public class WordData : ScriptableObject
{
    public Word[] words;
}