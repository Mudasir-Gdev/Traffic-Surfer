using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    private CarController car;
    public bool gameover;
    private bool record;
    private int Score;
    public GameObject GameOverPanel;
    private int SaveScore;

    public TextMeshProUGUI SpeedUi;
    public TextMeshProUGUI DistanceUI;
    public TextMeshProUGUI ScoredUI;
    
    
    void Start()
    {
        car = GetComponent<CarController>();

       
    }
    private void Update()
    {
        
        
        DistanceRecord();
    }


    private void Awake()
    {
        
        if (Singleton == null)
        {

            Singleton = this;
        }
        else if (Singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        
    }
    public void GameOver()
    {

        Debug.Log("GameOver Called");
        gameover = true;
        GameOverPanel.SetActive(true);
        SaveScore = Score;

    }
    public void UpdateSpeed(int speed)
    {
        SpeedUi.text = "Speed\n" + speed;

    }
    public void Distance(int distance)
    {
        DistanceUI.text = "Distance " + distance;
        
        if (SaveScore< distance)
            Score = distance;
            SaveScore = Score;
               
        
    }
    public void DistanceRecord()
    {
        
        ScoredUI.text = "Scored " + SaveScore;
        DontDestroyOnLoad(ScoredUI);
        
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
   

}
