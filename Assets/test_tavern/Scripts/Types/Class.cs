using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.test_tavern.Scripts.Types
{

    public class Item
    {
      public string Name { get; set; }

      public Item(string name)
      {
          Name = name;
      }
    }

    public class ItemSlot
    {
        public int ItemID { get; set; }

        public ItemSlotAtr Atr { get; set; }

        public ItemSlot(int id = 0, ItemSlotAtr atr = ItemSlotAtr.Out | ItemSlotAtr.In)
        {
            ItemID = id;
            Atr = atr;
        }

        bool GrabtItem(out int id)
        {
            if ((Atr & ItemSlotAtr.Lock) != ItemSlotAtr.Lock)
            {
                if ((Atr & ItemSlotAtr.Out) == ItemSlotAtr.Out)
                {
                    id = ItemID;

                    if ((Atr & ItemSlotAtr.Infinite) != ItemSlotAtr.Infinite)
                    {
                        DestroyItem();
                    }

                    return true;
                }
            }

            id = 0;
            return false;
        }

        bool PlaceItem(int id)
        {
            if ((Atr & ItemSlotAtr.Lock) != ItemSlotAtr.Lock)
            {
                if(IsEmpty() && (Atr & ItemSlotAtr.In) == ItemSlotAtr.In)
                {
                    SetItem(id);
                    return true;
                }
            }

            return false;
        }


        public void SendItem(ItemSlot tarSlot)
        {
            int SendItem;

            if (GrabtItem(out SendItem))
            {
                if (!tarSlot.PlaceItem(SendItem))
                {
                    PlaceItem(SendItem);
                }
            }
        }


        public void RequestItem(ItemSlot tarSlot)
        {
            int SendItem;

            if (tarSlot.GrabtItem(out SendItem))
            {
                if (!PlaceItem(SendItem))
                {
                    tarSlot.PlaceItem(SendItem);
                }
            }
        }


        public void GrabOrPlaceItem(ItemSlot tarSlot)
        {
            if (ItemID == 0)
            {
                RequestItem(tarSlot);
            }
            else
            {
                SendItem(tarSlot);
            }
        }


        public void SetItem(int id)
        {
            if ((Atr & ItemSlotAtr.Lock) != ItemSlotAtr.Lock)
            {
                ItemID = id;
            }
        }

        public void DestroyItem()
        {
            if ((Atr & ItemSlotAtr.Lock) != ItemSlotAtr.Lock)
            {
                ItemID = 0;
            }
        }

        public bool IsEmpty()
        {
            return ItemID == 0;
        }

    }



}
