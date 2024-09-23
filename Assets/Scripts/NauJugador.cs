using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _vel;


    private Vector2 minPantalla, maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minPantalla.x = minPantalla.x + 0.75f;
        maxPantalla.x = maxPantalla.x - 0.75f;

        minPantalla.y = minPantalla.y + 0.75f;
        maxPantalla.y = maxPantalla.y - 0.75f;

    }

    // Update is called once per frame
    void Update()
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
