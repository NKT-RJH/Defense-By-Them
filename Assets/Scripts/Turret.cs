using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public GameObject particle;
	private EnemyManager enemyManager;
	[Range(1, 4)] public int number;

	public int level = 0;
	private int damage;
	private float delay;
	private float range;
	private int slow;

	private float delayCount;

	private void Start()
	{
		enemyManager = FindObjectOfType<EnemyManager>();

		switch (number)
		{
			case 1:
				damage = 3;
				delay = 2;
				break;
			case 2:
				damage = 2;
				delay = 2;
				range = 1.5f;
				break;
			case 3:
				damage = 3;
				delay = 1;
				range = 2.5f;
				slow = 10;
				break;
			case 4:
				damage = 2;
				delay = 2;
				break;
		}
	}

	private void Update()
	{
		delayCount += Time.deltaTime;

		if (delayCount >= delay)
		{
			delayCount = 0;

			switch (number)
			{
				case 1:
					StartCoroutine(One());
					break;
				case 2:
					StartCoroutine(Two());
					break;
				case 3:
					print("공격 준비");
					StartCoroutine(Three());
					break;
				case 4:
					//StartCoroutine(Four());
					break;
			}
		}
	}

	public void LevelUp()
	{
		level++;

		switch (number)
		{
			case 1:
				damage += 2;
				delay -= 0.5f;
				break;
			case 2:
				damage += 2;
				range += 0.5f;
				if (level == 2)
				{
					delay -= 1;
				}
				break;
			case 3:
				slow += 10;
				if (level == 2)
				{
					slow += 10;
				}
				break;
			case 4:
				damage += 1;
				break;
		}
	}

	private IEnumerator One()
	{
		int count;
		bool find = false;
		for (count = 0; count < enemyManager.enemys.Count; count++)
		{
			try
			{
				if (Vector3.Distance(transform.position, enemyManager.enemys[count].transform.position) < 4f)
				{
					find = true;
					break;
				}
			}
			catch (MissingReferenceException) { }
		}

		if (!find) yield break;

		Transform target = enemyManager.enemys[count].transform;

		transform.GetChild(0).gameObject.SetActive(true);
		target.GetComponent<Enemy>().HP -= damage;
		GameObject particleObject = Instantiate(particle, target.position, Quaternion.identity);

		yield return new WaitForSeconds(0.3f);

		Destroy(particleObject);
		transform.GetChild(0).gameObject.SetActive(false);
	}

	private IEnumerator Two()
	{// 이거 공격 바꾸기!
		List<Transform> targets = new List<Transform>();
		bool find = false;
		for (int count = 0; count < enemyManager.enemys.Count; count++)
		{
			try
			{
				if (Vector3.Distance(transform.position, enemyManager.enemys[count].transform.position) <= 4f)
				{
					Vector3 mainTarget = enemyManager.enemys[count].transform.position;
					for (int count1 = 0; count1 < enemyManager.enemys.Count; count1++)
					{
						if (Vector3.Distance(mainTarget, enemyManager.enemys[count1].transform.position) > range) continue;
						targets.Add(enemyManager.enemys[count1].transform);
						find = true;
					}
					break;
				}
			}
			catch (MissingReferenceException) { }
		}

		if (!find) yield break;

		Queue<GameObject> objects = new Queue<GameObject>();
		for (int count = 0; count < targets.Count; count++)
		{
			targets[count].GetComponent<Enemy>().HP -= damage;
			objects.Enqueue(Instantiate(particle, targets[count].position, Quaternion.identity));
		}
		transform.GetChild(0).gameObject.SetActive(true);

		yield return new WaitForSeconds(0.3f);

		for (int count = 0; count < targets.Count; count++)
		{
			Destroy(objects.Dequeue());
		}
		transform.GetChild(0).gameObject.SetActive(false);
	}

	private IEnumerator Three()
	{
		List<Transform> targets = new List<Transform>();
		bool find = false;
		for (int count = 0; count < enemyManager.enemys.Count; count++)
		{
			try
			{
				if (Vector3.Distance(transform.position, enemyManager.enemys[count].transform.position) <= 4f)
				{
					Vector3 mainTarget = enemyManager.enemys[count].transform.position;
					print("타겟 인식함");
					for (int count1 = 0; count1 < enemyManager.enemys.Count; count1++)
					{
						print("범위 : " + Vector3.Distance(mainTarget, enemyManager.enemys[count1].transform.position));
						if (Vector3.Distance(mainTarget, enemyManager.enemys[count1].transform.position) > range) continue;
						targets.Add(enemyManager.enemys[count1].transform);
						find = true;
					}
					break;
				}
			}
			catch (MissingReferenceException) { }
		}

		if (!find) yield break;
		print("공격 개시");
		Queue<GameObject> objects = new Queue<GameObject>();
		for (int count = 0; count < targets.Count; count++)
		{
			Enemy enemy = targets[count].GetComponent<Enemy>();
			enemy.HP -= damage;
			StartCoroutine(enemy.Slow(5, slow));
			objects.Enqueue(Instantiate(particle, targets[count].position, Quaternion.identity));
		}
		transform.GetChild(0).gameObject.SetActive(true);

		yield return new WaitForSeconds(0.3f);

		for (int count = 0; count < targets.Count; count++)
		{
			Destroy(objects.Dequeue());
		}
		transform.GetChild(0).gameObject.SetActive(false);
	}

	private void Four()
	{
		// 이거 완성하기!
	}
}
