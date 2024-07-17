using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Grab : MonoBehaviour
{
    public int Health = 10;
    public GameObject HPBar;

    public Renderer DamageIndicater1;
    public Renderer DamageIndicater2;
    public Renderer DamageIndicater3;
    public Renderer DamageIndicater4;

    public float destroyDelay = 1.0f;
    SpriteRenderer sr;
    public GameObject explosion;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    IEnumerator Damager()
    {
        yield return new WaitForSeconds(0);
        DamageIndicater1.material.color = Color.red;
        DamageIndicater2.material.color = Color.red;
        DamageIndicater3.material.color = Color.red;
        DamageIndicater4.material.color = Color.red;

        yield return new WaitForSeconds(0.5f);
        DamageIndicater1.material.color = Color.white;
        DamageIndicater2.material.color = Color.white;
        DamageIndicater3.material.color = Color.white;
        DamageIndicater4.material.color = Color.white;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player2Ammo"))
        {
            Health--;
            Destroy(collision.gameObject);
            HPBar.transform.localScale -= new Vector3(0.1f, 0, 0);
            StartCoroutine(Damager());


        }

        if (collision.gameObject.CompareTag("BOT"))
        {
            Health -= 2;
            Destroy(collision.gameObject, destroyDelay);
            explosion.SetActive(true);
            HPBar.transform.localScale -= new Vector3(0.2f, 0, 0);
            StartCoroutine(Damager());
            sr.sprite = null;

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
    }
    IEnumerator Deaths()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("P2Win");
    }

}
