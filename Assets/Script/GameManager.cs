using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Level
{
    Forest,
    Classroom,
    City
}

public class GameManager : MonoBehaviour
{

    static public int scoreImac;
    static public int scoreBdi;
    static public int scoreCrous;

	public Text bdiScoreText;
	public Text imacScoreText;
	public Text crousScoreText;

	static public int highScore;
    public static GameManager inst;

    public Level level = Level.Forest;
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


    public void resetGame()
    {
        // reset score
        scoreImac = 0;
        scoreBdi = 0;
        scoreCrous = 0;

        // reset level
        level = Level.Forest;
        groundLeft = 20;
    }


    public void IncrementScore(Type typeOfCoin)
    {
        Debug.Log(typeOfCoin);

		switch (typeOfCoin)
		{
			case Type.Coin:
                scoreImac++;
                break;
			case Type.Ticket:
                scoreBdi++;
                break;
            case Type.Point:
                scoreCrous++;
                break;
			default:
                Debug.Log("error");
				break;
		}

        bdiScoreText.text = "BDI : " + scoreBdi;
        imacScoreText.text = "IMAC : " + scoreImac;
        crousScoreText.text = "CROUS : " + scoreCrous;

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
            level = level == Level.Classroom ? Level.Forest : Level.Classroom;

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
