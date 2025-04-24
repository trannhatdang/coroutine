using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiscript : MonoBehaviour
{
	[SerializeField] List<ParticleSystem> list_part;
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

	// Start is called before the first frame update
	void Start()
	{


	}

	// Update is called once per frame
	void Update()
	{

	}
	public void PlayParticleSys(int num)
	{	
		if(!list_part[num]) 
		{
			return;
		}

		list_part[num].gameObject.GetComponent<testParticleSystem>().play_part();


	}
}
