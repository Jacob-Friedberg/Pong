using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Paddle paddle;
    public Ball ball;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        //convert pixel cords into game cords (origin 0,0)
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        //convert pixel cords into game cords (origin 0,0)
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));

        Instantiate(ball);
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;

        paddle1.Init(true); //Left Paddle   
        paddle2.Init(false); // right Paddle

    }

}
