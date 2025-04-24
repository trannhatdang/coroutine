using UnityEngine;
using System.Collections.Generic;

public class testParticleSystem : MonoBehaviour
{
	[SerializeField] ParticleSystem part;
	
	void Awake()
	{

	}

	void Start()
	{
		part = GetComponent<ParticleSystem>();
	}

	void Update()
	{

	
	}
	
	public void play_part()
	{
		if(part.isPlaying)
		{
			part.Stop();
		}
		else 
		{
			part.Play();
		
		}
	}

	void OnParticleCollider(GameObject other)
	{
		List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
		int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

		GlowPart other_part = other.GetComponent<GlowPart>();
		for(int i = 0; i < numCollisionEvents; ++i)
		{
			other_part.glow();
		}
	}
	void OnParticleTrigger()
	{
		
		ParticleSystem ps = GetComponent<ParticleSystem>();

		List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
		List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

		int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
		int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

		for(int i = 0; i < numEnter; ++i)
		{
			ParticleSystem.Particle p = enter[i];
			p.startColor = new Color(255, 0, 0, 255);
			enter[i] = p;
		}

		for(int i = 0; i < numExit; ++i)
		{
			ParticleSystem.Particle p = exit[i];
			p.startColor = new Color(0, 255, 0, 255);
			exit[i] = p;
		}

		ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
		ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
	}
}


