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
				this.GetComponent<Text>().text = GameManager.scoreBdi > GameManager.scoreImac ? "Tu fais parties du bureau du BDI, toi ?" : "Tu as réussi tous tes partiels, non ?";
				break;
			case "BdiScore":
				this.GetComponent<Text>().text = "BDI : " + GameManager.scoreBdi;
				break;
			case "ImacScore":
				this.GetComponent<Text>().text = "IMAC : " + GameManager.scoreImac;
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
