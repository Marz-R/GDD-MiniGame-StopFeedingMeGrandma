using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
	public int damage = 1;
	public bool isEnemyShot = false; //true: damage player; false: damgae food
	private SpriteRenderer rendererComponent;

	void Awake()
    {
        rendererComponent = GetComponent<SpriteRenderer>(); //ammo sprite
    }

	void Start()
    {
		if (!isEnemyShot)
		{
        	Destroy (gameObject, 3); //destroy ammo, no infinite flying
        }
    }

    void Update()
    {
    	if (rendererComponent.IsVisibleFrom(Camera.main) == false)
    	{
            Destroy(gameObject);
        }
    }
}
