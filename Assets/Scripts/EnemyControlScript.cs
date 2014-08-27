using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class EnemyControlScript : MonoBehaviour
{
    public float Lifetime = 6f;

    private Stopwatch stopwatch = new Stopwatch();
	// Use this for initialization
	void Start ()
	{
	    stopwatch.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (stopwatch.ElapsedMilliseconds > Lifetime*1000)
        {
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
