using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingRay : MonoBehaviour
{
	public GameObject particleEffect;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Rock"))
		{
			Destroy(other.gameObject);
			GameObject p = Instantiate(particleEffect);
			p.transform.position = other.transform.position;
			p.transform.parent = other.transform.parent;
			Destroy(p, 3);
		}
	}
}
