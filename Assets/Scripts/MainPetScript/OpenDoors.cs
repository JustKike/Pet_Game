using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoors : MonoBehaviour
{

    public Text text;
    public Text text2;
    public string levelName;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (inDoor && Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(levelName);
        }
    }


}
