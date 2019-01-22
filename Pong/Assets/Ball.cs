using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;


    Vector2 direction;
    float radius;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }


        if(transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            SceneManager.LoadScene("EndGameP1");
            Debug.Log("right player wins");

        }

        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            SceneManager.LoadScene("EndGamep2");
            Debug.Log("leftPlayer wins");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle");
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            //collision logic for right paddle hits
            if (isRight && direction.x > 0)
            {
                direction.x = -direction.x;

            }
            //collision logic for left paddle hits 
            if (!isRight && direction.x < 0)
            {
                direction.x = -direction.x;

            }

        }
    }
}
