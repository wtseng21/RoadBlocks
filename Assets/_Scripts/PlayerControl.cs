using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public Sprite Collector;
    public Sprite Breaker;
    public Text countText;

    private int count;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Collector;
        count = 0;
        updateText();
    }

    private void updateText()
    {
        countText.text = count.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == Collector)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Breaker;
                return;
            }

            if (gameObject.GetComponent<SpriteRenderer>().sprite == Breaker)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Collector;
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.position += movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == Collector)
            {
                collision.gameObject.SetActive(false);
                count += 1;
                updateText();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Roadblock"))
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == Breaker)
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Gate15"))
        {
            if (count == 15)
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Gate35"))
        {
            if (count == 35)
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Gate64"))
        {
            if (count == 64)
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("Congrats");
        }
    }
}
