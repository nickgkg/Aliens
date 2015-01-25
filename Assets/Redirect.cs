using UnityEngine;
using System.Collections;

public class Redirect : MonoBehaviour {

	// Use this for initialization
    public float timer = 5;
    public string scene = "main";

    float startTime;
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update (){
	    if(Time.time > startTime+timer){
            Application.LoadLevel(scene);
        }
	}
}
