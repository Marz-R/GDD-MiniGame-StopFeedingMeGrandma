using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public float numEnemies;
	private float xMin = 15F;
	private float xMax = 50F;
	private float yMin = 4F;
	private float yMax = -4F;

	public float CoolDown = 30;
	private float LastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        Spawn(xMin, xMax);
    }

    void Update()
    {
    	var dist = (transform.position - Camera.main.transform.position).z;
    	var x1 = ((Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x) + 40);
		var x2 = ((Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x) + 25);

    	if(Time.time >= LastSpawn + CoolDown)
        {
     		Spawn(x1, x2);
 		}
    }

    private void Spawn(float xMins, float xMaxs)
    {
    	GameObject newParent = GameObject.Find("3 - FoodLand");
 
		for (int i = 0; i < numEnemies; i++)
		{
			Vector3 newPos = new Vector3(Random.Range(xMins, xMaxs), Random.Range(yMin, yMax), 0);
			GameObject food = Instantiate(foodPrefab, newPos, Quaternion.identity) as GameObject;
			food.transform.parent = newParent.transform;
		}

		LastSpawn = Time.time;
    }

}
