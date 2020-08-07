using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Table : MonoBehaviour
{
    [System.NonSerialized]
    public GManager gManager;

    private PlayerDatControler playerDat;

    public string Name = "Table";

    protected virtual void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GManager>();
    }

    protected virtual void Update()
    {
        if(playerDat != null)
        {
            if (playerDat.HandsStatus != 0)
            {
                Interactive(playerDat.HandsStatus);
            }
        }
    }
    public abstract void Interactive(Hands hnd);


    void OnCollisionStay2D(Collision2D col)
    {
        playerDat = col.gameObject.GetComponent<PlayerDatControler>();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        playerDat = null;
    }

}
