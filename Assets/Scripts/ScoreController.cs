using System;
using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{

    public int score = 0;

    public event EventHandler ScoreChanged;

    protected virtual void OnScoreChanged()
    {
        EventHandler handler = ScoreChanged;
        if (handler != null)
            handler(this, EventArgs.Empty);
    }

    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    guiText.text = "Score: " + score;
	}
}
