using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float hInput;
	public float jumpIn;
	public float hSpeed;
	public float jumpSpeed;

	Rigidbody2D playerRigidbody;

	public float boxWidth;
	public bool isAirbone;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();
		boxWidth = GetComponent<BoxCollider2D> ().bounds.extents.y; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//getting input
		hInput = Input.GetAxis ("Horizontal");
		jumpIn = Mathf.Abs(Input.GetAxisRaw ("Vertical"));

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, boxWidth+0.1f);
		isAirbone = (hit.collider == null);

		if (isAirbone) {
			jumpIn = 0;
		}

		Vector2 moveVector = new Vector2 (hInput * hSpeed, playerRigidbody.velocity.y + jumpIn * jumpSpeed);
		playerRigidbody.velocity = moveVector;
	}

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.tag == "Finish"){
            SceneManager.LoadScene("LevelOne");
        }
    }
}
