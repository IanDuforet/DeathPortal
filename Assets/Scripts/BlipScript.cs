using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] _blips;

    int _lives;

    int _blipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get amount of lives
        _lives = GameObject.Find("GameManager").GetComponent<GameManager>().GetLives();
        //Get all the  sprites and put them in the array
        _blips = this.GetComponentsInChildren<SpriteRenderer>();

        //Disable amount of lives 
        int amountToDisable = _blips.Length+1 - _lives;
        for(int i = _blips.Length-1; amountToDisable > 0; i--)
        {
            _blips[i].enabled = false;
            amountToDisable--;
        }

        //-2 because -1 for 0 based index and -1 because the life you're already using
        _blipIndex = _lives - 2;
    }

    public void AddBlip()
    {
        //Increase index
        _blipIndex++;
        //Show next blip
        _blips[_blipIndex].enabled = true;
    }

    public void RemoveBlip()
    {
        //Disable one blip
        _blips[_blipIndex].enabled = false;
        //Decrease index
        _blipIndex--;
    }
}
