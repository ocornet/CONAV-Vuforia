using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeGravity : MonoBehaviour
{
	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
    {
		rb.AddForce(-transform.parent.up * 9.81f,ForceMode.Acceleration);
    }
}
