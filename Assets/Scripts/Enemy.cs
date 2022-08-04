using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Range(1, 4)] public int number;

	private int HP;
	private int price;

	private void Start()
	{
		switch (number)
		{
			case 1:
				HP = 5;
				price = 3;
				break;
			case 2:
				HP = 15;
				price = 10;
				break;
			case 3:
				HP = 10;
				price = 15;
				break;
			case 4:
				HP = 15;
				price = 20;
				break;
		}
		StartCoroutine(DeathCheck());
	}

	private void Update()
	{
		
	}

	private IEnumerator DeathCheck()
	{
		while (HP > 0)
		{
			yield return null;
		}

		switch (number)
		{
			case 3:
				
				break;
			case 4:
				HP = 15;
				price = 20;
				break;
		}
	}
}