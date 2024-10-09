using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        SessionData.Instance.LoadScore();
        SetBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBestScoreText() {
        scoreText.text = "Best Score: " + SessionData.Instance.bestScorePlayerName + ": " + SessionData.Instance.bestScore.ToString();
    }

    public void OnClick_StartButton() {
        SessionData.Instance.playerName = playerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void OnClick_ExitButton() {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
