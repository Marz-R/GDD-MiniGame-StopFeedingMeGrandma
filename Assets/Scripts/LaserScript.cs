using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    //public int damage = 1;
    private float next = 0;
    private float cooldown = 4;
    private float end = 0;

    void Awake()
    {
     	lineRenderer = GetComponent<LineRenderer>();   	
    }

    void Start()
    {
    	lineRenderer.enabled = false;
    	lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
    	RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right); //starting point and direction of laser
    	lineRenderer.SetPosition(0, transform.position);
    	//HealthScript health = hit.transform.gameObject.GetComponent<HealthScript>();

    	if (Input.GetKeyDown(KeyCode.L) && Time.time > next)
    	{
    		lineRenderer.enabled = true;
    		end = Time.time + 2;
    		next = Time.time + cooldown + 2;
   		}

    	if (lineRenderer.isVisible && end < Time.time)
   		{
   			lineRenderer.enabled = false;
    	}

    	if(hit && lineRenderer.enabled)
    	{
   			lineRenderer.SetPosition(1, hit.point);
  			Destroy(hit.transform.gameObject);
  			SoundEffectsHelper.Instance.MakeDestroySound();

    			/*if (health != null) //this method of calling healthScript isn't work for some reason
        		{
        			if (health.isEnemy)
       				{
       					health.Damage(damage);
       				}
       			}*/
   		}
   		else
   		{	
   			lineRenderer.SetPosition(1, transform.right*100);
   		}
    		
    		//cooldown = 4;
    }
}
