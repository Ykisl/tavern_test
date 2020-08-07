using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovControler : MonoBehaviour
{
    private Rigidbody2D rb2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float SpeedX = 0;
        float SpeedY = 0;

        SpeedX = Input.GetAxis("Horizontal") * 5;
        SpeedY = Input.GetAxis("Vertical") * 5;

        rb2.velocity = new Vector2(SpeedX, SpeedY);
    }

    //Этот класс был сделан на скорую руку

}
