using UnityEngine;
using System.Collections;

public class TurnIntoAnimal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer r = (SpriteRenderer)GetComponent("SpriteRenderer");
        Sprite sprite = Resources.Load("animal"+Random.Range(0,17), typeof(Sprite)) as Sprite;
        r.sprite = sprite;
	}
}
