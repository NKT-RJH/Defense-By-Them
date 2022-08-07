using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
	public List<Transform> turnOne = new List<Transform>();
	public List<Transform> turnTwo = new List<Transform>();

	private void Start()
	{
		Transform turn1 = transform.Find("Turn1");
		for (int count = 0; count < turn1.childCount; count++)
		{
			turnOne.Add(turn1.GetChild(count));
		}

		Transform turn2 = transform.Find("Turn2");
		for (int count = 0; count < turn2.childCount; count++)
		{
			turnTwo.Add(turn2.GetChild(count));
		}
	}
}
