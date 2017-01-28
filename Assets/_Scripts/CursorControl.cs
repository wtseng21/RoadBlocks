using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorControl : MonoBehaviour {

    public Sprite C;
    public Sprite B;

    private Vector3 moveDown = new Vector3(-1.3f, -1.4f, 0.0f);
    private Vector3 moveUp = new Vector3(-1.3f, -0.4f, 0.0f);

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = C;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = B;
            transform.position = moveDown;
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = B;
            transform.position = moveDown;
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = C;
            transform.position = moveUp;
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = C;
            transform.position = moveUp;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (transform.position == moveUp)
            {
                SceneManager.LoadScene("GameMap");
                return;
            }
            if (transform.position == moveDown)
            {
                Application.Quit();
            }
        }
    }
}
