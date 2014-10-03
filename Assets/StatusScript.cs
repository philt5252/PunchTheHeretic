using UnityEngine;
using System.Collections;

public class StatusScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if (GlobalData.Score >= GlobalData.TargetStore)
	    {
	        guiText.text = "Success";
	    }
	    else
	    {
	        guiText.text = "Failure";
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(5, 5, 100, 50), "Test"))
        {
            Application.LoadLevel("Level" +(GlobalData.CurrentLevel+1));
        }
    }
}
