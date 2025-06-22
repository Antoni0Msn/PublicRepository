using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public List<AudioSource> StopAudioDie;
    public GameObject CanvaGameOver;
   


    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1f;
        CanvaGameOver.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
       
        GameOver_();
    }

    void GameOver_()
    {
        if (GameObject.Find("Player") == null)
        {
            Time.timeScale = 1f;
            SongsDeath();
            CanvaGameOver.SetActive(true);
           
        }

        else if (GameObject.Find("Player") != null)
        { }
    }



    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    void SongsDeath()
    {
        StopAudioDie[0].Stop();
        StopAudioDie[1].Stop();
        StopAudioDie[2].Stop();
        StopAudioDie[3].Stop();
        
        
    }


}
