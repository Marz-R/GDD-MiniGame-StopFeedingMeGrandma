using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
   public Transform shotPrefab; //obj prefab for shooting (ammo)

   //cool down time between shots
   public float shootingRate = 0.1f; 
   private float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
        	shootCooldown -= Time.deltaTime;
        }
    }

    //create new ammo
    public void Attack(bool isEnemy)
    {
    	if (CanAttack)
        {
    		shootCooldown = shootingRate;

    		//create new ammo and assign position
    		var shotTransform = Instantiate(shotPrefab) as Transform;
    		shotTransform.position = transform.position;

    		ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

        	if (shot != null)
            {
        		shot.isEnemyShot = isEnemy;
        	}

        	MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
        	if (move != null)
            {
        		move.direction = this.transform.right;
        	}
    	}
    }

    //cool down finish or not
    public bool CanAttack
    {
    	get
        {
    		return shootCooldown <= 0f;
    	}
    }
}
