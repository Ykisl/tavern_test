using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Supply : Table
{
    [SerializeField]
    private int ItemId = 0;

    private ItemControler itemControler;

    protected override void Start()
    {
        base.Start();

        itemControler = GetComponent<ItemControler>();
        Item item = gManager.ItemID(ItemId);
        Name = item.Name;

        ConfigIC();
        itemControler.GetSlot(0).SetItem(ItemId);
    }


    void ConfigIC()
    {
        itemControler.SetSize(1);
        itemControler.SetMainSlotType(ItemMainSlotType.Static);
        itemControler.SetArgument(0, ItemSlotAtr.Out | ItemSlotAtr.Infinite);
    }


    protected override void Update()
    {
        base.Update();
    }



    public override void Interactive(Hands hnd)
    {

    }
}

