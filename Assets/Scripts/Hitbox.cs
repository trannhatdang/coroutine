using UnityEngine;

public class Hitbox : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			StartCoroutine(Player.instance.Hurt());

			Vector2 temp = (Vector2)Player.instance.transform.position - (Vector2)transform.position;
			Player.instance.GetComponent<Rigidbody2D>().AddForce(temp * 800f * Player.instance.LastHort);
		}
	}
}	
