using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : Table
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
        itemControler.SetSize(4);
        itemControler.SetMainSlot(0);
        itemControler.SetMainSlotType(ItemMainSlotType.Static);
        itemControler.SetArgument(3, ItemSlotAtr.Out);
    }


    protected override void Update()
    {
        base.Update();

        if (!itemControler.GetSlot(3).IsEmpty())
        {
            itemControler.SetMainSlot(3);
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (itemControler.GetSlot(i).IsEmpty())
                {
                    itemControler.SetMainSlot(i);
                    break;
                }
            }
        }

    }


    public override void Interactive(Hands hnd)
    {


        if (!itemControler.GetSlot(2).IsEmpty())
        {
            if(gManager.IsCraftRRecipeExists(itemControler.GetSlot(0).ItemID, itemControler.GetSlot(1).ItemID, itemControler.GetSlot(2).ItemID))
            {
                int targetItem = gManager.CraftRecipe(itemControler.GetSlot(0).ItemID, itemControler.GetSlot(1).ItemID, itemControler.GetSlot(2).ItemID);
                itemControler.GetSlot(3).SetItem(targetItem);

                for (int i = 0; i < 3; i++)
                {
                    itemControler.GetSlot(i).DestroyItem();
                }
            }
            else
            {
                itemControler.GetSlot(3).SetItem(12);

                for (int i = 0; i < 3; i++)
                {
                    itemControler.GetSlot(i).DestroyItem();
                }
            }
        }
    }
}
