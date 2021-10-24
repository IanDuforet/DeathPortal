using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator _doorAnimator;

    private bool _isOpen { get; set; }

    private void Start()
    {
        _doorAnimator = this.GetComponent<Animator>();
    }

    public void SetState(bool state)
    {
        _isOpen = state;
        _doorAnimator.SetBool("Open", _isOpen);
    }
}
