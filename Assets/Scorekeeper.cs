using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreText;
    [SerializeField] Text sceneText;
    const int DEFAULT_POINTS = 1;
    const int SCORE_TO_ADVANCE = 10;
    int level;
    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        playerName = PersistentData.Instance.GetName();
        level = SceneManager.GetActiveScene().buildIndex - 1;
        DisplayScore();
        sceneText.text = "Level " + (level);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PersistentData.Instance.SetScore(score);
        DisplayScore();
        Invoke("AdvanceLevel", 0.2f);
        
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AdvanceLevel()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void DisplayScore()
    {
        Debug.Log(scoreText.text);
        scoreText.text = playerName + " Score: " + score;
    }
}
