using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DeathHandler : MonoBehaviour
{
    public bool InNoPortalZone { get; set; }

    private GameManager _gameManager;
    private BlipScript _blipScript;
    private CameraScript _cameraScript;

    [SerializeField]
    private GameObject _portalPrefab;
    [SerializeField]
    private GameObject _deathParticles;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _blipScript = GameObject.Find("BatteryArray").GetComponent<BlipScript>();
        _cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Allow the player to destoy themselves on button press
        if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(1))
        {
            DestroyPlayer(true); //Leave a portal behind
        }
    }

    public void DestroyPlayer(bool portal)
    { 
        Vector3 newPos = this.transform.position;

        //SPAWN PORTAL
        if(!InNoPortalZone)
            if(portal)
              Instantiate(_portalPrefab, newPos, this.transform.rotation, null); 

        //FEEDBACK
        //Particles
        Instantiate(_deathParticles, newPos, this.transform.rotation, null); //The particles will destroy themselves after one second
        //Screenshake
        _cameraScript.Shake(0.05f);

        //DEDUCT LIFE
        _gameManager.PlayerDie();
        if(_gameManager.GetLives() > 0)
        {
            //Update the visual on the battery
            _blipScript.RemoveBlip();
        }

        //SOUND
        SoundManager.Instance.PlaySound(SoundManager.Sounds.Death);

        //DESTROY
        Destroy(this.gameObject);
    }
}
