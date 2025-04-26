using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(Death());
	}
	IEnumerator Death()
	{
		yield return new WaitForSeconds(2f);
		Destroy(this.gameObject);
	}
}

