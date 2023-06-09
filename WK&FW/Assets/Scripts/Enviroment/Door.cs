using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Players;

    private Rigidbody2D _rb;
    private float timeToWait = 2f;
    
    private void Start()
    {
        Player.completed = 0;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Verifica si el objeto que ha entrado en contacto es un jugador
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == col.gameObject)
            {
                Debug.Log("Hit with " + col.name);
                Player.completed++;
                Debug.Log(Player.completed);
            }
            if (Player.completed == 2)
            {
                Player.completed = 0;
                Invoke("InvokeScene", timeToWait);
            }
        }
    }

    private void InvokeScene()
    {
        GameManager.Instance.LevelCompletedScreen();
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("bye with " + col.name);
        Player.completed--;
    }

}
