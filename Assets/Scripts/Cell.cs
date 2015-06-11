using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cell : MonoBehaviour {
	Button button;
	public int index;
	private int value;
	Image image;
	MainGame game;
	Text buttonText;
	bool enabledButton;
	// Use this for initialization
	void Awake () {
		enabledButton = true;
		game = MainGame.getGame ();
		image = GetComponent<Image> ();
		button = GetComponent<Button> ();
		buttonText=GetComponent<RectTransform> ().GetChild (0).GetComponent<Text>();
		button.onClick.AddListener (clickEd);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Val{
		set{
			if(value==-1){
				enabledButton=false;
				buttonText.text="";
				button.enabled=false;
				
				this.value=0;
				image.color=new Color(0.7f,0.7f,0.7f);
			}else{
				button.enabled=true;
				enabledButton=true;
				buttonText.text=""+value;
				if(value==0)
					image.color=new Color(1f,1f,1f);
				else if(value <5 )
					image.color=new Color(0.95f,0.92f,0.56f);
				else if(value <10 )
					image.color=new Color(0.918f,0.733f,0.392f);
				else if(value<20)
					image.color=new Color(0.85f,0.584f,0.349f);
				else
					image.color=new Color(0.75f,0.18f,0.129f);



			this.value=value;
			}
		}
		get{
			return this.value;
		}
	}

	public bool isClickable(){
		if (enabledButton == false)
						return false;
		int row = index / 5;
		int col = index % 5;
		int found = 0;
		if (Val > 0)
						found++;
		if (row - 1 >= 0) {
			if(game.buttons [index - 5].Val>0)found++;
		}
		if (row + 1 <= 4) {
			if(game.buttons [index + 5].Val>0)found++;
		}
		if (col - 1 >= 0) {
			if(game.buttons [index - 1].Val>0)found++;
			
		}
		if (col + 1 <= 4) {
			if(game.buttons [index + 1].Val>0)found++;
		}
		if (found > 1)
						return true;
				else
						return false;
	}


	public void clickEd(){
		game.next.enabled=true;

		int row = index / 5;
		int col = index % 5;
		int sum = 0;
		if (isClickable()) {
						if (row - 1 >= 0) {
								
								sum+=game.buttons [index - 5].Val;
								if(game.buttons [index - 5].enabledButton==true)game.buttons [index - 5].Val = 0;
						}
						if (row + 1 <= 4) {
								
								sum+=game.buttons [index + 5].Val;
								if(game.buttons [index + 5].enabledButton==true)game.buttons [index + 5].Val = 0;
						}
						if (col - 1 >= 0) {
								
								sum+=game.buttons [index - 1].Val;
								if(game.buttons [index - 1].enabledButton==true)game.buttons [index - 1].Val = 0;
						}
						if (col + 1 <= 4) {
										
								sum+=game.buttons [index + 1].Val;
								if(game.buttons [index + 1].enabledButton==true)game.buttons [index + 1].Val = 0;
			
						}
						Val += sum;
			game.Score=game.Score+1;
			game.checkIfEnded ();

		} 




	}

	IEnumerator FadeOut(Image im) {
		float first=1.0f;
		float k;
		while (first>0.5f) {
			Color c=im.color;
			k=Mathf.Lerp(first,0.4f,0.05f);
			print (k);
			c.a=k;
			first=k;
			im.color=c;
			yield return 0;
		}
		first = 0.5f;
		while (first<=1f) {
			Color c=im.color;
			k=Mathf.Lerp(first,1f,0.05f);
			c.a=k;
			first=k;
			im.color=c;
			yield return 0;
		}
	}
}
