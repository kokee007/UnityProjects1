using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _vel;


    private Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabProjectil;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

       
        float mesuraMeitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float mesuraMeitatImaggeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        // minPantalla.x = minPantalla.x + 0.75f;
        // minPantalla.x += 0.75f; // Es sinònim a la línia de dalt


        //GetComponent<SpriteRenderer>(): Este método busca el componente SpriteRenderer adjunto al objeto al que está asignado este script. SpriteRenderer es el componente que maneja la imagen (sprite) de la nave.
        //.sprite.bounds.size.x: Accede al tamaño del sprite (en el eje x), lo cual te da el ancho de la imagen para ajustar correctamente los límites de la pantalla y evitar que la nave salga fuera de los bordes.
        minPantalla.x += mesuraMeitatImatgeX;
        maxPantalla.x -= mesuraMeitatImatgeX;
        minPantalla.y += mesuraMeitatImaggeY;
        maxPantalla.y -= mesuraMeitatImaggeY;

    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();
        DisparaProjectil();
    }


    private void DisparaProjectil()
    {
        if (Input.GetKey("space"))
        {
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }

    }
    private void MovimentNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: "+ direccioIndicadaX + " - Y: " + direccioIndicadaY  );


        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);


        transform.position = novaPos;
    }

}

