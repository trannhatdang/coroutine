using UnityEngine;
using System.Collections;

public class Arms : MonoBehaviour
{
	Animator anim;
	SpriteRenderer spr;
	bool flag = false;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		spr.enabled = false;
	}
	public IEnumerator Attack()
	{
		if(flag) yield break;

		anim.SetBool("Attack", true);
		spr.enabled = true;
		flag = true;
		for(int i = 0; i < 37; ++i) yield return null;
		flag = false;
		anim.SetBool("Attack", false);
		spr.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Enemy.instance.Hurt();
		}
	}
}
