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
    public TimerController timerController;
    public CharacterGeneratorScript[] CharacterGenerators;
    public GameObject[] Characters;
    public int[] CharacterWeights;

    public int ConsecutiveHereticsForBonusTime = 10;
    public int BonusTime = 5;
    public float LevelTime = 60;

    public float MinTime = 0.5f;
    public float MaxTime = 2f;

    private Stopwatch stopwatch = new Stopwatch();
    private float currentTimeSpan;

    private int characterWeightTotal;
    private int currentConsecutiveHeretics = 0;

    // Use this for initialization
    void Start()
    {
        timerController.RemainingSeconds = LevelTime;
        characterWeightTotal = CharacterWeights.Sum();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        LevelTime -= Time.deltaTime;
        
        if (LevelTime <= 0)
        {
            stopwatch.Stop();
            Application.LoadLevel("PostLevel");
            return;
        }

        timerController.RemainingSeconds = LevelTime;

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
        var selectedGenerator = SelectGenerator();

        if (selectedGenerator == null)
            return;

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

        GameObject selectedCharacter = Characters[characterIndex];

        CharacterControlScript character = selectedGenerator.CreateCharacter(selectedCharacter);

        character.CharacterPunched += CharacterOnCharacterPunched;
        character.CharacterSurvived += CharacterOnCharacterSurvived;
    }

    private CharacterGeneratorScript SelectGenerator()
    {
        CharacterGeneratorScript[] generators = CharacterGenerators.Where(g => !g.HasCharacter()).ToArray();

        if (generators.Length == 0)
            return null;

        int generatorIndex = Random.Range(0, generators.Length);
        CharacterGeneratorScript selectedGenerator = generators[generatorIndex];
        return selectedGenerator;
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

        if (characterControlScript is HereticControlScript)
        {
            currentConsecutiveHeretics++;

            if (currentConsecutiveHeretics >= ConsecutiveHereticsForBonusTime)
            {
                currentConsecutiveHeretics = 0;

                LevelTime += BonusTime;
            }
        }
        else
        {
            currentConsecutiveHeretics = 0;
        }
    }

    private void UpdateCurrentTimeSpan()
    {
        currentTimeSpan = Random.Range(MinTime, MaxTime);
    }
}
