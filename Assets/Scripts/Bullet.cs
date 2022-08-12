using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Transform target = null;

	private void Update()
	{ // 내일 이거 지우고 다른 포탑 효과 넣고 게임 인트로랑 타이틀이랑 녹화 기능이랑 로딩 그런거 넣자 랭킹도 설명서도
		if (target == null) return;
		print("움직임");
		transform.position = Vector3.MoveTowards(transform.position, target.position, 1);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(gameObject);
		}
	}
}
