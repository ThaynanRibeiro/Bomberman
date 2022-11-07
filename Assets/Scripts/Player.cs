using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.ComponentModel;

public class Player : MonoBehaviour
{
    public GlobalStateManager globalManager;
    public Next next;
    [Range(1, 2)]
    public int playerNumber = 1;
    public float moveSpeed = 5f;
    public bool canDroparBombas = true;
    public bool canMove = true;
    public bool dead = false;

    public GameObject bombPrefab;

    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;

    public Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
        animator = myTransform.Find("PlayerModel").GetComponent<Animator>();
    }

    void Update()
    {
        AtualizarMovimento();
    }

    private void OnEnable()
    {
        if (playerNumber == 1)
        {
            AtualizarMovimentoPlayer1();
        }
        else
        {
            AtualizarMovimentoPlayer2();
        }

    }

    private void AtualizarMovimento()
    {
        animator.SetBool("Walking", false);

        if (!canMove)
        {
            return;
        }

        if (playerNumber == 1)
        {
            AtualizarMovimentoPlayer1();
        }
        else
        {
            AtualizarMovimentoPlayer2();
        }
    }

    private void AtualizarMovimentoPlayer1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDroparBombas && Input.GetKeyDown(KeyCode.Space))
        {
            DroparBomba();
        }
    }

    private void AtualizarMovimentoPlayer2()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDroparBombas && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            DroparBomba();
        }
    }

    private void DroparBomba()
    {
        if (bombPrefab)
        {
            Instantiate(bombPrefab,
                new Vector3(Mathf.RoundToInt(myTransform.position.x), bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)),
                bombPrefab.transform.rotation);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!dead && other.CompareTag("Explosion"))
        {
            Debug.Log("P" + playerNumber + " hit by explosion!");

            dead = true;
            globalManager.PlayerMorreu(playerNumber);
            gameObject.SetActive(false);

            next.gameObject.SetActive(true);
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void PlayerEnable(bool player)
    {
        gameObject.SetActive(player);
    }

    public void PositionInicial()
    {
        transform.position = startPosition;
    }
}
