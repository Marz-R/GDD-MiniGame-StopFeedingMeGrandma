using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(20, 10); //public so that i can set it during runtime
    
    // Update is called once per frame
    void Update()
    {
        //movement of player
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
    	movement *= Time.deltaTime;
    	transform.Translate (movement);

        //shooting
        bool shoot = Input.GetButtonDown("Jump");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();

            if (weapon != null)
            {
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }

        //stay in boundary
        var dist = (transform.position - Camera.main.transform.position).z;

        //get camera edges
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        //restrict player movement within the camera edges
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        HealthScript health = collider.gameObject.GetComponent<HealthScript>();

        if (health != null)
        {
            if (health.isEnemy)
            {
                SoundEffectsHelper.Instance.MakeEatingSound();
                Destroy(collider.gameObject);
            }
        }
    }

    void OnDestroy()
    {
        var gameOver = FindObjectOfType<GameOverScript>();
        gameOver.ShowButtons();
    }
}
