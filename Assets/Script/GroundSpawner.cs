using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] SerializableDictionary<Level, GameObject> grounds;
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

		GameObject temp = Instantiate(grounds[GameManager.level], nextSpawnPoint, Quaternion.identity);
        if (GameManager.level == Level.Forest)
		{
                temp.GetComponent<Ground>().spawnTree();
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
