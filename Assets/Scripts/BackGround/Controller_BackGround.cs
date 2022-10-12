using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_BackGround : MonoBehaviour
{
    [SerializeField]
    float speed;

    SpriteRenderer spriteRender;

    [SerializeField]
    bool autoMove;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (autoMove)
            GetComponent<SpriteRenderer>().size = new Vector2(spriteRender.size.x + speed * Time.deltaTime, spriteRender.size.y);
    }

    public void MoveBackGround(bool checkGround)
    {
        if (!checkGround)
        {
            GetComponent<SpriteRenderer>().size = new Vector2(spriteRender.size.x + speed * Time.deltaTime, spriteRender.size.y);
        }
    }
}
