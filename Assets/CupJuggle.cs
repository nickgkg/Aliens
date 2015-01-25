using UnityEngine;
using System.Collections;

public class CupJuggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        cups[0] = GameObject.Find("cu");
        cups[1] = GameObject.Find("cu1");
        cups[2] = GameObject.Find("cu2");
        correctIndex = -1;
	}
	
	// Update is called once per frame
    public static int correctIndex;
    int delay = 100;
    int frameMax=40;
    int frameCurr=0;
    int numSwitches = 15;//15
    int currentSwap;//0 left, 1 right, 2 outside
	GameObject[] cups = new GameObject[3];
    void FixedUpdate (){
        delay--;
        if(numSwitches>0 && delay<0){
            if(delay==-1){
                GameObject.Find("ball").renderer.enabled = false;
            }
	        if(frameMax>=frameCurr){
                if(currentSwap==0){
                    cups[0].transform.position = new Vector3(-2 - 2 * Mathf.Cos(Mathf.PI * frameCurr / frameMax)
                        , 1 + 0.5f * Mathf.Sin(Mathf.PI * frameCurr / frameMax), 0.1f);
                    cups[1].transform.position = new Vector3(-2 + 2 * Mathf.Cos(Mathf.PI * frameCurr / frameMax)
                        , 1 - 0.5f * Mathf.Sin(Mathf.PI * frameCurr / frameMax), -0.1f);
                    cups[2].transform.position = new Vector3(4,1,0f);
                }else if (currentSwap == 1) {
                    cups[0].transform.position = new Vector3(-4, 1, 0f);
                    cups[1].transform.position = new Vector3(2 - 2 * Mathf.Cos(Mathf.PI * frameCurr / frameMax)
                        , 1 + 0.5f * Mathf.Sin(Mathf.PI * frameCurr / frameMax), 0.1f);
                    cups[2].transform.position = new Vector3(2 + 2 * Mathf.Cos(Mathf.PI * frameCurr / frameMax)
                        , 1 - 0.5f * Mathf.Sin(Mathf.PI * frameCurr / frameMax), -0.1f);
                }else {
                    cups[0].transform.position = new Vector3(-4 * Mathf.Cos(Mathf.PI * frameCurr / frameMax)
                        , 1 + 0.5f * Mathf.Sin(Mathf.PI * frameCurr / frameMax), 0.1f);
                    cups[1].transform.position = new Vector3(0, 1, 0f);
                    cups[2].transform.position = new Vector3(4 * Mathf.Cos(Mathf.PI * frameCurr / frameMax)
                        , 1 - 0.5f * Mathf.Sin(Mathf.PI * frameCurr / frameMax), -0.1f);
                }
                frameCurr++;
            }else{
                if(currentSwap == 0){
                    GameObject temp = cups[1]; cups[1] = cups[0]; cups[0] = temp;
                }else if(currentSwap == 1){
                    GameObject temp = cups[1]; cups[1] = cups[2]; cups[2] = temp;
                }else{
                    GameObject temp = cups[0]; cups[0] = cups[2]; cups[2] = temp;
                }
                //swap pieces
                currentSwap=(int)Random.Range(0f,3f);
                numSwitches--;
                frameCurr = 0;
                frameMax -= 3;
                if(numSwitches==0){

                    correctIndex = ((hasBall)cups[1].GetComponent("hasBall")).ball ? 1 :
                        (((hasBall)cups[2].GetComponent("hasBall")).ball ? 2 : 0);
                    //Debug.Log("correctIndex is " + correctIndex + " because " + ((hasBall)cups[0].GetComponent("hasBall")).ball);
                    GameObject.Find("ball").transform.position= new Vector3(correctIndex==0?-4:(correctIndex==1?0:4),0.6f,0.5f);
                    GameObject.Find("ball").renderer.enabled = true;
                }
            }
        }
	}
}
