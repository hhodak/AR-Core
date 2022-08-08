using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class QuizManager : MonoBehaviour
{
    private List<QuestionAnswers> questionAnswers;
    public List<QuestionsAndAnswers> questionsAndAnswers;

    public GameObject[] options;
    public int currentQuestion;
    public Text questionText;
    public int questions = 0;
    public int correctAnswers = 0;

    [SerializeField] private LocalizedString localAnsweredText;
    [SerializeField] private LocalizedString localCorrectText;
    [SerializeField] private LocalizedString localPercentageText;
    public Text answeredText;
    public Text correctText;
    public Text percentageText;

    public GameObject questionContainer;
    public GameObject summaryPanel;

    private void OnEnable()
    {
        ResetQuiz();
        LoadQuestionsAndAnswers();
        questions = questionAnswers.Count;
        GenerateQuestion();
    }

    private void ResetQuiz()
    {
        questions = 0;
        correctAnswers = 0;
        questionContainer.SetActive(true);
        summaryPanel.SetActive(false);
    }

    public void NextQuestion()
    {
        questionAnswers.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questionAnswers[currentQuestion].answers[i];

            if (questionAnswers[currentQuestion].correctAnswerId == i)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (questionAnswers.Count > 0)
        {
            currentQuestion = Random.Range(0, questionAnswers.Count);
            questionText.text = questionAnswers[currentQuestion].question;
            SetAnswers();
        }
        else
        {
            ShowResult();
        }
    }
    private void LoadQuestionsAndAnswers()
    {
        for (int i = 0; i < questionsAndAnswers.Count; i++)
        {
            if (questionsAndAnswers[i].language == LocalizationSettings.SelectedLocale.Identifier.Code)
            {
                questionAnswers = questionsAndAnswers[i].questionAndAnswers;
                break;
            }
        }
    }

    void ShowResult()
    {
        summaryPanel.SetActive(true);
        questionContainer.SetActive(false);

        Test(localAnsweredText, answeredText, questions.ToString(), UpdateAnswerText);
        Test(localCorrectText, correctText, correctAnswers.ToString(), UpdateCorrectText);
        float percentage = (float)correctAnswers / questions * 100;
        Test(localAnsweredText, percentageText, percentage.ToString("F2"), UpdatePercentageText);
    }

    void Test(LocalizedString localText, Text textToChange, string argument, LocalizedString.ChangeHandler handler)
    {
        localText.Arguments = new object[] { textToChange };
        localText.StringChanged += handler;
        localText.Arguments[0] = argument;
        localText.RefreshString();
    }

    private void UpdateAnswerText(string value)
    {
        answeredText.text = value;
    }

    private void UpdateCorrectText(string value)
    {
        correctText.text = value;
    }

    private void UpdatePercentageText(string value)
    {
        percentageText.text = value;
    }


}
