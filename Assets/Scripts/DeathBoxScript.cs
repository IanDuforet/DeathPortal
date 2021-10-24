using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeathHandler _script = collision.transform.GetComponent<DeathHandler>();
        if (_script)
            _script.DestroyPlayer(false); //Don't leave a portal behind
    }
}
