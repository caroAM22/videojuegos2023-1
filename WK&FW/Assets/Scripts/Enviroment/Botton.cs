using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton : MonoBehaviour
{

    [SerializeField] private MovePlatform movePlatform;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        movePlatform.setMove(true);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        movePlatform.Move();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        movePlatform.setMove(false);
    }
}
