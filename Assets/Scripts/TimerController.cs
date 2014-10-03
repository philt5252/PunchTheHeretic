using System;
using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public float RemainingSeconds;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    guiText.text = "Timer: " + Math.Round(RemainingSeconds,2);
	}
}
