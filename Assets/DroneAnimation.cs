using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAnimation : MonoBehaviour
{
	Animator anim;
	public GameObject scanObject;
	bool scanning = false;

    void Start()
    {
		anim = GetComponent<Animator>();
		scanObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.S))
		{
			scanning = !scanning;
			scanObject.SetActive(scanning);
			anim.SetBool("IsScanning", scanning);
		}
    }
}
