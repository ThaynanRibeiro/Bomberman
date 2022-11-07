using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public GameObject menu;
    public GameObject next;

    public void Start()
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        next.SetActive(false);
    }

    public void Play()
    {
        player1.Enable();
        player2.Enable();
        menu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
