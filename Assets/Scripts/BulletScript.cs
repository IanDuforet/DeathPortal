using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    int _speed = 100;

    [SerializeField]
    private GameObject _ParticleSystem;

    // Update is called once per frame
    void Update()
    {
        //Move the bullet every frame
        this.transform.Translate(this.transform.up * (_speed * Time.deltaTime), Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the bullet collides with something, spawn it's particles and destroy the bullets
        //The particles will destroy themselves after one second
        _ParticleSystem = Instantiate(_ParticleSystem, this.transform.position, this.transform.rotation, null) as GameObject;
        Destroy(this.gameObject);

        SoundManager.Instance.PlaySound(SoundManager.Sounds.BulletExplosion);

        //Check if collision with player
        if(collision.transform.tag == "Player")
        {
            DeathHandler _script = collision.transform.GetComponent<DeathHandler>();
            if (_script)
                _script.DestroyPlayer(true); //True means leave a portal behind
        }


    }
}
