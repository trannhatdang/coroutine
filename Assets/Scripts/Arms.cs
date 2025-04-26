using UnityEngine;
using System.Collections;

public class Arms : MonoBehaviour
{
	Animator anim;
	SpriteRenderer spr;
	Collider2D coll;
	bool flag = false;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		coll = GetComponent<Collider2D>();
		spr.enabled = false;
		coll.enabled = false;
	}
	public IEnumerator Attack()
	{
		if(flag) yield break;

		anim.SetBool("Attack", true);
		spr.enabled = true;
		coll.enabled = true;
		flag = true;
		for(int i = 0; i < 37; ++i) yield return null;
		anim.SetBool("Attack", false);
		spr.enabled = false;
		coll.enabled = false;
		for(int i = 0; i < 30; ++i) yield return null;
		flag = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Enemy.instance.Hurt();
		}
	}
}
