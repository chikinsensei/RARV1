using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DetectorAnimator : MonoBehaviour
{
    public Transform PivotR;
    public Transform PivotL;
    
    public Animator Animator;

    public AudioClip doorOpenSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = doorOpenSound;
    }
    private void OnTriggerEnter(Collider other)
    {
		if (!other.CompareTag("Player") && !Animator.GetBool("b_OpenDoor")) return;

		Animator.SetBool("b_OpenDoor", true);
        audioSource.Play();

    }
    private void OnTriggerExit(Collider other)
    {
		if (!other.CompareTag("Player") && Animator.GetBool("b_OpenDoor")) return;
		Animator.SetBool("b_OpenDoor", false);
		audioSource.Play();
	}
}
