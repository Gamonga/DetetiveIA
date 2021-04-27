using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class movimento : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rbParceiroDetetive;
    public Animator animator;
    public static bool ParaPersonagem;
    public float limitadorVelocidade = 10;
    public static bool comecaDialogoFinal;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        comecaDialogoFinal = false;
        ParaPersonagem = false;
        contador = 0;
        if (MainMenu.NewGame == false)
        {
            LoadPlayer();
        }
    }
    int Animation(int contador)
    {
        contador = contador + 1;
        if (contador <= 1999)
        {
            animator.SetBool("Pegando_Caderno", false);
        }
        /*Esquerda e Baixo*/
        if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-15.0f, -15.0f);
            animator.SetBool("Esquerda", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f);
            animator.SetBool("Esquerda", false);
        }
        /*Direita e Cima*/
        if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.velocity = new Vector2(15.0f, -15.0f);
            animator.SetBool("Direita", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f);
            animator.SetBool("Direita", false);
        }
        /*Direita e Cima*/
        if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.velocity = new Vector2(15.0f, 15.0f);
            animator.SetBool("Direita", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f);
            animator.SetBool("Direita", false);
        }
        /*Esquerda e Baixo*/
        if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-15.0f, 15.0f);
            animator.SetBool("Esquerda", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f);
            animator.SetBool("Esquerda", false);
        }
        /*Direita*/
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.velocity = new Vector2(15.0f, 0.0f);
            animator.SetBool("Direita", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            animator.SetBool("Direita", false);
        }
        /*Esquerda*/
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-15.0f, 0.0f);
            animator.SetBool("Esquerda", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            animator.SetBool("Esquerda", false);
        }
        /*Cima*/
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            rb.velocity = new Vector2(0.0f, 15.0f);
            animator.SetBool("Sobe", true);
            return 0;
        }
        else
        {
            rb.velocity = rb.velocity - new Vector2(0.0f, 0.0f);
            animator.SetBool("Sobe", false);
        }
        /*Baixo*/
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            rb.velocity = new Vector2(0.0f, -15.0f);
            animator.SetBool("Desce", true);
            return 0;
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f);
            animator.SetBool("Desce", false);
        }
        if (contador >= 1000)
        {
            animator.SetBool("Pegando_Caderno", true);
        }
        return contador;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ParaPersonagem)
        {
            contador = Animation(contador);
        }
        if (Relatorio.jogoFinalizado)
        {
            if (rb.position.y <= -20.14f)
            {
                if (rb.position.x >= 16.0f)
                {
                    rb.velocity = new Vector2(0.0f, 0.0f);
                    animator.SetBool("Direita", false);
                    comecaDialogoFinal = true;
                    Relatorio.jogoFinalizado= false;
                }
                else
                {
                    rb.velocity = new Vector2(5f, 0.0f);
                    animator.SetBool("Direita", true);
                }
            }
            else
            {
                Vector3 position;
                position.x = 4.84f;
                position.y = -29.14f;
                position.z = -50f;
                rb.position = position;
                Vector3 position2;
                rbParceiroDetetive.bodyType = RigidbodyType2D.Dynamic;
                rbParceiroDetetive.gravityScale = 0.0f;
                position2.x = 20.39f;
                position2.y = -29.14f;
                position2.z = -50f;
                rbParceiroDetetive.position = position2;
            }
        }
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                position.x = 4.68f;
                position.y = -27.87f;
                position.z = -20f;
                break;
            case 2:
                position.x = -0.7f;
                position.y = -18.9f;
                position.z = -20f;
                break;
            case 3:
                position.x = 13.11f;
                position.y = -19.07f;
                position.z = -20f;
                break;
        }
        rb.position = position;

    }

}
