using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {

	// Use this for initialization
    public string[] scene;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Application.LoadLevel(scene[Random.Range(0,scene.Length)]);
        }
	}
}
