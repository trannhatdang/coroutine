using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	[SerializeField] float speed = 1f;
	void Awake()
	{
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float Horizontal = Input.GetAxisRaw("Horizontal");
		float Vertical = Input.GetAxisRaw("Vertical");


		transform.position = new Vector3(transform.position.x + Horizontal * Time.fixedDeltaTime * speed, transform.position.y + Vertical * Time.fixedDeltaTime * speed, transform.position.z);

		
	}
}
