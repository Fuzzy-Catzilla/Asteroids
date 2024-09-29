using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus = new();

    private int menuOpen = -1;


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
            //Start Menu music
        }
    }

    public void CloseMenu()
    {
        menuOpen = -1;
        foreach (var menu in menus) menu.SetActive(false);
        TogglePause(false);
        //Stop menu music
        //Close menu sound
    }
}
