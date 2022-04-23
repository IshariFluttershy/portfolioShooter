using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    int lives;

    [SerializeField]
    int numberOfEnemies;

    [SerializeField]
    GameObject gameOverGUI;
    [SerializeField]
    GameObject winGUI;

    WavesManager wavesManager;

    // Start is called before the first frame update
    void Start()
    {
        wavesManager = FindObjectOfType<WavesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            gameOverGUI.SetActive(true);
        }
        if (wavesManager.IsDone)
        {
            winGUI.SetActive(true);
        }
    }

    public void PlayerDestroyed()
    {
        lives -= 1;

       //if (lives > 0)
       //    Instantiate(playerPrefab);
    }

    public void EnemyDestroyed()
    {
        numberOfEnemies -= 1;
    }
}
