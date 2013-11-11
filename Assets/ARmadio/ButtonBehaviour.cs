using System;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
	private static float windowWidth = 300;
	private static float windowHeight = 75;
	private Rect exitWindow;
	private bool showQuitWindow = false;

    void OnGUI() {
		if (showQuitWindow)
		{
			// Tworzy nowe okno uzywajac zmiennej exitWindow jako polozenie i rozmiary okna
			// Oraz metody DoExitWindow do interakcji z uzytkownikiem
        	exitWindow = GUI.Window(0, exitWindow, DoExitWindow, "Quit?");
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
	
	void Update()
	{
		// KeyCode.Escape jest mapowany na przycisk powrotu w urzadzeniach z systemem Android
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			showQuitWindow = !showQuitWindow;
		}
	}
}
