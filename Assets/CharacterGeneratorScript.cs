
using System.Diagnostics;
using System.Security.Principal;
using System.Timers;
using UnityEngine;
using System.Collections;

public class CharacterGeneratorScript : MonoBehaviour
{

    public GameObject[] Characters;
    public float MinTime = 1f;
    public float MaxTime = 3f;

    private float currentTimeSpan;

    private Stopwatch stopwatch = new Stopwatch();
    private GameObject nextCharacter;
    // Use this for initialization
    private void Start()
    {
        stopwatch.Start();
        UpdateAll();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (stopwatch.ElapsedMilliseconds > currentTimeSpan*1000)
        {
            stopwatch.Reset();
            stopwatch.Start();

            Instantiate(nextCharacter, transform.position, Quaternion.identity);

            UpdateAll();
        }
    }

    private void UpdateCurrentTimeSpan()
    {
        currentTimeSpan = Random.Range(MinTime, MaxTime);
    }

    private void UpdateNextCharacter()
    {
        nextCharacter = Characters[Random.Range(0, Characters.Length)];
    }

    private void UpdateAll()
    {
        UpdateCurrentTimeSpan();
        UpdateNextCharacter();
    }
}
