using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PassLevel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text timeText;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button menuButton;

    private string score;
    private float totalLevel;

    private void Start()
    {
        LevelCompleted(GameManager.Instance.GetPoints(), GameManager.Instance.GetTime());
        menuButton.onClick.AddListener(OnButtonBack);
        continueButton.onClick.AddListener(OnButtonContinue);
    }
    private void LevelCompleted(int points, float time)
    {
        float p = (float)points / 12;
        
        if (p < 0.5)
        {
            score = "C";
        }
        else if (p < 0.95)
        {
            score = "B";
        }
        else
        {
            score = "A";
        }
        scoreText.text = $"{score}";
        timeText.text = $"{(float)Math.Round(time,2)}";

        totalLevel =  p*100 - (float)(0.3 * time);

        if (totalLevel < 0)
        {
            totalLevel = 0;
        } 
        
        GameManager.Instance.Scores(totalLevel);
    }

    private void OnButtonBack()
    {
        GameManager.Instance.MainMenu();
    }
    private void OnButtonContinue()
    {
        GameManager.Instance.ContinueLevel();
    }
    
    
}