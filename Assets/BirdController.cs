using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class BirdController : MonoBehaviour
{
    public int Score;
    public float BirdSpeed = 12f;
    public float RotateScale;
    public TextMeshPro ScoreText;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = new Vector2(0, BirdSpeed);
        }
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * RotateScale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        var curretScene  = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(curretScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
