using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
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
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
		if (spawnObstacle)
		{
            temp.GetComponent<Ground>().spawnObstacle();
            temp.GetComponent<Ground>().spawnObstacle();
		}
        temp.GetComponent<Ground>().spawnCoin();
        temp.GetComponent<Ground>().spawnTree();

    }

}
