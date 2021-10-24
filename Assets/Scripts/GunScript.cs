using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _delay = 0;

    [SerializeField]
    private float _coolDown = 2; //THIS CAN NEVER BE LESS THAN 1

    // Start is called before the first frame update
    void Start()
    {
        //Start the gun after x amount of seconds
        Invoke("Shoot", _delay);
    }
    void Shoot()
    {
        this.GetComponentInChildren<Animation>().Play();
        //Spawn a bullet after the reload has played
        Invoke("SpawnBullet", _coolDown);
    }
    
    void SpawnBullet()
    {
        Vector3 spawnPos = this.transform.GetChild(0).transform.GetChild(0).transform.position;
        Quaternion rotSpawnRot = this.transform.rotation;
        Instantiate(_bulletPrefab, spawnPos, rotSpawnRot, null);
        //Shoot and reload again
        Shoot();
    }
}
