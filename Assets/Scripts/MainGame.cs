using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;



public class MainGame {
	public int[] levelTargets=new int[]{
		1,4,6,7,7,8,8,8,8,9,
		9,9,8,11,8,10,10,8,7,8
	};
	public int[][] levels=new int[][] {
		new int[] { -1, -1, -1, -1, -1,
		  -1, 0, 2, 0, -1,
		  -1, 4, 0, 3, -1,
		  -1, 0, 1, 0, -1,
		  -1, -1, -1, -1, -1},
		new int[] { -1, 0, 0, 0, -1,
		   0, 0, 1, 0, 0,
		   0, 2, 0, 2, 2,
		   3,-1, 0, 0, 0,
		   -1, 0, 0, 0, -1 },
		new int[] { 	-1, 0, 0, 3, 0,
			0, 0, 2,  3, 1,
			7,0, -1,  0, 0,
			2, 0, 3,  0, 1,
			0, 0, 1,  0, 0 },
		new int[] { 0, 1, 1,  0, 2,
			0, 0, 0,  3, 1,
			1, 0,-1, -1, 0,
			1, 0, 0,  2, 0,
			0, 0, 1,  0, 0 },
		new int[] { 	7, 1, 0,2, 0,
			0, 6, 0,  0, 0,
			0,0, 3,  5, 8,
			0, -1, 0,  0, 0,
			0, 0, 3,  4, 0 },
		new int[] { 	0, 1, 0,0, 0,
			0, 0, 1,  1, 4,
			0,5, 0,  -1, 0,
			2, 0, 7,  0,3,
			0, 1, 0,  0, 3},
		new int[] { 0, 1, 0,  0, 2,
		  0, 0, 0,  3, 1,
		 11, 0, 0,  -1, 0,
		  1, 0, 6,  2, 1,
		  0, 0, 1,  0, 0 },
		new int[] { 0, 1, 0, -2, 2,
		  0, 0, 0,  3, 1,
		 11, 0, 1,  0, 0,
		  1, 0, 6,  0, 1,
		  0, 0, 1,  0, 0 },
		new int[] { 	2, 1, 0,3, 0,
			0, 3, 0,  0, 5,
			3,3, -1,  5, 0,
			-1, 0, 2,  0, 2,
			0, 1, 2,  -1, 0 },
		new int[] { 4, 0, 0, 3, 4,
			0, 0, 2,  3, 1,
			11, 0, -1,  0, 0,
			1, 0, 3,  0, 1,
			0, 0, 1,  0, 0 },
		//11-20
		new int[] { 4, 0,2, 1, 1,
			0, 0, 2,  7, 1,
			1, 0, 0,  0, 0,
			1, 0, -1,  0, 1,
			0, 3, 1,  0, 0 },
		new int[] { 	9, 0, 0, 3, 0,
			0, 0, 2,  3, 1,
			-1,0, 0,  0, 0,
			2, 0, 3,  4, 1,
			0, 2, 1,  0, 0 },

		new int[] { 	0, 2, 0, 3, 0,
			1, 0, 1,  0, 0,
			1,0, 0,  1, 0,
			0, 1, 1,  0, 1,
			1, 0, 0,  1, 0 },
		new int[] { 	3, 6, 0, 3, 0,
			1, 0, 1,  0, 0,
			1,2, 0,  1, 0,
			0, -1, 1,  -1, 1,
			1, 0, 1,  1, 8 },
		new int[] { 	1, 0, 5,1, 0,
			0, 4, 0,  0, 0,
			3,0, 2,  7, 0,
			3, -1, 0,  4, 0,
			0, 0, 0,  3, 4 },
		new int[] { 	1, 1, 0,5, 0,
			7, 2, 4,  -1, 2,
			0,-1, 0,  0, 4,
			1, 2, 3,  5, 0,
			0, 0, 6,  0, 7 },
		new int[] { 	0, 1, 2,-1, 2,
			0, -1, 1,  2, 0,
			4,0, 1,  0, 3,
			3, 0, -1,  4, 0,
			3, 3, 0,  1, 3 },


		new int[] { 	0, 3, 3,3, 0,
			0, 3, -1,  2, 0,
			3,0, 0,  3, 0,
			0, 5, 0,  0, 4,
			0,5, 0,  -1, 0 },
		new int[] { 	-1, 2, 2,3, 0,
			0, 0,2,  2, 0,
			0,2, 2,  5, 0,
			2, 0, 0, 2,2,
			0, 0,2,  0, 2 },

		new int[] { 	1, 1, 0,1, 1,
			0, 1, 0,  1, 0,
			1,-1, 1,  0,2,
			0, 1, 0, -1, 2,
			0, 0, 1,  0, 0 },



	};
	private static MainGame game;
	private int[] values;
	public int level=1,restarted=0;
	private int score;
	public int total;
	public RectTransform levelClear,gameOver,popup;
	public Text point,levelText,target;
	private bool isEnded;
	public Button restart,restart2,goToMenu,next,goToMenu2,popupClose,popupClose2;
	public Canvas canvas;
	public InterstitialAd interstitial;


