using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugHandsStatus : MonoBehaviour
{
    GManager gManager;
    ItemControler PlayerItemCon;

    Text UiText;
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GManager>();
        PlayerItemCon = GameObject.Find("Player").GetComponent<ItemControler>();

        UiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UiText.text = String.Format("LeftHand:{0}  RightHand:{1}", gManager.ItemID(PlayerItemCon.GetSlot(0).ItemID).Name, gManager.ItemID(PlayerItemCon.GetSlot(1).ItemID).Name);
    }
}
