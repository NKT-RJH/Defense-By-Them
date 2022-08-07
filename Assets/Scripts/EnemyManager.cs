using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public List<GameObject> enemys = new List<GameObject>();

	public GameObject[] enemyPrefab = new GameObject[4];

	public List<Faze> fazes = new List<Faze>();

	public int fazeCount;

	public float fazeTime;

	private bool nextFaze;

	public GameObject nextFazeButton;

	private void Start()
	{
		StartCoroutine(RunFaze());
	}

	private IEnumerator RunFaze()
	{
		float countFazeTime = 0f;
		float countGap = 0f;
		int enemyCount = 0;
		int fazeSpawnCount = 0;
		for (fazeCount = 0; fazeCount < fazes.Count; fazeCount++)
		{
			countFazeTime = 0;
			fazeSpawnCount = 0;
			enemyCount = 0;
			countGap = 0;
			for (int count = 0; count < fazes[fazeCount].enemys.Length; count++)
			{
				enemyCount += fazes[fazeCount].enemys[count];
			}

			while (countFazeTime <= fazes[fazeCount].fazeTime)
			{
				countFazeTime += Time.deltaTime;
				countGap += Time.deltaTime;

				if (fazeSpawnCount == enemyCount) continue;

				if (countGap >= fazes[fazeCount].spawnGap)
				{
					countGap = 0f;
					int random = 0;
					while (true)
					{
						random = UnityEngine.Random.Range(0, 4);
						if (fazes[fazeCount].enemys[random] > 0)
						{
							break;
						}
					}
					enemys.Add(Instantiate(enemyPrefab[random], new Vector3(15.5f, 1.3f, 0), Quaternion.identity));
					fazes[fazeCount].enemys[random]--;
					fazeSpawnCount++;
				}

				yield return null;
			}
			if (fazeCount + 1 == fazes.Count) break;
			nextFazeButton.SetActive(true);
			while (!nextFaze)
			{
				yield return null;
			}
			nextFaze = false;
		}
	}

	public void NextFaze()
	{
		nextFaze = true;
		nextFazeButton.SetActive(false);
	}
}

[Serializable]
public class Faze
{
	public int[] enemys = new int[4];

	public float fazeTime = 0f;
	public float spawnGap = 0f;
}