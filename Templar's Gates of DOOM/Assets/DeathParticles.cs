using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public GameObject deathFragments;

	public void Death()
	{
		Instantiate (deathFragments, transform.position, deathFragments.transform.rotation);
	}
}
