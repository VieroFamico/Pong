using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IManager
{
    [SerializeField] TextMeshProUGUI PlayerScore;
    [SerializeField] TextMeshProUGUI EnemyScore;

    GameObject Ball;
    GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        GameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        GameOverScreen.SetActive(false);
        Debug.Log(PlayerScore.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerScoreUpdate()
    {
        PlayerScore.text = (int.Parse(PlayerScore.text) + 1).ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (int.Parse(PlayerScore.text) > 7)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }
    public void EnemyScoreUpdate()
    {
        EnemyScore.text = (int.Parse(EnemyScore.text) + 1).ToString();

        if (int.Parse(EnemyScore.text) > 7)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }
}
