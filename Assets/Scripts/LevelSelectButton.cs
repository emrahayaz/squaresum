using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour {
	public int index;
	MainGame game;
	// Use this for initialization
	void Start () {
		game = MainGame.getGame ();
		
						GetComponent<Button> ().onClick.AddListener (delegate {
								game.level = index;
								
								game.generateVals ();
								Application.LoadLevel (1);
								
						});
	}

}
