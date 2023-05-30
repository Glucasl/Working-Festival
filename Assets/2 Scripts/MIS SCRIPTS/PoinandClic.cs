using UnityEngine;
using System.Collections;

public class PoinandClic : MonoBehaviour {
	public UnityEngine.AI.NavMeshAgent minav;
	public Transform target;
	public ParticleSystem miparticula;
	

	public Camera micamara;
	// Use this for initialization
	void Start () {
	
		minav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		minav.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		minav.destination = target.position;


		if (Input.GetButtonDown ("Fire1")) {
			RaycastHit hit;
			Ray ray = micamara.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {

				target.position = hit.point;

				minav.speed = 6;
			}

		}
		if (Input.GetButtonDown ("Fire2")) {
			minav.speed = 0;
		
		}


	}
   
   
}
