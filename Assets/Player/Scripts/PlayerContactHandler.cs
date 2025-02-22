using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContactHandler : MonoBehaviour
{

    public Image itemImage;
    public string nextLevel = "Level1";
    public PlayerAudioController audioController;

    bool canWinLevel = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            itemImage.color = new Color(0.98f, 0.945f, 0.765f);
            canWinLevel = true;
            audioController.PlayGetItem();
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWinLevel)
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                Debug.Log("NAO PODE PROSSEGUIR");
            }
        }
    }
}
