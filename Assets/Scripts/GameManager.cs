using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _lives = 6;
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private GameObject _playerPrefab;

    public void PlayerDie()
    {
        _lives--;
        if (_lives > 0) //Respawn
        { 
            SpawnNewPlayer();
            SoundManager.Instance.PlaySound(SoundManager.Sounds.Respawn);
        }
        else if (_lives == 0) //If the player is out of lives, restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void NextLevel(string level)
    {
        //Load next level and play win sound
        SceneManager.LoadScene(level);
        SoundManager.Instance.PlaySound(SoundManager.Sounds.Goal);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    void SpawnNewPlayer()
    {
        Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    public int GetLives()
    {
        return _lives;
    }
}