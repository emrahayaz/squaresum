using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeLogic : MonoBehaviour {
	//level elements
	public RectTransform levelsPanel,levelSelector;
	public Button nextLevels,prevLevels,cancel;
	public Sprite deactiveImage,activeImage,activeNext,passiveNext,activePrev,passivePrev;
	int levelWrapper=0;

	//level elements end

	MainGame game;
	public Button start,quit,credits;


	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("MaxLevel", 1);
		//print(PlayerPrefs.GetInt("MaxLevel", 1));
		game = MainGame.getGame ();
		levelsPanelActivate(start);
		quit.onClick.AddListener (delegate {
			QuitGame();
		});

		game.RequestBanner ();



	}


	//level functions

	void levelsPanelActivate(Button b){
		generateButtons(levelWrapper);
		b.onClick.AddListener (delegate {
			levelSelector.GetComponent<Animator>().SetInteger("animState",1);
		});
		nextLevels.onClick.AddListener (delegate {
			levelWrapper++;
			generateButtons(levelWrapper);
			checkActivePassiveLevelsButton();
			
		});
		
		prevLevels.onClick.AddListener (delegate {
			levelWrapper--;
			generateButtons(levelWrapper);
			checkActivePassiveLevelsButton();
		});
		cancel.onClick.AddListener (delegate {
			levelSelector.GetComponent<Animator>().SetInteger("animState",0);
		});
		checkActivePassiveLevelsButton ();
	}

	void generateButtons(int index){
		int maxLevel=PlayerPrefs.GetInt("MaxLevel", 1);

		for (int i=0; i<10; i++) {

			if((i+1+(index*10))>maxLevel){
				levelsPanel.GetChild(i).GetComponent<Button>().enabled=false;
				levelsPanel.GetChild(i).GetComponent<Image>().sprite=deactiveImage;
			}else{
				levelsPanel.GetChild(i).GetComponent<Button>().enabled=true;
				levelsPanel.GetChild(i).GetComponent<Image>().sprite=activeImage;
			}
			levelsPanel.GetChild(i).GetComponent<LevelSelectButton>().index=i+1+(index*10);
			levelsPanel.GetChild(i).GetChild(0).GetComponent<Text>().text=""+(i+1+(index*10));
		}
	}

	void checkActivePassiveLevelsButton(){
		int a = game.levels.Length;


		if (a > ((levelWrapper+1) * 10)) {
			nextLevels.GetComponent<Button>().enabled=true;
			nextLevels.GetComponent<Image>().sprite=activeNext;
		} else {
			nextLevels.GetComponent<Button>().enabled=false;
			nextLevels.GetComponent<Image>().sprite=passiveNext;
		}

		if (levelWrapper>0) {
			prevLevels.GetComponent<Button>().enabled=true;
			prevLevels.GetComponent<Image>().sprite=activePrev;
		} else {
			prevLevels.GetComponent<Button>().enabled=false;
			prevLevels.GetComponent<Image>().sprite=passivePrev;
		}
	}
	void QuitGame(){
		Application.Quit();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) { QuitGame(); }
	}

	//level functions end
	

}
