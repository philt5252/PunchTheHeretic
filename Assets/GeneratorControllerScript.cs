using System.Diagnostics;
using System.Linq;
using UnityEngine;
using System.Collections;

public class GeneratorControllerScript : MonoBehaviour
{

    public CharacterGeneratorScript[] CharacterGenerators;
    public GameObject[] Characters;

    public float MinTime = 0.5f;
    public float MaxTime = 2f;

    private Stopwatch stopwatch = new Stopwatch();
    private float currentTimeSpan;

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
        if (stopwatch.ElapsedMilliseconds > currentTimeSpan * 1000)
        {
            

            //Instantiate(nextCharacter, transform.position, Quaternion.identity);

            //UpdateAll();
            CreateCharacter();

            UpdateCurrentTimeSpan();

            stopwatch.Reset();
            stopwatch.Start();
        }
    }

    private void CreateCharacter()
    {
        CharacterGeneratorScript[] generators = CharacterGenerators.Where(g => !g.HasCharacter()).ToArray();

        if (generators.Length == 0)
            return;

        int generatorIndex = Random.Range(0, generators.Length);
        int characterIndex = Random.Range(0, Characters.Length);

        CharacterGeneratorScript selectedGenerator = generators[generatorIndex];
        GameObject selectedCharacter = Characters[characterIndex];

        selectedGenerator.CreateCharacter(selectedCharacter);
    }

    private void UpdateCurrentTimeSpan()
    {
        currentTimeSpan = Random.Range(MinTime, MaxTime);
    }
}
