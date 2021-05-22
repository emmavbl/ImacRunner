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
					this.GetComponent<Text>().text =  "T'es crous ?";
				}
				else if (GameManager.scoreBdi > GameManager.scoreImac & GameManager.scoreBdi > GameManager.scoreCrous)
				{
					this.GetComponent<Text>().text = "Tu fais parties du bureau du BDI, toi ?";
				}
				else
				{
					this.GetComponent<Text>().text = "Tu as réussi tous tes partiels, non ? ";
				}

				break;
			case "BdiScore":
				this.GetComponent<Text>().text = "BDI : " + GameManager.scoreBdi;
				break;
			case "ImacScore":
				this.GetComponent<Text>().text = "IMAC : " + GameManager.scoreImac;
				break;
			case "CrousScore":
				this.GetComponent<Text>().text = "CROUS : " + GameManager.scoreCrous;
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
