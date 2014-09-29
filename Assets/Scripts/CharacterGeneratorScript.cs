
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Timers;
using Assets;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public class CharacterGeneratorScript : MonoBehaviour
{
    private GameObject currentCharacter;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public CharacterControlScript CreateCharacter(GameObject character)
    {
        currentCharacter = Instantiate(character, this.transform.position, Quaternion.identity) as GameObject;

        return currentCharacter.GetComponent<CharacterControlScript>();
    }

    public bool HasCharacter()
    {
        return currentCharacter != null;
    }

}
