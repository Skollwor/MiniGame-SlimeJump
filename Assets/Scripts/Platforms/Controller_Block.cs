using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controller_Block : MonoBehaviour
{
    [SerializeField]
    float speed;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player != null && !player.GetComponent<Controller_Player>().CheckGround)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        if (gameObject != null && transform.position.x < Camera.main.transform.position.x - 10)
        {
            Debug.Log("Invisible");
            Destroy(gameObject);
        }
    }
}
