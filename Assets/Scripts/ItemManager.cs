using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
	public GameManager gameManager;
	public EnemyManager enemyManager;
	public Text itemPriceText;
	public Text buyCountText;

	public int[] items = new int[4];
	public Image[] itemImages = new Image[4];
	public Text[] itemTexts = new Text[4];

	public int goldPower = 1;
	public int itemPrice = 10;
	public int buyCount = 10;

	private float countTime = 5;

	private Coroutine goldCoroutine;
	private Coroutine stopCoroutine;

	private void Start()
	{
		for (int count = 0; count < itemTexts.Length; count++)
		{
			itemTexts[count].text = string.Format("{0}개", items[count]);
		}
	}

	private void Update()
	{
		if (countTime <= 5)
		{
			countTime += Time.deltaTime / Time.timeScale;
			for (int count = 0; count < itemImages.Length; count++)
			{
				itemImages[count].fillAmount = countTime / 5;
			}
		}

		buyCountText.text = string.Format("{0}번 남음", buyCount);
		itemPriceText.text = string.Format("{0}원", itemPrice);
	}

	public void GetItem()
	{
		if (gameManager.gold < itemPrice) return;
		if (buyCount <= 0) return;
		gameManager.gold -= itemPrice;
		items[Random.Range(0,4)]++;
		for (int count = 0; count < itemTexts.Length; count++)
		{
			itemTexts[count].text = string.Format("{0}개", items[count]);
		}
		itemPrice += 5;
		buyCount--;
	}

	public void GetItemByEnemy()
	{
		items[Random.Range(0, 4)]++;
		for (int count = 0; count < itemTexts.Length; count++)
		{
			itemTexts[count].text = string.Format("{0}개", items[count]);
		}
	}

	public void Heal()
	{
		if (countTime < 5) return;
		if (items[0] <= 0) return;
		countTime = 0f;
		gameManager.HP += gameManager.HP + 3 > 10 ? 10 - gameManager.HP : 3;
		for (int count = 0; count < 10; count++)
		{
			gameManager.hpUI[count].SetActive(false);
		}
		for (int count = 0; count < gameManager.HP; count++)
		{
			gameManager.hpUI[count].SetActive(true);
		}
		itemTexts[0].text = string.Format("{0}개", --items[0]);
	}

	public void WholeAttack()
	{
		if (countTime < 5) return;
		if (items[1] <= 0) return;
		countTime = 0f;
		foreach (GameObject enemy in enemyManager.enemys)
		{
			try
			{
				Enemy temporary = enemy.GetComponent<Enemy>();
				temporary.HP /= 2;
			}
			catch (MissingReferenceException) { }
		}
		itemTexts[1].text = string.Format("{0}개", --items[1]);
	}

	public void GoldIncrease()
	{
		if (countTime < 5) return;
		if (items[2] <= 0) return;
		if (goldCoroutine != null) return;
		countTime = 0f;
		goldCoroutine = StartCoroutine(GoldCoroutine());
		itemTexts[2].text = string.Format("{0}개", --items[2]);
	}

	private IEnumerator GoldCoroutine()
	{
		goldPower *= 2;
		yield return new WaitForSeconds(180);
		goldPower = 1;
		goldCoroutine = null;
	}

	public void StopEnemy()
	{
		if (countTime < 5) return;
		if (items[3] <= 0) return;
		if (stopCoroutine != null) return;
		countTime = 0f;
		stopCoroutine = StartCoroutine(StopCoroutine());
		itemTexts[3].text = string.Format("{0}개", --items[3]);
	}

	private IEnumerator StopCoroutine()
	{
		foreach (GameObject enemy in enemyManager.enemys)
		{
			try
			{
				Enemy temporary = enemy.GetComponent<Enemy>();
				temporary.movementspeed /= 2;
			}
			catch (MissingReferenceException) { }
		}
		yield return new WaitForSeconds(10);
		foreach (GameObject enemy in enemyManager.enemys)
		{
			try
			{
				Enemy temporary = enemy.GetComponent<Enemy>();
				temporary.movementspeed *= 2;
			}
			catch (MissingReferenceException) { }
		}
		stopCoroutine = null;
	}
}
