using UnityEngine;
using System.Collections;

public class DisplayTimer : MonoBehaviour {

	// Use this for initialization
    public float delay = 0;
    public float timer = 4;
    public string scene = "lose";

    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {  
        if(Time.time < startTime + delay){

        }else if (Time.time > startTime + timer + delay)
        {
            Application.LoadLevel(scene);
        }
        else {
            float time = startTime + timer + delay - Time.time;
            ((GUIText)GetComponent("GUIText")).text = (int)time+":"+(int)((time-(int)time)*100);
        }
    }
}
