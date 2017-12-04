using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {

    public Transform player;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;
	}
}
