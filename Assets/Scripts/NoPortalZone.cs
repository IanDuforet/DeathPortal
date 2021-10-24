using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPortalZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<DeathHandler>().InNoPortalZone = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<DeathHandler>().InNoPortalZone = false;
        }
    }
}
