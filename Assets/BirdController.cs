using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BirdController : MonoBehaviour
{
    public float BirdSpeed = 12f;
    public float RotateScale;

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
}
