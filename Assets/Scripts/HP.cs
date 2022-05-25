using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Text textbox;
    public GameObject player;
    private readonly string selectedChara = "selectedChara";

    void Start()
    {
        int getChara = PlayerPrefs.GetInt("selectedChara");
        textbox = GetComponent<Text>();

        switch(getChara)
        {
        	case 1:
        		player = GameObject.FindWithTag("P2 - Baby");
        		break;
        	case 2:
        		player = GameObject.FindWithTag("P1 - Kid");
        		break;
        	default:
        		break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	if (player != null)
        {
        	HealthScript health = player.GetComponent<HealthScript>();
        	textbox.text = "" + health.hp;
        }
    }
}
