using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public bool _highlighted;
    private SpriteRenderer _renderer1;
    private SpriteRenderer _renderer2;
    private Color _Default1;
    private Color _Default2;

    [SerializeField]
    private Color _highlightColor;


    // Start is called before the first frame update
    void Start()
    {
        //Save the original colors
        SpriteRenderer[] renderers = this.GetComponentsInChildren<SpriteRenderer>();
        _renderer1 = renderers[0];
        _renderer2 = renderers[1];
        _Default1 = _renderer1.color;
        _Default2 = _renderer2.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_highlighted)
        {
            //Change to highlight color
            _renderer1.color = _highlightColor;
            _renderer2.color = _highlightColor;
        }
        else if (!_highlighted)
        {
            //Swap back to original color
            _renderer1.color = _Default1;
            _renderer2.color = _Default2;
        }
    }

    public void Highlight(bool b)
    {
        _highlighted = b;
    }
}

