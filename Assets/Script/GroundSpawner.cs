using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject insideTile;
    [SerializeField] GameObject outsideTile;
    [SerializeField] GameObject cityTile;
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

		switch (GameObject.FindObjectOfType<GameManager>().level)
		{
            case Level.Forest:
                temp = Instantiate(outsideTile, nextSpawnPoint, Quaternion.identity);
                temp.GetComponent<Ground>().spawnTree();
                break;
            case Level.Classroom:
                temp = Instantiate(insideTile, nextSpawnPoint, Quaternion.identity);
                break;
            case Level.City:
                temp = Instantiate(cityTile, nextSpawnPoint, Quaternion.identity);
                break;
            default:
                temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
                break;
        }

        nextSpawnPoint = temp.transform.Find("SpawnPoint").transform.position;
		if (spawnObstacle)
		{
            // random how many obstacles
            temp.GetComponent<Ground>().spawnObstacle();
            temp.GetComponent<Ground>().spawnObstacle();
		}

        temp.GetComponent<Ground>().spawnCoin();

        // alert GameManager we spawn a new ground 
        GameObject.FindObjectOfType<GameManager>().newSpawn();
    }

}
