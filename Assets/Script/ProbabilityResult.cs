using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityResult
{

    public List<int> coinsPicked; //Store picked coins for data review
    public List<int> levelsSpawned; //Levels Spawned for data review
    public List<int> amountOfTilesGenerated;
    public List<int> coinPositions; //Coin Positions for data review
    public List<int> obstaclePositions; //Obstacles Positions for data review


	public ProbabilityResult()
	{
		coinsPicked = ProbabilityFunction.coinsPicked;
		levelsSpawned = ProbabilityFunction.levelsSpawned;
		amountOfTilesGenerated = ProbabilityFunction.amountOfTilesGenerated;
		coinPositions = ProbabilityFunction.coinPositions;
		obstaclePositions = ProbabilityFunction.obstaclePositions;
	}
}