	public Cell[] buttons;

	private MainGame(){
		buttons = new Cell[25];
	}
	public static MainGame getGame(){
		if(game==null){
			game=new MainGame();
			game.generateVals();
			game.isEnded=false;
		}
		return game;
	}

	public int[] Values{      
		set { 
			game.values = value; 
		}
		
		get { 
			return game.values; 
		}
		
	}




	public int Score{
		set{
			game.point.text=""+value;
			game.score=value;
		}
		get{
			return game.score;
		}
	}
	public bool checkIfEnded(){
		bool ended = true;
		int positives = 0;
		for(int i=0;i<game.buttons.Length;i++){
			if(game.buttons[i].Val>0)positives++;
			if(game.buttons[i].isClickable()==true){
				ended =false;
			}
		}
		if(ended==true || game.total<=game.score){
			if(game.total==game.score && positives==1)
			{	int maxLevel=PlayerPrefs.GetInt("MaxLevel",1);
				game.levelClear.GetComponent<Animator>().SetInteger("animState",1);
				if(maxLevel<(game.level+1) && (game.level+1)<=game.levels.Length)PlayerPrefs.SetInt("MaxLevel",game.level+1);
				if(game.level%2==0 && game.level>1)game.RequestInterstitial ();
			}
			else	
				game.gameOver.GetComponent<Animator>().SetInteger("animState",1);
				
			return true;
		}else
		return false;
	}

	public bool IsEnded{
		set{
			game.isEnded=value;
		}
		get{
			return game.isEnded;
		}
	}

	public void generateVals(){
		game.Values=new int[25];
		for (int i=0; i<game.Values.Length; i++) {
						game.Values [i] = game.levels[(game.level-1)][i];
				}
		game.total = game.findMin (game.levels[game.level-1]);
	}
	public void loadNewLevel(){

	}
	public void reloadLevel(){
		game.restarted++;
		if (game.restarted % 5 == 0)
						game.RequestInterstitial ();
		game.Score = 0;
		game.gameOver.GetComponent<Animator>().SetInteger("animState",0);
		game.levelClear.GetComponent<Animator>().SetInteger("animState",0);
		game.levelText.text = game.level.ToString ();
		for (int i=0; i<game.buttons.Length; i++) {
			game.buttons [i].Val = game.Values [i];
		}
		game.total = game.findMin (game.levels[game.level-1]);
		game.target.text = game.total.ToString ();

	}
	public void addButton(Cell c,int index){
		c.index = index;
		c.Val = game.Values [index];
		game.buttons [index] = c;
	}

