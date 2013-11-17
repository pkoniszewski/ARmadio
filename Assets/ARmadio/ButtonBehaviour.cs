using System;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
	private static float windowWidth = 300;
	private static float windowHeight = 75;
	private Rect exitWindow;
	private Rect contextMenu;
	private bool showQuitWindow = false;
	private bool showContextMenu = false;
	
	void Awake()
	{
		GlobalVariables.widthScale = Screen.width / GlobalVariables.widthNormalized;
		GlobalVariables.heightScale = Screen.height / GlobalVariables.heightNormalized;
		
		windowWidth = windowWidth*GlobalVariables.widthScale;
		windowHeight = windowHeight*GlobalVariables.heightScale;
		
		Debug.Log("MYTEST: WIDTH " + GlobalVariables.widthScale.ToString());
		Debug.Log("MYTEST: HEIGHT " + GlobalVariables.heightScale.ToString());
	}
	
    void OnGUI() {
		if (showQuitWindow)
		{
			// Tworzy nowe okno uzywajac zmiennej exitWindow jako polozenie i rozmiary okna
			// Oraz metody DoExitWindow do interakcji z uzytkownikiem
        	exitWindow = GUI.Window(0, exitWindow, DoExitWindow, "Quit?");
		}
		else if (showContextMenu)
		{
			contextMenu = GUI.Window(0, contextMenu, DoContextMenu, "Menu");
		}
    }
	
    void DoExitWindow(int windowID) {
		exitWindow = new Rect((Screen.width-windowWidth)/2f,
			(Screen.height-windowHeight)/2f,
			windowWidth,
			windowHeight);
		// Przycisk 'Yes' zamyka aplikacje
        if (GUI.Button(new Rect(10, 20, windowWidth/2 - 10, windowHeight - 25), "Yes"))
		{
            Application.Quit();
		}
		// Przycisk 'No' ukrywa menu
		else if (GUI.Button (new Rect(windowWidth/2 + 10, 20, windowWidth/2 - 20, windowHeight - 25), "No"))
		{
			showQuitWindow = false;
		}
    }
	
	void DoContextMenu(int windowId)
	{
		contextMenu = new Rect((Screen.width-windowWidth)/2f,
			(Screen.height-windowHeight)/2f,
			windowWidth,
			windowHeight);
	}
	
	void Update()
	{
		// KeyCode.Escape jest mapowany na przycisk powrotu w urzadzeniach z systemem Android
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			showContextMenu = false;
			showQuitWindow = !showQuitWindow;
		}
		else if (Input.GetKeyDown(KeyCode.Menu))
		{
			showQuitWindow = false;
			showContextMenu = !showContextMenu;
		}
	}
}
