using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
	Slider slid;
	void Start()
	{
		slid = GetComponent<Slider>();
	}
	void Update()
	{
		slid.value = Player.instance.hp;
	}
}
