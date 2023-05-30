using UnityEngine;
using System.Collections;

public class PosEqualPos : MonoBehaviour {
	public Transform target;
	public float smoothTime = 3F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smoothTime );


	}
}
