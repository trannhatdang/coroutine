using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiscript : MonoBehaviour
{
	public static uiscript instance;
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
	}
}