	public void disableAllButtons(){
		//for (int i=0; i<game.buttons.Length; i++);
		game.next.enabled = false;
		game.goToMenu.enabled = false;
		game.goToMenu2.enabled = false;
		game.restart.enabled = false;

	}
	public void enableAllButtons(){
		//for (int i=0; i<game.buttons.Length; i++);
		game.next.enabled = true;
		game.goToMenu.enabled = true;
		game.goToMenu2.enabled = true;
		game.restart.enabled = true;
		
	}
	public void RequestBanner()
	{
		string adUnitId = "ca-app-pub-1003477908870610/7337594286";
		
		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);

	}


	public void RequestInterstitial()
	{
		string adUnitId = "ca-app-pub-1003477908870610/8814327483";
		
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().AddTestDevice("682D0A9CE85B8DEAB0102A48CB0F2769").Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		interstitial.AdLoaded += HandleAdLoaded;


	}

	public void HandleAdLoaded(object sender, EventArgs args)
	{
		if (game.interstitial.IsLoaded()) {
			game.interstitial.Show();
		}
	}
	public bool isClickableCell(int index,int[] grid){
		if (grid[index] <0)
			return false;
		int row = index / 5;
		int col = index % 5;
		int found = 0;
		if (grid[index] > 0)
			found++;
		if (row - 1 >= 0) {
			if(grid[index - 5]>0)found++;
			else if(grid[index - 5]<-1)
				return false;
		}
		if (row + 1 <= 4) {
			if(grid [index + 5]>0)found++;
			else if(grid[index + 5]<-1)
				return false;
		}
		if (col - 1 >= 0) {
			if(grid [index - 1]>0)found++;
			else if(grid[index - 1]<-1)
				return false;
			
		}
		if (col + 1 <= 4) {
			if(grid [index + 1]>0)found++;
			else if(grid[index + 1]<-1)
				return false;
		}
		if (found > 1)
			return true;
		else
			return false;
	}
	public int[] makeMoveAndReturn(int index,int[] grid){
		int[] gridtemp = new int[25];
		for (int i=0; i<25; i++)
						gridtemp [i] = grid [i];

		int row = index / 5;
		int col = index % 5;
		int sum = 0;
		if (row - 1 >= 0) {
			if(gridtemp[index - 5]>0){ sum +=gridtemp[index-5];
				gridtemp[index-5]=0;}
		}
		if (row + 1 <= 4) {
			if(gridtemp [index + 5]>0){sum +=gridtemp[index+5];
				gridtemp[index+5]=0;}
		}
		if (col - 1 >= 0) {
			if (gridtemp [index - 1] > 0){
				sum += gridtemp [index - 1];
				gridtemp [index - 1] = 0;
				}
			
		}
		if (col + 1 <= 4) {
			if(gridtemp [index + 1]>0){sum +=gridtemp[index+1];
				gridtemp[index+1]=0;}
		}
		gridtemp [index] += sum;
		return gridtemp;
	}
	
	public int isFinishedGrid(int[] grid){
		int positives = 0;
		for (int i=0; i<25; i++) {
			if(grid[i]>0)positives++;
			if(isClickableCell(i,grid))
				return 1;
		}
		if (positives == 1)
						return 2;
		else
		   return 3;
	}


	public int findMin(int[] grid){
		if(game.levelTargets[game.level-1]>0) return game.levelTargets[game.level-1];
		int a = 111111;
		int realindex=0;
		int tmp = isFinishedGrid (grid);
		if (tmp == 1) {
						
						for (int i=0; i<grid.Length; i++) {
								if (isClickableCell (i, grid) == true) {
										int temp = findMin (makeMoveAndReturn (i, grid));
									if(temp + 1 < a){
										realindex=i;
										a=temp + 1;
									}
								}
						}

		} else if (tmp == 2) {
			return 0;
		} else {
			return 10000000;
		}
		return a;

	}
	public string findMinString(int[] grid){
		//if(game.levelTargets[game.level-1]>0) return "";
		string result = "";
		int a = 111111;
		int realindex=0;
		int tmp = isFinishedGrid (grid);
		if (tmp == 1) {
			
			for (int i=0; i<grid.Length; i++) {
				if (isClickableCell (i, grid) == true) {
					int temp = findMin (makeMoveAndReturn (i, grid));
					if(temp + 1 < a){
						result=i.ToString()+" : "+findMinString(makeMoveAndReturn (i, grid));
						a=temp + 1;
					}
				}
			}
			
		} else if (tmp == 2) {
			return " finished";
		} else {
			return "10000000";
		}
		return result;
		
	}
	
	
	
}
