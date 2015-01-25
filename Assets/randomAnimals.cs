using UnityEngine;
using System.Collections;

public class randomAnimals : MonoBehaviour {
	// array of possible animals
	private GameObject[] animals = new GameObject[18];
	// animal to appear for this particular miniGame instance
	private GameObject chosenOne;
	private BoxCollider2D animalCollider;

	// input = mouse or touch, will need to edit before exporting to android
	private Vector3 input;
	private int successfulTap = 0;
    bool sucessfulThisTime = false;
	private int totalAnimalAppearances = 0;

	// want the animal to appear/disappear every x seconds
	private float visibleTimeLimit = 0;
	private float invisibleTimeLimit = 0;

	// Use this for initialization
	IEnumerator Start () {

        // Load animals into array
        int i = 0;
        while (i < 18)
        {
            // load animals into array
            animals[i] = GameObject.Find("animal" + i);
            animals[i].renderer.enabled = false;
            i++;
        }

		GameObject instructions = GameObject.Find ("instructions");
		instructions.renderer.enabled = true;
		yield return new WaitForSeconds(2);
		instructions.renderer.enabled = false;
        Debug.Log("Done Waiting");
		GameObject landscape = GameObject.Find ("landscape2");
		landscape.renderer.enabled = true;

        yield return new WaitForSeconds(1);

		// Choose animal to use in this game
		int index = Random.Range(0, 18);
		chosenOne = animals[index];	
		chosenOne.renderer.enabled = true;
		animalCollider = chosenOne.AddComponent<BoxCollider2D> ();
        animalCollider.size = new Vector2(4,4);
	} // end of start
	
	// Update is called once per frame
	void Update () {
		// VISIBILITY
		// continue visibility
        if(chosenOne != null){
		if (chosenOne.renderer.enabled == true && visibleTimeLimit < 0.6){//0.5
			visibleTimeLimit = visibleTimeLimit + Time.deltaTime;
		}
		// continue invisibility
		else if (chosenOne.renderer.enabled == false && invisibleTimeLimit < 1.5){
			invisibleTimeLimit = invisibleTimeLimit + Time.deltaTime;
		}
		// else flip visiblity of animal and change location
		else {
			chosenOne.renderer.enabled = !chosenOne.renderer.enabled;
			if (chosenOne.renderer.enabled == false){ totalAnimalAppearances++;}
			visibleTimeLimit = 0;
			invisibleTimeLimit = 0;

            sucessfulThisTime = false;

			// change location
			Vector2 newPos;
			newPos.x = Random.Range (-7f, 7f);
			newPos.y = Random.Range (-3f, 3f);
			chosenOne.transform.position = newPos;
		}

		// TOUCH
		// if mouse/touch input has happened
		if (Input.GetMouseButtonDown (0)){
			input = Input.mousePosition;
			input = camera.ScreenToWorldPoint (input);
			input.z = 0;
			
			// determine if input is within the animal's bounds
            if (animalCollider.OverlapPoint(input) && !sucessfulThisTime)
            {
				Debug.Log ("collided");
				successfulTap++;
                sucessfulThisTime = true;
			}
			else {
				Debug.Log ("no collision");
			}
		} //end of input check
		
		// QUIT
		if (totalAnimalAppearances >= 5 && successfulTap >= 5){
			Debug.Log (totalAnimalAppearances, chosenOne);
			Debug.Log (successfulTap, chosenOne);
			Debug.Log ("win");
			Application.LoadLevel ("win");
		}
		else if (totalAnimalAppearances >= 5 && successfulTap < 5){
			Debug.Log (totalAnimalAppearances, chosenOne);
			Debug.Log (successfulTap, chosenOne);
			Debug.Log ("lose");
			Application.LoadLevel ("lose");
		}
        }
	} // endof update

} // endof class
