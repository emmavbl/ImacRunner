using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GroundSpawner spawner;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject ticket;
    [SerializeField] GameObject pointCrous;
    [SerializeField] SerializableDictionary<Level, GameObject> obstacles;
    [SerializeField] GameObject[] trees;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.spawnTile(true);
        Destroy(gameObject, 2);
    }
    
    public void spawnObstacle()
	{
        Vector3 position = transform.position;
        position.x = ProbabilityFunction.getObstaclePosition() * (10/3); // random between a b and c position
        //position.x = Random.Range(-1,2) * (10/3); // random between a b and c position
        position.y = 0.5f;
        position.z = position.z + 5;
        Instantiate(obstacles[GameManager.level], position, Quaternion.identity, transform);
	}

    public void spawnCoin()
    {
        Vector3 position = transform.position;
        position.x = ProbabilityFunction.GetCoinPosition() * (10/3); // random between a b and c position
        //position.x = Random.Range(-1,2) * (10/3); // random between a b and c position
        position.y = 0.7f;

        Instantiate(ProbabilityFunction.getCoinType(new List<GameObject>() { coin, ticket, pointCrous }),
            position, Quaternion.identity, transform);
    }

    public void spawnTree()
	{
        int treesNumber = 8;
        for (int i = 0; i < treesNumber; i++)
        {
            GameObject treeToSpawn = trees[Random.Range(0, trees.Length)];
            GameObject temp = Instantiate(treeToSpawn, transform);
			if (i%2 == 0)
			{
                temp.transform.position = getRandomPointInCollider(transform.GetChild(2).GetComponent<Collider>());
			} else
			{
                temp.transform.position = getRandomPointInCollider(transform.GetChild(3).GetComponent<Collider>());
			}

        }
    }

    public Vector3 getRandomPointInCollider(Collider col)
	{

        Vector3 point = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x),
            0,
            Random.Range(col.bounds.min.z, col.bounds.max.z)
        );

        return point;

    }
}
