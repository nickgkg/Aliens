using UnityEngine;
using System.Collections;

public class hasBall : MonoBehaviour {

	// Use this for initialization
    int leaveIn = -1;
    bool correct = false;
    public bool ball = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null && hit.collider.gameObject == this.gameObject){
                //Debug.Log(((transform.position.x < -2 && CupJuggle.correctIndex == 0)));
                if ((transform.position.x < -2 && CupJuggle.correctIndex == 0) ||
                    (transform.position.x > -2 && transform.position.x < 2 && CupJuggle.correctIndex == 1) ||
                    (transform.position.x > 2 && CupJuggle.correctIndex == 2))
                {
                    correct = true;
                }
                leaveIn = 50;
            }
        }
        if (leaveIn > 0) {
            leaveIn--;
            GameObject.Find("cupParent").transform.position = new Vector3(0f,1f+0.1f*(50f-leaveIn),0f);
        }else if(leaveIn==0){
            if(correct){
                Application.LoadLevel("win");
            }else{
                Application.LoadLevel("lose");
            }
        }
	}
}
