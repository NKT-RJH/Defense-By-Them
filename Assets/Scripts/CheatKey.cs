using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatKey : MonoBehaviour
{
	private Dictionary<KeyCode, Action> actionsByKey = new Dictionary<KeyCode, Action>();

	private void Start()
	{
		// 치트키는 F1 에서부터 F7 까지! 일단은 테스트 함수로..,
		actionsByKey.Add(KeyCode.F1, StopEnemy);
		actionsByKey.Add(KeyCode.F2, GoldIncrease);
		actionsByKey.Add(KeyCode.F3, KillAll);
		actionsByKey.Add(KeyCode.F4, KillAll_Gold);
		actionsByKey.Add(KeyCode.F5, GotoTitle);
		actionsByKey.Add(KeyCode.F6, GotoFirstStage);
		actionsByKey.Add(KeyCode.F7, GotoSecondStage);

		StartCoroutine(Repeat());
	}

	private IEnumerator Repeat()
	{
		while (true)
		{
			if (Input.anyKeyDown)
			{
				foreach (KeyValuePair<KeyCode, Action> keyValue in actionsByKey)
				{
					if (Input.GetKeyDown(keyValue.Key))
					{
						keyValue.Value.Invoke();
					}
				}
			}
			yield return null;
		}
	}

	private void StopEnemy()
	{
		// 모든 적 멈추기
		print("모든 적 멈추기");
	}

	private void GoldIncrease()
	{
		// 골드 증가 100
		print("골드 증가 100");
	}

	private void KillAll()
	{
		// 모든 적 사망 (골드 획득 X)
		print("모든 적 사망 (골드 획득 X)");
	}

	private void KillAll_Gold()
	{
		// 모든 적 사망 (골드 획득)
		print("모든 적 사망 (골드 획득)");
	}

	private void GotoTitle()
	{
		// 메인화면으로
		print("메인화면으로");
	}

	private void GotoFirstStage()
	{
		// 1스테이지로 전환
		print("1스테이지로 전환");
	}

	private void GotoSecondStage()
	{
		// 2스테이지로 전환
		print("2스테이지로 전환");
	}
}
