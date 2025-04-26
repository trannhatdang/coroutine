using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{
	Slider slid;
	void Start()
	{
		slid = GetComponent<Slider>();
	}
	void Update()
	{
		slid.value = Enemy.instance.hp;
	}
}
		
