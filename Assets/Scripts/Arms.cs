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
		yield break;
		//TODO
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Enemy.instance.Hurt();
		}
	}
}
