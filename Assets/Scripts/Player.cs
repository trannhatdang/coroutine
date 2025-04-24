using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	Aura aura;
	[SerializeField] float speed = 1f;
	[SerializeField] float jumpForce = 1f;
	void Awake()
	{
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		aura = GetComponent<Aura>();
	}

	void Update()
	{
		float Horizontal = Input.GetAxisRaw("Horizontal");
		rb.AddForce(Vector2.right * speed * Horizontal * 2.5f);
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

	}

	IEnumerator empower() 
	{
		for(int i = 0; i < 100; ++i)
		{
			aura.addfire(0.01f);
			yield return new WaitForSeconds(0.2f);
		}
	}
}
