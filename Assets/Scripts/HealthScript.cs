using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
	public int hp = 1;
	public bool isEnemy = true; //player or food?

	public void Damage(int damageCount)
  	{
    	hp -= damageCount;

    	if (hp <= 0)
    	{
        	SoundEffectsHelper.Instance.MakeDestroySound();
        	Destroy(gameObject); //destroy food
        }
  	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //check if the collided obj has a shotscript or not
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
        	if (shot.isEnemyShot != isEnemy)
        	{
        		Damage(shot.damage);
        		Destroy(shot.gameObject); //destroy ammo
        	}
        }
    }
}
