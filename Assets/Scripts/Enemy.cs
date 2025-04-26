using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator coroutine;
    public int hp {get; private set;}
    bool flag = true;
    Rigidbody2D rb;
    Guns[] guns;
    public static Enemy instance; 

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

    void Start()
    {
       coroutine = routine(); 
       rb = GetComponent<Rigidbody2D>();
       guns = GetComponentsInChildren<Guns>();
       hp = 10;
       StartCoroutine(coroutine);
    }

    public void Hurt()
    {
	    hp--;
    }

    IEnumerator routine()
    {
	    yield return new WaitForSeconds(2f);
	    var rand = new System.Random();

	    while(hp > 0)
	    {
		    if(rand.Next() % 2 == 0)
		    {
			    if(flag)
			    {
				    rb.AddForce(Vector2.left * 500);
				    flag = false;
			    }
			    else
			    {
				    rb.AddForce(Vector2.right * 500);
				    flag = true;
			    }
		    }
		    else
		    {
			    foreach(Guns gun in guns)
			    {
				    gun.shoot(flag);
			    }
		    }
		    yield return new WaitForSeconds(2f);
	    }
    }
}
