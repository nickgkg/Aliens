using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
    int timer=100;
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer > 30){
            timer--;
        }else if (timer > 0){
            timer--;
            Vector3 move = new Vector3(0f, -0.1f, 0f);
            transform.Translate(move,transform);
        }
	}
}
