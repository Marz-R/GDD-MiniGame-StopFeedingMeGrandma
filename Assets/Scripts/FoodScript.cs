using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private bool hasSpawn;
    private MoveScript moveScript;
    private ShotScript shotScript;
    private HealthScript healthScript;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;

    void Awake()
    {
        // Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();
        shotScript = GetComponent<ShotScript>();
        healthScript = GetComponent<HealthScript>();
        coliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hasSpawn = false;

        // Disable everything before spawn
        coliderComponent.enabled = false;
        moveScript.enabled = false;
        shotScript.enabled = false;
        healthScript.enabled = false;
    }

    void Update()
    {
        //check if spawn
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            //destroy when out of frame
            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        coliderComponent.enabled = true;
        moveScript.enabled = true;
        shotScript.enabled = true;
        healthScript.enabled = true;
    }
}
