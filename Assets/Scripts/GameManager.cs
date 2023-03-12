using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI treasureText;
    [SerializeField] public bool gameActive = false;
    [SerializeField] float time = 0;
    [SerializeField] int numTreasures = 0;
    [SerializeField] AudioSource gameAudio;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip treasureSound;

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            time += Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(time);
        }
    }

    public void StartGame()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        timeText.text = "Time: " + Mathf.Round(time);
        treasureText.text = "Treasures: " + numTreasures +"/5";
        gameActive = true;
        titleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameAudio.PlayOneShot(buttonSound, 1.0f);
    }

    public void AddTreasure()
    {
        gameAudio.PlayOneShot(treasureSound, 1.0f);
        numTreasures += 1;
        treasureText.text = "Treasures: " + numTreasures + "/5";
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
