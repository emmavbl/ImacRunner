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
    [SerializeField] int numberOfGroundSpawnInLevel = 20;

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

    // Decrement level time and check if null for the next level to spawn
    public void newSpawn()
	{
        numberOfGroundSpawnInLevel--;
        if (numberOfGroundSpawnInLevel <= 0)
		{
            // random on new level
            level = Level.Inside;

            // random on level duration

		}
	}

    // Start is called before the first frame update
    void Start()
    {
        //initialise le niveau 
        level = Level.Outside;
        numberOfGroundSpawnInLevel = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
