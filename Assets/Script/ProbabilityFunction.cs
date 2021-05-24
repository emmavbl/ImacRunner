using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityFunction :MonoBehaviour
{
	[SerializeField] GameObject[] coins;
	List<int> coinsPicked; //Store picked coins for data review
	List<Level> levelsSpawned; //Levels Spawned for data review
	List<int> amountOfTilesGenerated;
	// get type of coin --> uniform
	// return GameObject 
	GameObject getCoinType() {
		int index = Random.Range(0, 2); //We pick a coin type evenly in the coins[] list and return it
		coinsPicked.Add(index);
		return coins[index];
	}

	// get Level --> Bernoulli
	// return Level
	public Level GetLevel(Level actual)
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
		levelsSpawned.Add(next);
		return next;
    }

	// get level duration (int), between [3, 25] --> geometrical (formula : q^(k-1)*p)
	// return [3,25]
	public int LevelDuration()
    {
		float p = 0.5f;
		int k = Random.Range(3, 10);
		float geometrical = p * Mathf.Pow(1 - p, k - 1); //Calculate geometrical value with p : 0.5 and k in [3,10]
		int amountOfTiles = (int)(geometrical * 100 + 5);
		amountOfTilesGenerated.Add(amountOfTiles);
		return amountOfTiles; //we get an int for the number of tiles to generate

	}

	// get position between (-1, 0, 1) (for coin or obstacle) --> Binomial
	// return -1, 0, 1

	/*public int GetCoinPosition()
	{
		int maxRange = 20;
		float p = Random.Range(0f, 1.0f); //We define a probability p for the Binomial law
		int k = Random.Range(0, maxRange); // we set an n to calculate B(n,p)
		int binomial = Binomial(k, maxRange); // We get the binomial coefficient 
		float binomialLaw = binomial * Mathf.Pow(p, k) * Mathf.Pow((1 - p), maxRange - k); // binomial formula

	}*/

	// get type of obstacle --> Poisson
	// return gameObject



	public int Binomial(int k, int n)
    {
		int nF = 1;
		for(int i=1;i < n; i++){ nF = nF*i; } // Computing n!
		int kF = 1;
		for (int i = 1; i < k; i++) { kF = kF * i; } // Computing k!
		int n_kF = 1;
		for (int i = 1; i < n - k; i++) { n_kF = n_kF * i; } // Computing (n-k)!
		return nF / (kF * n_kF); // Returning n!/k!(n-k)!
    }
}
