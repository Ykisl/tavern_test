using Assets.test_tavern.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : Table
{
    [SerializeField]
    private int TimeInSecondss = 2;
    [SerializeField]
    private int OvercookingTime = 10;

    [SerializeField]
    private int Progress = 0;
    private bool IsCooked;
    private bool IsOverCooked;

    private ItemControler itemControler;

    protected override void Start()
    {
        base.Start();

        itemControler = GetComponent<ItemControler>();
        ConfigIC();
    }


    void ConfigIC()
    {
        itemControler.SetSize(1);
        itemControler.SetMainSlotType(ItemMainSlotType.Static);
        itemControler.SetArgument(0, ItemSlotAtr.In | ItemSlotAtr.Out);
    }


    protected override void Update()
    {
        base.Update();



        if (Progress == TimeInSecondss && !IsCooked && gManager.IsGrillRecipeExists(itemControler.GetSlot(0).ItemID))
        {
            itemControler.GetSlot(0).SetItem(gManager.GrillRecipe(itemControler.GetSlot(0).ItemID));
            IsCooked = true;
        }
        else if (Progress >= (TimeInSecondss + OvercookingTime))
        {
            if (!IsOverCooked)
            {
                itemControler.GetSlot(0).SetItem(11);
                IsOverCooked = true;
            }
        }
    }


    public override void Interactive(Hands hnd)
    {
        if (!itemControler.GetSlot(0).IsEmpty())
        {
            StartCoroutine(GrillCoroutine());
        }
    }

    IEnumerator GrillCoroutine()
    {
        while (!itemControler.GetSlot(0).IsEmpty())
        {
            yield return new WaitForSeconds(1f);
            Progress++;
        }
        Progress = 0;
        IsCooked = false;
        IsOverCooked = false;
    }

}
