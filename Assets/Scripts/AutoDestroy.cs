using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        //Automatically destroy the object after 1 second
        //CAN IMRPOVE THIS BY MAKING THE TIME A SERIALIZED FIELD
        Destroy(this.gameObject, 1);   
    }
}
