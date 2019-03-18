using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AstronautAnimation : MonoBehaviour
{
	Animator anim;
	bool drill = false;
	bool wave = false;
	public GameObject drillObject;
	public GameObject[] rockObjects;
	GameObject drillTip;
	Coroutine drillRocks;

	void Start()
    {
		anim = GetComponent<Animator>();
		drillTip = drillObject.transform.Find("Tip").gameObject;
		drillObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.D))
		{
			Debug.Log("Toggle Drilling");
			wave = false;
			drill = !drill;
			drillObject.SetActive(drill);
			
			if (drill)
			{
				drillRocks = StartCoroutine("DrillRocks");
			}
			else
			{
				StopCoroutine(drillRocks);
			}
			UpdateAnimator();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log("Toggle Waving");
			drill = false;
			wave = !wave;
			UpdateAnimator();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Reset");
			drill = false;
			wave = false;
			UpdateAnimator();
		}
		
    }

	void UpdateAnimator()
	{
		anim.SetBool("IsWaving", wave);
		anim.SetBool("IsDrilling", drill);
	}

	IEnumerator DrillRocks()
	{
		yield return new WaitForSeconds(8f);
		while (drill)
		{
			GameObject rock = Instantiate(rockObjects[(int)(Random.value * rockObjects.Length)]);
			rock.transform.position = drillTip.transform.position;
			rock.transform.parent = transform.parent;
			rock.GetComponent<Rigidbody>().AddForce(5*(rock.transform.parent.up + Random.insideUnitSphere), ForceMode.Impulse);
			yield return new WaitForSeconds(5f);
		}
	}
}
