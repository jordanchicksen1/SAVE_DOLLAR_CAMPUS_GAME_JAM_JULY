using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Grab : MonoBehaviour
{
    public int Health = 10;
    public GameObject HPBar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
    
        if (collision.gameObject.CompareTag("Player1Ammo"))
        {
            Health--;
            Destroy(collision.gameObject);
            
            HPBar.transform.localScale -= new Vector3(0.1f, 0, 0);

        }

        if (collision.gameObject.CompareTag("BOT"))
        {
            Health -= 2;

            Destroy(collision.gameObject);
            HPBar.transform.localScale -= new Vector3(0.2f, 0, 0);

        }
    }

    public GameObject Death;
    public List<GameObject> DeathList;

    private void Update()
    {
        if (Health == 0)
        {
            foreach (GameObject obj in DeathList)
            {
                obj.SetActive(false);
            }
            Death.SetActive(true);
            StartCoroutine(Deaths());
        }

       // if (Health -- )
    }

    IEnumerator Deaths()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("P1Win");
    }
}
