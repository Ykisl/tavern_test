using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.test_tavern.Scripts.Types;

public class ItemControler : MonoBehaviour
{
    [SerializeField]
    private int SlotsCount = 1;

    [SerializeField]
    private int MainSlot = 0;

    private ItemSlot[] ist;

    [SerializeField]
    private ItemMainSlotType mainSlotType;


    void Awake()
    {
        SetSize(SlotsCount);
    }


    public void SetSize(int size)
    {
        ist = new ItemSlot[size];
        for (int i = 0; i < size; i++)
        {
            ist[i] = new ItemSlot();
        }
        SlotsCount = size;
    }

    public ItemSlot GetSlot(int index)
    {
        return ist[index];
    }


    public ItemSlot[] GetSlots()
    {
        return ist;
    }


    public void SetArgument(int index, ItemSlotAtr atr)
    {
        ist[index].Atr = atr;
    }

    public void SetMainSlot(int index)
    {
        MainSlot = index;
    }

    public ItemSlot GetMainSlot()
    {
        switch (mainSlotType)
        {
            case ItemMainSlotType.Static:
                return ist[MainSlot];
            case ItemMainSlotType.Free:
                foreach (ItemSlot slot in ist)
                {
                    if (slot.IsEmpty())
                    {
                        return slot;
                    }
                }
                break;
            case ItemMainSlotType.StaticOrFree:
                if (ist[MainSlot].IsEmpty())
                {
                    return ist[MainSlot];
                }

                foreach (ItemSlot slot in ist)
                {
                    if (slot.IsEmpty())
                    {
                        return slot;
                    }
                }
                break;
        }

        return ist[MainSlot]; //Возврат Main Слота если нет свободного
    }

    public void SetMainSlotType(ItemMainSlotType slotType)
    {
        mainSlotType = slotType;
    }

}

