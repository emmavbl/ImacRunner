using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		switch (gameObject.name)
		{
			case "HighScore":
				if( GameManager.scoreCrous > GameManager.scoreImac & GameManager.scoreCrous > GameManager.scoreBdi)
				{
					this.GetComponent<Text>().text =  "T'es super Crous, ça c'est sûr !";
				}
				else if (GameManager.scoreBdi > GameManager.scoreImac & GameManager.scoreBdi > GameManager.scoreCrous)
				{
					this.GetComponent<Text>().text = "T'as fait le plein en tickets conso !";
				}
				else
				{
					this.GetComponent<Text>().text = "T'as passé tous tes UE, respect !";
				}

				break;
			case "BdiScore":
				this.GetComponent<Text>().text = ": " + GameManager.scoreBdi;
				break;
			case "ImacScore":
				this.GetComponent<Text>().text = ": " + GameManager.scoreImac;
				break;
			case "CrousScore":
				this.GetComponent<Text>().text = ": " + GameManager.scoreCrous;
				break;
			default:
				break;
		}

	}

    // Update is called once per frame
    void Update()
    {

    }
}
