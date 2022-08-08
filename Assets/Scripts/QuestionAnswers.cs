using System.Collections.Generic;

[System.Serializable]
public class QuestionAnswers
{
    public string question;
    public string[] answers;
    public int correctAnswerId;
}

[System.Serializable]
public class QuestionsAndAnswers
{
    public string language;
    public List<QuestionAnswers> questionAndAnswers;
}
