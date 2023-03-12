using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.transform.position.x > 5)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.5f, -12.0f);
        }
        else 
        {
            transform.position = new Vector3(5.0f, player.transform.position.y + 3.5f, -12.0f);
        }
    }
}
