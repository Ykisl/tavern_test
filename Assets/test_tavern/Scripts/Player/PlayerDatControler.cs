using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatControler : MonoBehaviour
{

    private ItemControler itemControler;
    private ItemControler TableitemControler;

    public Hands HandsStatus;


    ItemSlot LeftHand;
    ItemSlot RightHand;

    void Start()
    {
        itemControler = GetComponent<ItemControler>();

        LeftHand = itemControler.GetSlot(0);
        RightHand = itemControler.GetSlot(1);

    }


    void Update()
    {
        Hands hands = new Hands();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hands |= Hands.Left;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            hands |= Hands.Right;
        }

        HandsStatus = hands;

        if(TableitemControler != null)
        {
            if((hands & Hands.Left) == Hands.Left)
            {
                LeftHand.GrabOrPlaceItem(TableitemControler.GetMainSlot());
            }
            if ((hands & Hands.Right) == Hands.Right)
            {
                RightHand.GrabOrPlaceItem(TableitemControler.GetMainSlot());
            }
        }

    }


    void OnCollisionStay2D(Collision2D col)
    {
        TableitemControler = col.gameObject.GetComponent<ItemControler>();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        TableitemControler = null;
    }
}
