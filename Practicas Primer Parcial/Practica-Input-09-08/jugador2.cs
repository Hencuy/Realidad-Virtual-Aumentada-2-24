using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float forceJump = 5.0f;

    private Rigidbody rig;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moverx = 0f;
        float movery = 0f;

        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movery = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movery = -1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moverx = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moverx = 1f;
        }

        Vector3 movimiento = new Vector3(moverx, 0.0f, movery) * moveSpeed * Time.deltaTime;
        Vector3 newPos = rig.position + rig.transform.TransformDirection(movimiento);

        rig.MovePosition(newPos);
    }

    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            rig.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Objeto1"))
        {
            Debug.Log("Jugador 2 Se choco con objeto 1");

        }

        if (collision.gameObject.CompareTag("Objeto2"))
        {
            Debug.Log("Jugador 2 Se ha chocado con objeto 2");

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }
}
