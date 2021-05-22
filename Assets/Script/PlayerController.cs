using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] float laneSize = 10 / 3;
    [SerializeField] float turnspeed = 5;
    public float speed = 5;
    public float speedIncreasePerPoint = .05f;
    bool alive = true;

    private int targetLane = 1; // 0:left 1:middle 2:right

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().resetGame();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = transform.position;

        //defin 
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
            targetLane--;
			if (targetLane == -1)
			{
                targetLane = 0;
			}
		} else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            targetLane++;
            if (targetLane == 3)
            {
                targetLane = 2;
            }
        }

        //change target position
		switch (targetLane)
		{
            case 0 :
                targetPosition.x = -laneSize;
                break;
            case 1 :
                targetPosition.x = 0;
                break;
            case 2 :
                targetPosition.x = laneSize;
                break;
            default:
			    break;
	    }

		if (alive)
		{
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * turnspeed);
		}
    }

	private void FixedUpdate()
	{
		if (alive)
		{
            transform.position += Vector3.forward * speed * Time.fixedDeltaTime;
		}
	}

    public void die()
    {
        alive = false;

        FindObjectOfType<AudioManager>().play("PlayerDeath");
        FindObjectOfType<GameManager>().setScore();
        
        //set death animation

        Invoke("gameOver", 1);
        
    }

    void gameOver()
    {
        SceneManager.LoadScene(2); // Game
    }


}
