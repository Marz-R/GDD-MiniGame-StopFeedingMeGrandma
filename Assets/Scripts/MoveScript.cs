using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(1, 1); //public so that i can set it during runtime
    public Vector2 direction = new Vector2(-1, 0); //x=-1 -> to the left; y=0 -> no ups&downs

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
    	movement *= Time.deltaTime;
    	transform.Translate (movement);
    }
}
