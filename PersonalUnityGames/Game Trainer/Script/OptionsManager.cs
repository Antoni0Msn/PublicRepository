using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public GameObject Options_Object;

    public List<AudioSource> AudioSources;

    public Slider audioslider;

    public Dropdown resolution_dropdown;

    public GameObject PlayerOBJ;


    public static OptionsManager Instance { get; private set; }


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioslider.value = 0.50f;
        ApplyOptions();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            PlayerOBJ.GetComponent<PlayerMovement>().enabled = false;
            PlayerOBJ.GetComponent<PlayerAttack>().enabled = false;
            Time.timeScale = 0;
            Options_Object.SetActive(true);
        }
        

    }

    public void ApplyOptions()
    {
        Options_Object.SetActive(false);
        PlayerOBJ.GetComponent<PlayerMovement>().enabled = true;
        PlayerOBJ.GetComponent<PlayerAttack>().enabled = true;
        Time.timeScale = 1;
        changeresolutions();
        foreach (AudioSource audio in AudioSources)
        {
            audio.volume = audioslider.value;
        }






    }

    void changeresolutions()
    {
        if (resolution_dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }

        else if (resolution_dropdown.value == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }

        else if(resolution_dropdown.value == 2)
        {
            Screen.SetResolution(900, 800, true);
        }
    }

    public void QuitGame()
    {

        Application.Quit();

    }


}
