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
		actionsByKey.Add(KeyCode.F1, test);
		actionsByKey.Add(KeyCode.F2, test);
		actionsByKey.Add(KeyCode.F3, test);
		actionsByKey.Add(KeyCode.F4, test);
		actionsByKey.Add(KeyCode.F5, test);
		actionsByKey.Add(KeyCode.F6, test);
		actionsByKey.Add(KeyCode.F7, test);

		StartCoroutine(Repeat());
	}

	private IEnumerator Repeat()
	{
		while (true)
		{
			foreach (KeyValuePair<KeyCode,Action> keyValue in actionsByKey)
			{
				if (Input.GetKeyDown(keyValue.Key))
				{
					keyValue.Value.Invoke();
				}
			}
			yield return null;
		}
	}

	private void test()
	{
		print("테스트!!");
	}
}
