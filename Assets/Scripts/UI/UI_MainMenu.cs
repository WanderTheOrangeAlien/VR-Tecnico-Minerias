using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
	public Button Btn_Start;
	public Button Btn_Credits;
	public Button Btn_Exit;
	
	public Button Btn_test;
	
	
	// Start is called before the first frame update
	void Awake()
	{
		Btn_Start.onClick.AddListener(() => {
			SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
		});
	    
		Btn_Credits.onClick.AddListener(() => {
	    	
		});
	    
		Btn_Exit.onClick.AddListener(() => {
			Application.Quit();
		});
		
	}

	// Update is called once per frame
	void Update()
	{
        
	}
}
