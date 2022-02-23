using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private AudioSource sound;
    private Animator anim;
    
    void Start()
    {
		sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        anim.SetTrigger("Play");
    }

    public void makesound()
	{
		sound.Play();
	}
}

