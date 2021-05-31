using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityFunction :MonoBehaviour
{

	static public List<int> coinsPicked = new List<int>(); //Store picked coins for data review
	static public List<int> levelsSpawned = new List<int>(); //Levels Spawned for data review
	static public List<int> amountOfTilesGenerated = new List<int>();
	static public List<int> coinPositions = new List<int>(); //Coin Positions for data review
	static public List<int> obstaclePositions = new List<int>(); //Obstacles Positions for data review

	string saveFile;

	// get type of coin --> uniform
	// return GameObject 

	
	static public GameObject getCoinType(List<GameObject> coins) {
		int index = Random.Range(0, coins.Count); //We pick a coin type evenly in the coins[] list and return it
		coinsPicked.Add(index);
		return coins[index];
	}

	// get Level --> Bernoulli
	// return Level
	static public Level GetLevel(Level actual)
    {
		Level next = actual;
		//We define a probability p for the next level to happen then get the level
		if(actual == Level.Classroom)
        {
			float p = 0.4f;
			float randomValue = Random.Range(0f, 1.0f);
			if (randomValue < p)
            {
				next = Level.City;
            }
			else
            {
				next = Level.Forest; //We'll set it to 3rd level after
            }
        }
		if (actual == Level.City)
		{
			float p = 0.3f;
			float randomValue = Random.Range(0f, 1.0f);
			if (randomValue < p)
			{
				next = Level.Classroom;
			}
			else
			{
				next = Level.Forest; //We'll set it to 3rd level after
			}
		}
		if (actual == Level.Forest) //3rd level type
		{
			float p = 0.7f;
			float randomValue = Random.Range(0f, 1.0f);
			if (randomValue < p)
			{
				next = Level.Classroom;
			}
			else
			{
				next = Level.City; //We'll set it to 3rd level after
			}
		}
		if(next == Level.City) { levelsSpawned.Add(0); }
		if (next == Level.Forest) { levelsSpawned.Add(1); }
		if (next == Level.Classroom) { levelsSpawned.Add(2); }
		return next;
    }

	// get level duration (int), between [3, 25] --> geometrical (formula : q^(k-1)*p)
	// return [3,25]
	static public int LevelDuration()
    {
		float p = 0.5f;
		int k = Random.Range(3, 5);
		float geometrical = p * Mathf.Pow(1 - p, k - 1); //Calculate geometrical value with p : 0.5 and k in [3,5]
		int amountOfTiles = (int)(geometrical * 100 + 5);
		amountOfTilesGenerated.Add(amountOfTiles);
		return amountOfTiles; //we get an int for the number of tiles to generate

	}

	// get position between (-1, 0, 1) (for coin or obstacle) --> Binomial
	// return -1, 0, 1

	static public int GetCoinPosition()
	{
		int maxRange = 10; //To get a wide range of values
		float p = Random.Range(0.5f, 1.0f); //We define a probability p for the Binomial law
		int k = Random.Range(5, maxRange); // we set an n to calculate B(n,p)
		int binomial = Binomial(k, maxRange); // We get the binomial coefficient 
		//Debug.Log(binomial);
		float binomialLaw = binomial * Mathf.Pow(p, k) * Mathf.Pow((1 - p), maxRange - k) * 100; // binomial formula
		Debug.Log("binomial : " + binomialLaw);
		if (binomialLaw < 7) { coinPositions.Add(-1); return -1; } //Density of values found with a Python graph
		else if (binomialLaw < 15 ) { coinPositions.Add(0); return 0; }
		else { coinPositions.Add(1); return 1; }
	}

	// get position of obstacle --> Poisson
	// return gameObject //must respect coin positions public List<int> coinPositions;
	static public int getObstaclePosition()
    {
		int coinPos = -2;
		if (coinPositions.Count > 0)
		{
			coinPos = coinPositions[coinPositions.Count - 1];
		}
		int maxRange = 25; //To get a wide range of values
		int lambda = 3;
		int k = Random.Range(20, maxRange);
		float poisson = (Mathf.Pow(lambda, k) * Mathf.Exp(-lambda) / Factorial(k));
		Debug.Log("Poisson : " + poisson);
		if (poisson < -10 && coinPos != -1) { obstaclePositions.Add(-1); return -1; } //Density of values found with a Python graph
		else if (poisson < -4 && coinPos != 0) { obstaclePositions.Add(0); return 0; }
		else { 
			if (coinPos == 1 )
            {
				obstaclePositions.Add(0); return 0;
			}
			else
            {
                obstaclePositions.Add(1); return 1;
			}
		}

	}

	static public int Factorial(int n)
    {
		if (n == 0) return (1);

		return (n * Factorial(n - 1));
	}
	static public int Binomial(int k, int n)
    {
		int nF = Factorial(n); // Computing n!
		int kF = Factorial(k); // Computing k!
		int n_kF = Factorial(n - k); // Computing (n-k)!
		return nF / (kF * n_kF); // Returning n!/k!(n-k)!

    }

	private void Update()
    {
		Debug.Log(GetCoinPosition());
		if (Input.GetKeyDown("p"))
		{
			Debug.Log("Hello");
			export();
			Debug.Log(Application.persistentDataPath);
		}
	}

	void Awake()
	{
		// Update the path once the persistent path exists.
		saveFile = Application.persistentDataPath + "/gamedata.json";
	}
	public void export()
    {
		Debug.Log(obstaclePositions);
		var result = new ProbabilityResult();
		File.WriteAllText(saveFile, JsonUtility.ToJson(result));
	}
}
