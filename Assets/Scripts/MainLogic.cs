using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MainLogic : MonoBehaviour {

	//level elements
	public RectTransform levelsPanel,levelSelector,popup;
	public Button nextLevels,prevLevels,cancel,popupClose,popupClose2;
	public Sprite deactiveImage,activeImage,activeNext,passiveNext,activePrev,passivePrev;
	int levelWrapper=0;
	//level elements end
	
	public RectTransform table,levelClear,gameOver;
	public Button restart,restart2,goToMenu,next,goToMenu2,restartTextButton,mainmenuTextButton;
	MainGame game;
	public Text point,levelText,target;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		game = MainGame.getGame ();
		for (int i=0; i<game.Values.Length; i++) {
			game.addButton(table.GetChild(i).GetComponent<Cell>(),i);
			}
		game.point = point;
		game.levelClear = levelClear;
		game.gameOver = gameOver;
		game.restart = restart;
		game.restart2 = restart2;
		game.goToMenu = goToMenu;
		levelsPanelActivate (game.goToMenu);
		game.popup = popup;
		game.goToMenu2 = goToMenu2;
		game.popupClose = popupClose;
		game.popupClose.onClick.AddListener (delegate {
			game.popup.GetComponent<Animator>().SetInteger("animState",0);
		});
		game.popupClose2 = popupClose2;
		game.popupClose2.onClick.AddListener (delegate {
			game.popup.GetComponent<Animator>().SetInteger("animState",0);
		});
		levelsPanelActivate (game.goToMenu2);
		game.next = next;
		game.levelText = levelText;
		game.canvas = canvas;
		game.target = target;
		game.target.text = game.total.ToString ();
		game.levelText.text = game.level.ToString();
		game.restart.onClick.AddListener (()=>game.reloadLevel());
		game.restart2.onClick.AddListener (()=>game.reloadLevel());

		game.next.onClick.AddListener (delegate{
					game.next.enabled=false;
					game.level++;
					game.generateVals();
					game.reloadLevel();
			
		});
		restartTextButton.onClick.AddListener (delegate{
			game.generateVals();
			game.reloadLevel();
		});
		mainmenuTextButton.onClick.AddListener (delegate{
			Application.LoadLevel(0);
		});
		game.Score = 0;
		if(game.level==1)game.popup.GetComponent<Animator>().SetInteger("animState",1);
		//print (game.findMinString(game.levels[game.level-1]));


	}

	//level functions
	
	void levelsPanelActivate(Button b){


		b.onClick.AddListener (delegate {
			generateButtons(levelWrapper);
			game.levelClear.GetComponent<Animator>().SetInteger("animState",0);
			game.gameOver.GetComponent<Animator>().SetInteger("animState",0);
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
		for (int i=0; i<levelsPanel.childCount; i++) {
			
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
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.LoadLevel(0); }
	}
	//level functions end



	

}
