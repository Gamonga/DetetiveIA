﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movimento : MonoBehaviour
{    
    public Rigidbody2D rb;
    public Animator animator;
    public float limitadorVelocidade = 10;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        if(MainMenu.NewGame == false){        
            LoadPlayer();
        }
    }
    int Animation(int contador)
    {
        contador = contador + 1;
        if (contador <=1999)
        {
            animator.SetBool("Pegando_Caderno", false);
        }
        /*Esquerda e Baixo*/
        if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-5.0f,-5.0f);
            animator.SetBool("Esquerda", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f,0.0f);
            animator.SetBool("Esquerda", false);
        }
        /*Direita e Cima*/
        if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.velocity = new Vector2(5.0f,-5.0f);
            animator.SetBool("Direita", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f,0.0f);
            animator.SetBool("Direita", false);
        }
        /*Direita e Cima*/
        if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.velocity = new Vector2(5.0f,5.0f);
            animator.SetBool("Direita", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f,0.0f);
            animator.SetBool("Direita", false);
        }
        /*Esquerda e Baixo*/
        if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-5.0f,5.0f);
            animator.SetBool("Esquerda", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f,0.0f);
            animator.SetBool("Esquerda", false);
        }
        /*Direita*/
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.velocity = new Vector2(5.0f,0.0f);
            animator.SetBool("Direita", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector2(0.0f,0.0f);
            animator.SetBool("Direita", false);
        }
        /*Esquerda*/
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-5.0f,0.0f);
            animator.SetBool("Esquerda", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector2(0.0f,0.0f);
            animator.SetBool("Esquerda", false);
        }
        /*Cima*/
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            rb.velocity = new Vector2(0.0f,5.0f);
            animator.SetBool("Sobe", true);
            return 0;
        }
        else
        {
            rb.velocity = rb.velocity - new Vector2(0.0f,0.0f);
            animator.SetBool("Sobe", false);
        }
        /*Baixo*/
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            rb.velocity = new Vector2(0.0f,-5.0f);
            animator.SetBool("Desce", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f,0.0f);
            animator.SetBool("Desce", false);
        }        
        if (contador >= 1000)
        {
            animator.SetBool("Pegando_Caderno",true);
        }
        return contador;
    }


    // Update is called once per frame
    void FixedUpdate ()
    {
        contador = Animation(contador);
    }

    public void LoadPlayer(){

        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;        
    }
    
}
