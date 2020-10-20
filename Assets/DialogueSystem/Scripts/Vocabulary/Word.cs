using System;

namespace Dialogue.Vocabulary
{
    public enum WordClasses
    {
        verb, noun, article
    };

    [Serializable()]
    public class Word
    {
        public string word;// { get; set; }
        public WordClasses wordClass;// { get; set; }

        public Word(string word = "null", WordClasses wordClass = WordClasses.noun)
        {
            this.word = word;
            this.wordClass = wordClass;
        }        

        public Word(){}

        public string Show()
        {
            string message = string.Format("Word: {0} Class: {1}", word, wordClass);

            return message;
        }
    }
}