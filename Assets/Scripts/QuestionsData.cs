using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuestionsData : MonoBehaviour
{
    public Questions questions;
    [SerializeField] private Text _questionText;

    void Start()
    {

    }
    public void AskQuestion()
    {
        if(CountValidQuestions() == 0)
        {
            _questionText.text = string.Empty;
            ClearQuestion();
            SceneManager.LoadScene("MainMenu");
            return;
        }
        var randomIndex = 0;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, questions.questionsList.Count);
        } while (questions.questionsList[randomIndex].questioned == true);
        questions.currentQuestion = randomIndex;
        questions.questionsList[questions.currentQuestion].questioned = true;
        _questionText.text = questions.questionsList[questions.currentQuestion].question;
    }

    public void ClearQuestion()
    {
        print("Cleared Questions");
    }
    private int CountValidQuestions()
    {
        int ValidQuestions = 0;
        foreach (var question in questions.questionsList)
        {
            if (question.questioned == false)
                ValidQuestions++;
        }
        Debug.Log("Questions Left" + ValidQuestions);
        return ValidQuestions;
    }
}
