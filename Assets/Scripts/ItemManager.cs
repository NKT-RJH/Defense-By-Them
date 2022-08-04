using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public int[] items = new int[4];
	
	public void GetItem(int number)
	{
		items[number]++;
	}

	public void Heal()
	{
		if (items[0] <= 0) return;

		// 보호 시설 회복
	}

	public void WholeAttack()
	{
		if (items[1] <= 0) return;

		// 전체 데미지
	}

	public void GoldIncrease()
	{
		if (items[2] <= 0) return;

		// 골드 획득량 증가
	}

	public void StopEnemy()
	{
		if (items[3] <= 0) return;

		// 적의 이동속도 0
	}
}
