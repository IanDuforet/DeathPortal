using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    DoorScript _connectedDoor;
    [SerializeField]
    private float _timePressed = 1;
    private Image _timerImage;

    private float _timer;

    private bool _pressed { get; set; }
    private float _buttonTopY;
    private float _treshHold = 0.07f;
    private bool _playedSound = false;

    void Start()
    {
        _timerImage = this.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _buttonTopY = this.transform.GetChild(0).localPosition.y;
 
        if (_buttonTopY < _treshHold)
        {
            //Reset the timer for the visual
            _timer = _timePressed;

            //If the button is below the treshhold and it's not pressed yet, make it pressed and update the door
            if (!_pressed)
            {
                _pressed = true;
                _connectedDoor.SetState(_pressed);
                if (!_playedSound)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Sounds.ButtonPress);
                    _playedSound = true;
                }
            }
        }
        else
        {
            //If the button is back above the treshhold AND the button is still pressed,
            //unpress it and close the door
            if (_pressed)
            { 
                _pressed = false;
                //Close the door after x seconds
                Invoke("CloseDoor", _timePressed);
                _playedSound = false;
            }
        }

        _timer -= Time.deltaTime;

        //Scale the timer of the visual
        _timerImage.fillAmount = _timer / _timePressed;
    }

    void CloseDoor()
    {
        _connectedDoor.SetState(_pressed);
    }
}
