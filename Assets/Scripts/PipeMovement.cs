using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    public static float pipeSpeed;
    public float screenStartX;
    public float screenEndX;



    void Start()
    {
        screenStartX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f)).x - 1.5f;
        screenEndX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f)).x + 0.5f;
    }


    void Update()
    {
        transform.position -= Vector3.right * pipeSpeed * Time.deltaTime;

        if(transform.position.x < screenStartX)
        {
            var heightOffset = Random.Range(-1, 4);
            transform.position = new Vector3(screenEndX, heightOffset);
        }
    }


}
