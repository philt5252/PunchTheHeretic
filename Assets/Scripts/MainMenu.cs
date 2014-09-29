using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(5, 5, 100, 50), "Test"))
        {
            Application.LoadLevel("MainScene");
        }
        else if (GUI.Button(new Rect(5, 150, 100, 50), "Help"))
        {
            Application.LoadLevel("Help");
        }
    }
}
