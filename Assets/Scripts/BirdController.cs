using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class BirdController : MonoBehaviour
{
    public int Score;
    public TextMeshPro GameOverScore;
    public float BirdSpeed = 12f;
    public float GameSpeed;
    public float RotateScale;
    public TextMeshPro ScoreText;
    public GameObject endScreen;
    public RuntimeAnimatorController Skin1;
    public RuntimeAnimatorController Skin2;
    public RuntimeAnimatorController Skin3;
    public Sprite BackgroundSprite1;
    public Sprite BackgroundSprite2;
    public GameObject Background;
    Rigidbody2D rb;

    private void Start()
    {
        int currentSkin = Random.Range(1, 4);
        switch (currentSkin)
        {
            case 1:
                GetComponent<Animator>().runtimeAnimatorController = Skin1;
                break;
            case 2:
                GetComponent<Animator>().runtimeAnimatorController = Skin2;
                break;
            case 3:
                GetComponent<Animator>().runtimeAnimatorController = Skin3;
                break;
        }

        int currentBackgroun = Random.Range(1, 3);
        switch (currentBackgroun)
        {
            case 1:
                Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite1;
                break;
            case 2:
                Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite2;
                break;
        }


        PipeMovement.pipeSpeed = GameSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isDead)
        {
            rb.velocity = new Vector2(0, BirdSpeed);
        }
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * RotateScale);
    }

    bool isDead = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        Die();
    }

    public void Die()
    {
        PipeMovement.pipeSpeed = 0;
        Invoke("ShowMenu", 1f);
    }

    void ShowMenu()
    {
        GameOverScore.text = Score.ToString();
        endScreen.SetActive(true);
        ScoreText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
