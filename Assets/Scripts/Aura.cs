using UnityEngine;


public class Aura : MonoBehaviour
{
	[SerializeField] SpriteRenderer fire;

	void Awake()
	{
		fire.color = new Color(1f, 1f, 1f, 0);
	}
	public void addfire(float value)
	{
		float alpha = fire.color.a;
		fire.color = new Color(1f, 1f, 1f, alpha + value);
	}
	public void reset()
	{
		fire.color = new Color(1f, 1f, 1f, 0);
	}
}

