using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;     //list of background sprites to be parallaxed 
    float[] parallaxFactor;             //how much bg is parallaxed according to camera and z value
    public float smoothing = 1f;       //speed. must be > 0

    Transform cam;
    Vector3 prevCamPos;

    //called before Start
    private void Awake() {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {
        prevCamPos = cam.position;

        //giving each bg image their parallax factor
        parallaxFactor = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++) {
            parallaxFactor[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for(int  i= 0; i< backgrounds.Length; i++) {
            float parallax = (prevCamPos.x - cam.position.x) * parallaxFactor[i];
            float bgTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 bgTargetPos = new Vector3(bgTargetPosX,backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bgTargetPos, smoothing * Time.deltaTime);
        }
        prevCamPos = cam.position;
	}
}
