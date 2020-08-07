using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTable : Table
{

    [SerializeField]
    private int CountOfСlicks = 4;
    private int Progress = 0;

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
        itemControler.SetMainSlotType(ItemMainSlotType.Static);
        itemControler.SetArgument(0, ItemSlotAtr.In);
        itemControler.SetArgument(1, ItemSlotAtr.Out);
    }


    protected override void Update()
    {
        base.Update();


        if (!itemControler.GetSlot(1).IsEmpty())
        {
            itemControler.SetMainSlot(1);
        }
        else
        {
            itemControler.SetMainSlot(0);
        }
    }


    public override void Interactive(Hands hnd)
    {
        if (!itemControler.GetSlot(0).IsEmpty())
        {
            Progress++;
        }
        else
        {
            Progress = 0;
        }


        if (!gManager.IsCutRecipeExists(itemControler.GetSlot(0).ItemID))
        {
            itemControler.GetSlot(1).SetItem(itemControler.GetSlot(0).ItemID);
            itemControler.GetSlot(0).DestroyItem();
        }

        if(Progress >= CountOfСlicks)
        {
            itemControler.GetSlot(1).SetItem(gManager.CutRecipe(itemControler.GetSlot(0).ItemID));
            itemControler.GetSlot(0).DestroyItem();

        }
    }
}
