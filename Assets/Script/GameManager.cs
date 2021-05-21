using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Level
{
    Outside,
    Inside
}

public class GameManager : MonoBehaviour
{

    static public int score;
    static public int highScore;
    public static GameManager inst;

    public Level level = Level.Outside;
    [SerializeField] int groundLeft = 20; // number of ground spawn left before next level

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

    public void resetGame()
    {
        // reset score
        score = 0;

        // reset level
        level = Level.Outside;
        groundLeft = 20;
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

    // Decrement level time and check if null for the next level to spawn
    public void newSpawn()
	{
        groundLeft--;
        if (groundLeft <= 0)
		{
            // random on new level
            level = level == Level.Inside ? Level.Outside : Level.Inside;

            // random on level duration (int), between [3, 25]
            groundLeft = 20;

		}
	}

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
