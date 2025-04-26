using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	Aura aura;
	Arms arms;
	Animator anim;
	[SerializeField] bool staggered = false;
	float Horizontal = 0.0f;
	public float LastHort{get;private set;}
	public static Player instance;
	public int hp {get; private set;}
	[SerializeField] float speed = 1f;
	[SerializeField] float jumpForce = 1f;
	void Awake()
	{
		if(instance && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
		LastHort = 1f;
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		aura = GetComponentInChildren<Aura>();
		arms = GetComponentInChildren<Arms>();
		anim = GetComponent<Animator>();
		hp = 100;
	}

	void Update()
	{

		Horizontal = Input.GetAxisRaw("Horizontal");

		if(Horizontal == 1f) LastHort = 1f;
		else if(Horizontal == -1f) LastHort = -1f;

		if(staggered) return;

		rb.AddForce(Vector2.right * speed * Horizontal * 70f);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpForce * 200);
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			StartCoroutine(empower());
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			aura.reset();
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			StartCoroutine(arms.Attack());
		}
	}

	IEnumerator empower() 
	{
		for(int i = 0; i < 100; ++i)
		{
			aura.addfire(0.01f);
			yield return new WaitForSeconds(0.2f);
		}
	}
	public IEnumerator Hurt()
	{
		if(staggered) yield break;

		hp--;
		staggered = true;
		yield return new WaitForSeconds(1f);
		staggered = false;
	}
}
