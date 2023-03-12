using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float startPosX;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x > (startPosX + range) || transform.position.x < (startPosX - range))
        {
            speed = (-speed);
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
