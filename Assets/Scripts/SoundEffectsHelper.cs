using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsHelper : MonoBehaviour
{
  //singleton
    public static SoundEffectsHelper Instance;
    public AudioClip eatingSound;
    public AudioClip playerShotSound;
    public AudioClip destroySound;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null){
          Debug.LogError("Multiple instances of SoundEffectsHelper!");
      }
      Instance = this;
    }

    public void MakePlayerShotSound()
    {
      MakeSound(playerShotSound); //pew.wav
    }

    public void MakeEatingSound()
    {
      MakeSound(eatingSound); //eating.wav
    }

    public void MakeDestroySound()
    {
      MakeSound(destroySound); //boop.mps
    }

    private void MakeSound(AudioClip originalClip)
    {
      AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
