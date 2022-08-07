using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoint : MonoBehaviour
{
	public GameManager gameManager;

	private void OnTriggerEnter(Collider collision)
	{
		if (!collision.CompareTag("Enemy")) return;

		collision.GetComponent<Enemy>().deathByPoint = true;
		collision.GetComponent<Enemy>().HP = 0;

		if (gameManager)
		{
			gameManager.HP--;
			gameManager.hpUI[gameManager.HP].SetActive(false);
		}
	}
}
