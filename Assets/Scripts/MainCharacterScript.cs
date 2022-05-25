using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
	public GameObject kid, baby;

	private readonly string selectedChara = "selectedChara";

    void Start()
    {
        int getChara;
        GameObject selectedPlayer;
        GameObject newParent = GameObject.Find("2 - Foreground");
        Vector3 pos = new Vector3(-10, 0, 0);

        getChara = PlayerPrefs.GetInt("selectedChara");

        switch(getChara)
        {
        	case 1:
        		selectedPlayer = Instantiate(baby, pos, Quaternion.identity) as GameObject;
        		selectedPlayer.transform.parent = newParent.transform;
        		break;
        	case 2:
        		selectedPlayer = Instantiate(kid, pos, Quaternion.identity) as GameObject;
        		selectedPlayer.transform.parent = newParent.transform;
        		break;
        	default:
        		break;
        }
    }
}
