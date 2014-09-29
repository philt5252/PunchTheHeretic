using System;
using System.Diagnostics;
using System.Linq;
using Assets;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class LevelControllerScript : MonoBehaviour
{
    public ScoreController scoreContoller;
    public CharacterGeneratorScript[] CharacterGenerators;
    public GameObject[] Characters;
    public int[] CharacterWeights;

    public float MinTime = 0.5f;
    public float MaxTime = 2f;

    private Stopwatch stopwatch = new Stopwatch();
    private float currentTimeSpan;

    private int characterWeightTotal;

    // Use this for initialization
    void Start()
    {
        characterWeightTotal = CharacterWeights.Sum();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (stopwatch.ElapsedMilliseconds > currentTimeSpan * 1000)
        {
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
        int characterNum = Random.Range(0, characterWeightTotal);
        int characterIndex = 0;

        for (int i = 0; i < CharacterWeights.Length; i++)
        {
            if (characterNum < CharacterWeights.Take(i + 1).Sum())
            {
                characterIndex = i;
                break;
            }
        }

        CharacterGeneratorScript selectedGenerator = generators[generatorIndex];
        GameObject selectedCharacter = Characters[characterIndex];

        CharacterControlScript character = selectedGenerator.CreateCharacter(selectedCharacter);

        character.CharacterPunched += CharacterOnCharacterPunched;
        character.CharacterSurvived += CharacterOnCharacterSurvived;
    }

    private void CharacterOnCharacterSurvived(object sender, EventArgs eventArgs)
    {
        CharacterControlScript characterControlScript = sender as CharacterControlScript;

        characterControlScript.CharacterSurvived -= CharacterOnCharacterSurvived;

        scoreContoller.score += characterControlScript.PointsSurvived;
    }

    private void CharacterOnCharacterPunched(object sender, EventArgs eventArgs)
    {
        CharacterControlScript characterControlScript = sender as CharacterControlScript;

        characterControlScript.CharacterPunched -= CharacterOnCharacterPunched;

        scoreContoller.score += characterControlScript.PointsPunched;
    }

    private void UpdateCurrentTimeSpan()
    {
        currentTimeSpan = Random.Range(MinTime, MaxTime);
    }
}
