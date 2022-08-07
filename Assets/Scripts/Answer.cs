using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void AnswerResult()
    {
        if (isCorrect)
        {
            Debug.Log("Correct!");
            quizManager.correctAnswers++;
        }
        else
        {
            Debug.Log("False!");
        }
        quizManager.NextQuestion();
    }
}
