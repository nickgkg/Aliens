using UnityEngine;
using System.Collections;
using System;

public class EnableGui : MonoBehaviour {

	// Use this for initialization

    public GameObject[] b;
    public GameObject[] l;
    string[] names = {"FROG","FISH","DUCK","CAT","DOG","MOUSE","WOLF","BEAR","SQUIRREL","ELEPHANT","LION","MEERKAT",
                         "WHALE","OCTOPUS","SHARK","HORSE","BUNNY","BIRD"};
    int[] blanks = {2,4,6};
    int blankIndex;
    string word;
    void Start()
    {
        GUI.enabled = true;
        word = names[UnityEngine.Random.Range(0, names.Length - 1)];
        string word2 = (string)word.Clone();
        int[] ind = new int[word2.Length];
        for (int i = 0; i < word2.Length; i++)
        {
            ind[i] = i;
        }
        for (int i = 0; i < word2.Length; i++)
        {
            int rand = UnityEngine.Random.Range(0, word2.Length);
            int temp = ind[rand]; ind[rand] = ind[i]; ind[i] = temp;
        }
        char[] ch = word2.ToCharArray();
        ((GUIText)l[0].GetComponent("GUIText")).text = ch[ind[0]] + "";
        ((GUIText)l[1].GetComponent("GUIText")).text = ch[ind[1]] + "";
        ((GUIText)l[2].GetComponent("GUIText")).text = ch[ind[2]] + "";
        ch[ind[0]] = '_';
        ch[ind[1]] = '_';
        ch[ind[2]] = '_';

        blanks[0] = ind[0];
        blanks[1] = ind[1];
        blanks[2] = ind[2];
        Array.Sort(blanks);

        ((GUIText)GetComponent("GUIText")).text = new string(ch);
        // initial randomness
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                for (int i = 0; i < b.Length; i++) { 
                    if(hit.collider.gameObject == b[i]){
                        
                        b[i].collider2D.enabled = false;
                        string text = ((GUIText)GetComponent("GUIText")).text;
                        Debug.Log("Letter was hit " + text + " <- " + ((GUIText)l[i].GetComponent("GUIText")).text);
                        ((GUIText)GetComponent("GUIText")).text =
                            text.Substring(0,blanks[blankIndex])    +((GUIText)l[i].GetComponent("GUIText")).text
                            + text.Substring(blanks[blankIndex]+1,text.Length-blanks[blankIndex]-1 );
                        ((GUIText)l[i].GetComponent("GUIText")).text = "";
                        blankIndex++;
                        if(blankIndex==3){
                            if (((GUIText)GetComponent("GUIText")).text.Equals(word))
                            {
                                Application.LoadLevel("win");
                            }
                            else
                            {
                                Application.LoadLevel("lose");
                            }
                        }
                    }
                }
            }
        }
    }
}
