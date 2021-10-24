using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    private GameObject _mouse;
    private GameObject _lastFound;

    bool _highlighted = false;

    private void Start()
    {
        _mouse = GameObject.Find("Mouse");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Do a raycast to check if the mouse finds a portal
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        _mouse.transform.position = mousePos2D;
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider!= null && hit.transform.tag == "Portal")
        {
            //Save the current found portal so you can unhighlight it
            _lastFound = hit.transform.gameObject;
            if(!_highlighted)
            {
                hit.transform.GetComponent<PortalScript>().Highlight(true);
                SoundManager.Instance.PlaySound(SoundManager.Sounds.Highlight);
                _highlighted = true;
            }

            if(Input.GetMouseButtonDown(0))   //If you click on a portal, teleport to it and play it's animation once
            {
                hit.transform.GetChild(0).GetComponent<Animation>().Play();
                this.transform.position = hit.transform.position;
                SoundManager.Instance.PlaySound(SoundManager.Sounds.Teleport);
            }
        }
        else if (hit.collider == null) //If your mouse is no longer on a portal, disable it's highlight of the previous one
        {
            if(_lastFound)
                _lastFound.GetComponent<PortalScript>().Highlight(false);
            _highlighted = false;
        }
    }
}
