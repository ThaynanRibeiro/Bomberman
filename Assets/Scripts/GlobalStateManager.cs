using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalStateManager : MonoBehaviour
{
    public List<GameObject> Players = new List<GameObject>();

    private int deadPlayerNum = -1;
    public string mensagem;

    public void PlayerMorreu(int playerNumber)
    {
        deadPlayerNum = playerNumber;
        Invoke("ChecarPlayersMorto", .3f);
        mensagem = ChecarPlayersMorto();
    }

    string ChecarPlayersMorto()
    {
        if (deadPlayerNum == 1)
        {
            Debug.Log("Player 2 Venceu!");
            return mensagem = "Player 2 Venceu!";
        }
        else
        {
            Debug.Log("Player 1 Venceu!");
            return mensagem = "Player 1 Venceu!";
        }
    }
}
