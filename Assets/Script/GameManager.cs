using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    static public int score;
    static public int highScore;
    public static GameManager inst;

    private void Awake()
    {
        Debug.Log("Awake");
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void setScore()
	{
		if (score >= highScore)
		{
            highScore = score;
		}
	}

    public void resetScore()
    {
        score = 0;
    }

    public void setText()
	{
        FindObjectsOfType<ScoreText>()[1].GetComponent<Text>().text = "Score : " + score;
        Debug.Log(FindObjectsOfType<ScoreText>()[1].GetComponent<Text>().text);
        Debug.Log(score);
        FindObjectsOfType<ScoreText>()[0].GetComponent<Text>().text = "HighScore : " + highScore;
    }

    public void IncrementScore()
    {
        score++;
        FindObjectOfType<PlayerController>().scoreText.text = "SCORE : " + score;

        // Increase the player speed
        FindObjectOfType<PlayerController>().speed += FindObjectOfType<PlayerController>().speedIncreasePerPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
