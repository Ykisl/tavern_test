using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Table
{

    private ItemControler itemControler;


    protected override void Start()
    {
        base.Start();

        itemControler = GetComponent<ItemControler>();
        ConfigIC();
    }


    void ConfigIC()
    {
        itemControler.SetSize(2);
        itemControler.SetMainSlotType(ItemMainSlotType.Free);
        itemControler.SetArgument(0, ItemSlotAtr.In);
        itemControler.SetArgument(1, ItemSlotAtr.In);
    }


    protected override void Update()
    {
        base.Update();

        itemControler.GetSlot(0).DestroyItem();
        itemControler.GetSlot(1).DestroyItem();
    }


    public override void Interactive(Hands hnd)
    {

    }
}
