using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus = new();

    private AudioSource bgMusic;
    private int menuOpen = -1;
    private float volume;


    private void Awake()
    {
        bgMusic = GetComponent<AudioSource>();
        volume = bgMusic.volume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuOpen != 0)
        {
            SwitchMenu(0);
        }
        else if(Input.GetKeyDown(KeyCode.Escape)) CloseMenu();
    }

    public void TogglePause(bool paused)
    {
        Time.timeScale = paused ? 0f : 1f;
    }

    public void SwitchMenu(int menuNum)
    {
        if (menuOpen != -1)
        {
            menus[menuOpen].SetActive(false);
            menus[menuNum].SetActive(true);
            menuOpen = menuNum;
            //Menu Sound
        }
        else
        {
            menus[menuNum].SetActive(true);
            menuOpen = menuNum;
            TogglePause(true);
            bgMusic.spatialBlend = 0.75f;
            //play menu music
        }
    }

    public void CloseMenu()
    {
        menuOpen = -1;
        foreach (var menu in menus) menu.SetActive(false);
        TogglePause(false);
        bgMusic.spatialBlend = 0f;
        //Stop menu music
        //Close menu sound
    }
}
