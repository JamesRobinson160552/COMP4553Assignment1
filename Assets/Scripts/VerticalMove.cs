using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float startPosY;

    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.position.y > (startPosY + range) || transform.position.y < (startPosY - range))
        {
            speed = (-speed);
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
