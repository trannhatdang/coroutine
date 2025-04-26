using UnityEngine;

public class Guns : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	float ogx;
	void Start()
	{
		ogx = transform.localPosition.x;
	}
	public void shoot(bool flag)
	{
		if(flag)
		{
			transform.localPosition = new Vector3(-ogx, transform.localPosition.y, transform.localPosition.z);
		}
		else
		{
			transform.localPosition = new Vector3(ogx, transform.localPosition.y, transform.localPosition.z);
		}

		GameObject gb = Instantiate(bullet, this.transform.position, Quaternion.identity);
		gb.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000 * (flag ? 1 : -1));
	}
}
