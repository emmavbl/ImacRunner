using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject InsideTile;
    [SerializeField] GameObject OutsideTile;
    Vector3 nextSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnPoint = transform.position;
		for (int i = 0; i < 19; i++)
		{
			if (i < 2)
			{
                spawnTile(false);
			}
			else
			{
                spawnTile(true);
			}
		}
    }

    public void spawnTile(bool spawnObstacle)
	{

        GameObject temp;
        //GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);

		if (GameObject.FindObjectOfType<GameManager>().level == Level.Outside)
		{
            temp = Instantiate(OutsideTile, nextSpawnPoint, Quaternion.identity);
		} else
		{
            temp = Instantiate(InsideTile, nextSpawnPoint, Quaternion.identity);
        }

        nextSpawnPoint = temp.transform.Find("SpawnPoint").transform.position;
		if (spawnObstacle)
		{
            temp.GetComponent<Ground>().spawnObstacle();
            temp.GetComponent<Ground>().spawnObstacle();
		}
        temp.GetComponent<Ground>().spawnCoin();

        if (GameObject.FindObjectOfType<GameManager>().level == Level.Outside)
        {
            temp.GetComponent<Ground>().spawnTree();
        }

        // alert GameManager we spawn a new ground 
        GameObject.FindObjectOfType<GameManager>().newSpawn();
    }

}
