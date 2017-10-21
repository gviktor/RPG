using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Jatekos : Leny
    {
        public int Arany { get; set; }
        public int XP { get; set; }
        public int Szint { get; set; }
        public List<TaskaItem> Taska { get; set; }
        public List<JatekosKuldetes> Kuldetesek { get; set; }

        public Hely AktualisHely { get; set; }

        public Jatekos(int aktualisHP, int maxHP, int arany, int xp, int szint) : base(aktualisHP, maxHP)
        {
            Arany = arany;
            XP = xp;
            Szint = szint;
            Taska = new List<TaskaItem>();
            Kuldetesek = new List<JatekosKuldetes>();
        }
        public bool HasRequiredItemToEnterThisLocation(Hely location)
        {
            if (location.ItemABelepeshez == null)
            {
                // There is no required item for this location, so return "true"
                return true;
            }

            // See if the player has the required item in their inventory
            foreach (TaskaItem ii in Taska)
            {
                if (ii.Reszletek.ID == location.ItemABelepeshez.ID)
                {
                    // We found the required item, so return "true"
                    return true;
                }
            }

            // We didn't find the required item in their inventory, so return "false"
            return false;
        }

        public bool HasThisQuest(Kuldetes quest)
        {
            foreach (JatekosKuldetes playerQuest in Kuldetesek)
            {
                if (playerQuest.Reszletek.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Kuldetes quest)
        {
            foreach (JatekosKuldetes playerQuest in Kuldetesek)
            {
                if (playerQuest.Reszletek.ID == quest.ID)
                {
                    return playerQuest.TeljesitveE;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Kuldetes quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (KuldeteshezTargy qci in quest.KuldeteshezSzuksegesTargyak)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (TaskaItem ii in Taska)
                {
                    if (ii.Reszletek.ID == qci.Reszletek.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Mennyiseg < qci.Mennyiseg) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Kuldetes quest)
        {
            foreach (KuldeteshezTargy qci in quest.KuldeteshezSzuksegesTargyak)
            {
                foreach (TaskaItem ii in Taska)
                {
                    if (ii.Reszletek.ID == qci.Reszletek.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Mennyiseg -= qci.Mennyiseg;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (TaskaItem ii in Taska)
            {
                if (ii.Reszletek.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Mennyiseg++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Taska.Add(new TaskaItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Kuldetes quest)
        {
            // Find the quest in the player's quest list
            foreach (JatekosKuldetes pq in Kuldetesek)
            {
                if (pq.Reszletek.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.TeljesitveE = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }
    }
}
