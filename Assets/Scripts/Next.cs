using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Next : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public GameObject next;
    public GameObject menu;
    public GlobalStateManager globalManage;
    public TextMeshProUGUI mensagemVencedor;
    public Vector3 blocksDestroyable;

    public string nomeCena;
    public string cenaMenuPrincipal;

    public void Start()
    {
        player1.PlayerEnable(false);
        player2.PlayerEnable(false);
    }

    private void OnEnable()
    {
        player1.dead = false;
        player2.dead = false;
        mensagemVencedor.text = Mensagem();

        if (mensagemVencedor.text.Contains("1"))
        {
            player2.gameObject.SetActive(true);
        }
        else if (mensagemVencedor.text.Contains("2"))
        {
            player1.gameObject.SetActive(true);
        }
        else
        {
            player1.gameObject.SetActive(true);
            player1.gameObject.SetActive(true);
        }
    }
    public string Mensagem()
    {
        return globalManage.mensagem;
    }

    public void Restart()
    {
        OnEnable();

        player1.PositionInicial();
        player2.PositionInicial();
        player1.Enable();
        player2.Enable();
        next.SetActive(false);
    }
    public void Menu()
    {
        next.SetActive(false);
        menu.SetActive(true);
        player1.PlayerEnable(false);
        player2.PlayerEnable(false);
    }

    public void VoltarMenu()
    {
        try
        {
            menu.SetActive(false);

            SceneManager.LoadScene(nomeCena);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    public void VoltarMenuPrincipal()
    {
        try
        {
            menu.SetActive(false);

            SceneManager.LoadScene(cenaMenuPrincipal);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
    public void ProximaFase()
    {
        try
        {
            menu.SetActive(false);

            SceneManager.LoadScene(nomeCena);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

}
