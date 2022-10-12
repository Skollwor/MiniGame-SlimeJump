using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject UI;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject spawner;

    [SerializeField]
    SpriteRenderer backGroundSky;

    [SerializeField]
    SpriteRenderer clouds_Far;

    [SerializeField]
    SpriteRenderer clouds_Close;

    [SerializeField]
    SpriteRenderer clouds_Trees;

    [SerializeField]
    SpriteRenderer hils;


    int lastRecord = 0;


    private void Start()
    {
        lastRecord = player.GetComponent<Controller_Player>().GetCurrentRecord;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastRecord < player.GetComponent<Controller_Player>().GetCurrentRecord)
        {
            lastRecord = player.GetComponent<Controller_Player>().GetCurrentRecord;
            UI.GetComponent<Controller_Ui>().SetRecord(lastRecord);
        }
       
            backGroundSky.GetComponent<Controller_BackGround>().MoveBackGround(player.GetComponent<Controller_Player>().CheckGround);
            clouds_Far.GetComponent<Controller_BackGround>().MoveBackGround(player.GetComponent<Controller_Player>().CheckGround);
            clouds_Close.GetComponent<Controller_BackGround>().MoveBackGround(player.GetComponent<Controller_Player>().CheckGround);
            clouds_Trees.GetComponent<Controller_BackGround>().MoveBackGround(player.GetComponent<Controller_Player>().CheckGround);
       

        spawner.GetComponent<Controller_Spawner>().CanSpawn(player.GetComponent<Controller_Player>().CheckGround);


        UI.GetComponent<Controller_Ui>().FillBar = player.GetComponent<Controller_Player>().FillBarPower;
    }

    void SetRecord()
    {
        UI.GetComponent<Controller_Ui>().SetRecord(1);
    }
}
