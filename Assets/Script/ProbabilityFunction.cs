using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityFunction :MonoBehaviour
{
	[SerializeField] GameObject[] coins;

	// get type of coin --> uniform
	// return GameObject 

	// get Level --> Bernoulli
	// return Level

	// get level duration (int), between [3, 25] --> geometrical
	// return [3,25]

	// get position between (-1, 0, 1) (for coin or obstacle) --> Binomial
	// return -1, 0, 1

	// get type of obstacle --> Poisson
	// return gameObject
}
