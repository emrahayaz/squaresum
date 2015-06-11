using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hexagon : MonoBehaviour {
	/*Button[] buttons;

	int gridSize;
	RectTransform rect;
	MainGame currentGame;
	// Use this for initialization
	void Start () {
		currentGame = MainGame.getGame ();
		rect= GetComponent<RectTransform>();
		buttons = GetItems ();
		gridSize=rect.childCount;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	Button[] GetItems() {

		Button[] items = new Button[rect.childCount];
		for (int i = 0; i < rect.childCount; i++) {
			items[i] = rect.GetChild(i).GetComponent<Button>();
			items[i].GetComponent<Cell>().index=i;
			items[i].GetComponent<Cell>().value=i;
			(items[i].GetComponent<RectTransform>().GetChild(0).GetComponent<Text>()).text=""+i;
			//items[i].GetComponent<Text>().text=""+i;

		}
		return items;
	}*/
}
