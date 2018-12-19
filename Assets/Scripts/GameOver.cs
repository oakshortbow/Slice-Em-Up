using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private PlayerHealthController playerHealth;
    public GameObject gameOverMenuUI;
    private Transform player;

    // Update is called once per frame


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    void Update()
    {
        if (!player.gameObject.activeInHierarchy)
        {
            gameOverMenuUI.SetActive(true);
        }
    }


    public void Restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

}
