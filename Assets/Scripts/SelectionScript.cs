using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour
{
    public GameObject player;
    public GameObject baby;
    public GameObject playerIntro;
    public GameObject babyIntro;

    private Vector3 CharacterPosition;
    private Vector3 IntroPosition;
    private Vector3 OffScreen;
	private int CharaInt;

	private readonly string selectedChara = "selectedChara";

    private void Awake()
    {
    	CharacterPosition = new Vector3 (0, 0, 0);
    	IntroPosition = new Vector3 (6, -3, 0);
    	OffScreen = new Vector3 (-30, 0, 0);
    	CharaInt = 1;
    	PlayerPrefs.SetInt("selectedChara", 2); 
    }

    public void NextChara()
    {
    	//when click button, change characters and intros
    	switch(CharaInt)
    	{
    		case 1:
    			PlayerPrefs.SetInt("selectedChara", 1); //player has selected **baby**
    			player.transform.position = OffScreen;
    			playerIntro.transform.position = OffScreen;

    			baby.transform.position = CharacterPosition;
    			babyIntro.transform.position = IntroPosition;

    			CharaInt = 2;

    			break;

    		case 2:
    			PlayerPrefs.SetInt("selectedChara", 2); //player has selected **kid**
    			baby.transform.position = OffScreen;
    			babyIntro.transform.position = OffScreen;

    			player.transform.position = CharacterPosition;
    			playerIntro.transform.position = IntroPosition;

    			CharaInt = 1;

    			break;

    		default:
    			break;
    	}
    }

    public void Play()
    {
    	SceneManager.LoadScene("Scene1");
    }
}
