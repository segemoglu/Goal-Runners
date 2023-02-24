using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject ball;

    public int speed, move;
    public float jump;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-1 * move * Time.deltaTime, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(1 * move * Time.deltaTime, 0, 0);
        //}

        ball.transform.Rotate(500 * Time.deltaTime, 0, 0);

        transform.Translate(0, 0, 1 * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "yellowCard")
        {
            gameManager.GetComponent<GameManager>().yellowCard += 1;
            gameManager.GetComponent<GameManager>().ArrangePoints();
            Destroy(other.gameObject);

        }
        else if (other.tag == "redCard")
        {
            gameManager.GetComponent<GameManager>().shoes -= 1;
            gameManager.GetComponent<GameManager>().ArrangePoints();
            Destroy(other.gameObject);

        }
        else if (other.tag == "shoes")
        {
            gameManager.GetComponent<GameManager>().shoes += 1;
            gameManager.GetComponent<GameManager>().ArrangePoints();
            Destroy(other.gameObject);

        }
        else if (other.tag == "jump")
        {
            //transform.Translate(0, jump * Time.deltaTime, 0);
            rb.AddForce(transform.up * jump);
        }


        else if (other.tag == "Finish")
        {
            gameManager.GetComponent<GameManager>().nextLevel = true;
            gameManager.GetComponent<GameManager>().GameOver();
        }
        else if (other.tag == "lose")
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
