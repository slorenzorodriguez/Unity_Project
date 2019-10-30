using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Script general del player


    public Rigidbody rigidbody;
    private int count;
    private int count2;
    private int count3;
    private int count4;
    public float speed;
    public Text countText;
    public Text winText;
    public GameObject Door;
    public GameObject column;
    public GameObject button;




    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }


    void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        //en la colision de la bola con un trigger:


        //busco el objeto con la etiqueta dada, al encontrarla hará:
        if (other.gameObject.CompareTag("Pick Up Door"))
        {
            //hago que el objeto desaparezca estableciendo 'setactive' como false. Cada uno de los triggers los acumulará y contará.
            //hago lo mismo en los 3 if.
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText(); //llamo al método.
        }

        
        if (other.gameObject.CompareTag("Pick Up 2"))
        {
            other.gameObject.SetActive(false);
            count2 = count2 + 1;
            showColumn(); //llamo al método
        }
        if (other.gameObject.CompareTag("WinningPickUp"))
        {
            other.gameObject.SetActive(false);
            count4 = count4 + 1;
            setWinText(); //llamo al método.
        }

    }

    void setCountText()
    {

        //si la cuenta de los triggers colisionados igual a 9; el objeto el objeto Door modificará su posición en su eje x con el vector3
        if (count == 9)
        {
            Door.transform.position += new Vector3(0, 4, 0);


            //countText.text = "Count: " + count.ToString();
            //Door.gameObject.SetActive(false);
            //winText.text = "¡YOU WIN!";
        }
    }
    void setWinText()
    {

        //si la cuenta del trigger es mayor o igual a X, aparece en pantalla el texto.
        if (count4 == 1)
        {
            winText.text = "¡YOU WIN!";
        }
    }

    void showColumn()
    {

        // Si la cuenta del trigger es mayor o igual a 9; los objetos 'button' y 'columna' cambian a true, se mostrarán visibles en la escena.
        if (count2 >= 9)
            button.gameObject.SetActive(true);
            column.gameObject.SetActive(true);

        {

        }
    }
}

