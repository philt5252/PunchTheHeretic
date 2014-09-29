using System.CodeDom;
using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width-55, Screen.height-55, 50, 50), "Back"))
        {
            
            Application.LoadLevel("MainMenu");
            //Application.LoadLevelAsync("Start");
        }
    }
}
