using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TutorialInfo : MonoBehaviour 
{

	 
	public bool showAtStart = true;
	public GameObject overlay;
	public AudioListener mainListener;
	public Toggle showAtStartToggle;



	public static string showAtStartPrefsKey = "showLaunchScreen";



	void Awake()
	{
		if (PlayerPrefs.HasKey(showAtStartPrefsKey))
		{
			showAtStart = PlayerPrefs.GetInt(showAtStartPrefsKey) == 1;
		}
			
		showAtStartToggle.isOn = showAtStart;
	
		if (showAtStart) 
		{
			ShowLaunchScreen();
		}
		else 
		{
			StartGame ();
		}

	}
		
	public void ShowLaunchScreen()
	{
		Time.timeScale = 0f;
		mainListener.enabled = false;
		overlay.SetActive (true);
	}
		


	public void StartGame()
	{		
		overlay.SetActive (false);
		mainListener.enabled = true;
		Time.timeScale = 1f;
	}


	public void ToggleShowAtLaunch()
	{
		showAtStart = showAtStartToggle.isOn;
		PlayerPrefs.SetInt(showAtStartPrefsKey, showAtStart ? 1 : 0);
	}
}
