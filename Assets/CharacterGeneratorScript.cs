
using System.Diagnostics;
using System.Security.Principal;
using System.Timers;
using UnityEngine;
using System.Collections;

public class CharacterGeneratorScript : MonoBehaviour
{
    private Object currentCharacter;

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

    public void CreateCharacter(GameObject character)
    {
        currentCharacter = Instantiate(character, this.transform.position, Quaternion.identity);
    }

    public bool HasCharacter()
    {
        return currentCharacter != null;
    }

}
