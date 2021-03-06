﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace RPG
{
    public partial class Fokepernyo : Form
    {
        private Jatekos jatekos;
        private Ellenfel ellenfel;
        public Fokepernyo()
        {
            InitializeComponent();
            jatekos = new Jatekos(10,10,20,0,1);
            // a játékos a kezdőhelyre kerül
            Mozog(Vilag.HelyIDAlapjan(Vilag.LOCATION_ID_HOME));
            // adunk neki egy kardot
            jatekos.Taska.Add(new TaskaTargy(Vilag.TargyIDAlapjan(Vilag.ITEM_ID_RUSTY_SWORD),1));

            lblHitPoints.Text = jatekos.AktualisHP.ToString();
            lblArany.Text = jatekos.Arany.ToString();
            lblXP.Text = jatekos.XP.ToString();
            lblSzint.Text = jatekos.Szint.ToString();
        }
        private void btnNorth_Click(object sender, EventArgs e)
        {
            Mozog(jatekos.AktualisHely.HelyEszakra);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            Mozog(jatekos.AktualisHely.HelyDelre);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            Mozog(jatekos.AktualisHely.HelyKeletre);

        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            Mozog(jatekos.AktualisHely.HelyNyugatra);

        }

        private void Mozog(Hely cel)
        {
            //Does the location have any required items
            if (!jatekos.HasRequiredItemToEnterThisLocation(cel))
            {
                rtbMessages.Text += "You must have a " + cel.ItemABelepeshez.Nev; return;
            }

            // Update the player's current location
            jatekos.AktualisHely = cel;

            // Show/hide available movement buttons
            btnNorth.Visible = (cel.HelyEszakra != null);
            btnEast.Visible = (cel.HelyKeletre != null);
            btnSouth.Visible = (cel.HelyDelre != null);
            btnWest.Visible = (cel.HelyNyugatra != null);

            // Display current location name and description
            rtbLocation.Text = cel.Nev + Environment.NewLine;
            rtbLocation.Text += cel.Leiras + Environment.NewLine;

            // Completely heal the player
            jatekos.AktualisHP = jatekos.MaxHP;

            // Update Hit Points in UI
            lblHitPoints.Text = jatekos.AktualisHP.ToString();

            // Does the location have a quest?
            if (cel.KuldetesVanItt != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = jatekos.HasThisQuest(cel.KuldetesVanItt);
                bool playerAlreadyCompletedQuest = jatekos.CompletedThisQuest(cel.KuldetesVanItt);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = jatekos.HasAllQuestCompletionItems(cel.KuldetesVanItt);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + cel.KuldetesVanItt.Nev + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            jatekos.RemoveQuestCompletionItems(cel.KuldetesVanItt);

                            // Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += cel.KuldetesVanItt.ErtekXP.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += cel.KuldetesVanItt.ErtekArany.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += cel.KuldetesVanItt.ErtekItem.Nev + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            jatekos.XP += cel.KuldetesVanItt.ErtekXP;
                            jatekos.Arany += cel.KuldetesVanItt.ErtekArany;

                            // Add the reward item to the player's inventory
                            jatekos.AddItemToInventory(cel.KuldetesVanItt.ErtekItem);

                            // Mark the quest as completed
                            jatekos.MarkQuestCompleted(cel.KuldetesVanItt);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    rtbMessages.Text += "You receive the " + cel.KuldetesVanItt.Nev + " quest." + Environment.NewLine;
                    rtbMessages.Text += cel.KuldetesVanItt.Leiras + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (KuldeteshezTargy qci in cel.KuldetesVanItt.KuldeteshezSzuksegesTargyak)
                    {
                        if (qci.Mennyiseg == 1)
                        {
                            rtbMessages.Text += qci.Mennyiseg.ToString() + " " + qci.Reszletek.Nev + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Mennyiseg.ToString() + " " + qci.Reszletek.Nev + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    // Add the quest to the player's quest list
                    jatekos.Kuldetesek.Add(new JatekosKuldetes(cel.KuldetesVanItt));
                }
            }

            // Does the location have a monster?
            if (cel.EllenfelVanItt != null)
            {
                rtbMessages.Text += "You see a " + cel.EllenfelVanItt.Nev + Environment.NewLine;

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Ellenfel standardMonster = Vilag.EllenfelIDAlapjan(cel.EllenfelVanItt.ID);

                ellenfel = new Ellenfel(standardMonster.ID, standardMonster.Nev, standardMonster.MaxSebzes,
                    standardMonster.ErtekXP, standardMonster.ErtekArany, standardMonster.AktualisHP, standardMonster.MaxHP);

                foreach (ZsakmanyTargy lootItem in standardMonster.MiketDobhat)
                {
                    ellenfel.MiketDobhat.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                ellenfel = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Mennyiseg";

            dgvInventory.Rows.Clear();

            foreach (TaskaTargy TaskaItem in jatekos.Taska)
            {
                if (TaskaItem.Mennyiseg > 0)
                {
                    dgvInventory.Rows.Add(new[] { TaskaItem.Reszletek.Nev, TaskaItem.Mennyiseg.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (JatekosKuldetes playerQuest in jatekos.Kuldetesek)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Reszletek.Nev, playerQuest.TeljesitveE.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Fegyver> weapons = new List<Fegyver>();

            foreach (TaskaTargy TaskaItem in jatekos.Taska)
            {
                if (TaskaItem.Reszletek is Fegyver)
                {
                    if (TaskaItem.Mennyiseg > 0)
                    {
                        weapons.Add((Fegyver)TaskaItem.Reszletek);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Nev";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<Gyogyital> healingPotions = new List<Gyogyital>();

            foreach (TaskaTargy TaskaItem in jatekos.Taska)
            {
                if (TaskaItem.Reszletek is Gyogyital)
                {
                    if (TaskaItem.Mennyiseg > 0)
                    {
                        healingPotions.Add((Gyogyital)TaskaItem.Reszletek);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Nev";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }


        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Fegyver currentWeapon = (Fegyver)cboWeapons.SelectedItem;

            // Determine the amount of damage to do to the monster
            int damageToMonster = VeletlenSzam.NumberBetween(currentWeapon.MinSebzes, currentWeapon.MaxSebzes);

            // Apply the damage to the monster's CurrentHitPoints
            ellenfel.AktualisHP -= damageToMonster;

            // Display message
            rtbMessages.Text += "You hit the " + ellenfel.Nev + " for " + damageToMonster.ToString() + " points." + Environment.NewLine;

            // Check if the monster is dead
            if (ellenfel.AktualisHP <= 0)
            {
                // Monster is dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + ellenfel.Nev + Environment.NewLine;

                // Give player experience points for killing the monster
                jatekos.XP += ellenfel.ErtekXP;
                rtbMessages.Text += "You receive " + ellenfel.ErtekXP.ToString() + " experience points" + Environment.NewLine;

                // Give player gold for killing the monster 
                jatekos.Arany += ellenfel.ErtekArany;
                rtbMessages.Text += "You receive " + ellenfel.ErtekArany.ToString() + " gold" + Environment.NewLine;

                // Get random loot items from the monster
                List<TaskaTargy> lootedItems = new List<TaskaTargy>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (ZsakmanyTargy lootItem in ellenfel.MiketDobhat)
                {
                    if (VeletlenSzam.NumberBetween(1, 100) <= lootItem.SzazalekbanEsik)
                    {
                        lootedItems.Add(new TaskaTargy(lootItem.Reszletek, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (ZsakmanyTargy lootItem in ellenfel.MiketDobhat)
                    {
                        if (lootItem.AlapertelmezettE)
                        {
                            lootedItems.Add(new TaskaTargy(lootItem.Reszletek, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (TaskaTargy TaskaTargy in lootedItems)
                {
                    jatekos.AddItemToInventory(TaskaTargy.Reszletek);

                    if (TaskaTargy.Mennyiseg == 1)
                    {
                        rtbMessages.Text += "You loot " + TaskaTargy.Mennyiseg.ToString() + " " + TaskaTargy.Reszletek.Nev + Environment.NewLine;
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + TaskaTargy.Mennyiseg.ToString() + " " + TaskaTargy.Reszletek.Nev + Environment.NewLine;
                    }
                }

                // Refresh player information and inventory controls
                lblHitPoints.Text = jatekos.AktualisHP.ToString();
                lblArany.Text = jatekos.Arany.ToString();
                lblXP.Text = jatekos.XP.ToString();
                lblSzint.Text = jatekos.Szint.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a blank line to the messages box, just for appearance.
                rtbMessages.Text += Environment.NewLine;

                // Move player to current location (to heal player and create a new monster to fight)
                Mozog(jatekos.AktualisHely);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = VeletlenSzam.NumberBetween(0, ellenfel.MaxSebzes);

                // Display message
                rtbMessages.Text += "The " + ellenfel.Nev + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                // Subtract damage from player
                jatekos.AktualisHP -= damageToPlayer;

                // Refresh player data in UI
                lblHitPoints.Text = jatekos.AktualisHP.ToString();

                if (jatekos.AktualisHP <= 0)
                {
                    // Display message
                    rtbMessages.Text += "The " + ellenfel.Nev + " killed you." + Environment.NewLine;

                    // Move player to "Home"
                    Mozog(Vilag.HelyIDAlapjan(Vilag.LOCATION_ID_HOME));
                }
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            Gyogyital potion = (Gyogyital)cboPotions.SelectedItem;

            // Add healing amount to the player's current hit points
            jatekos.AktualisHP = (jatekos.AktualisHP + potion.MennyitGyogyit);

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (jatekos.AktualisHP > jatekos.MaxHP)
            {
                jatekos.AktualisHP = jatekos.MaxHP;
            }

            // Remove the potion from the player's inventory
            foreach (TaskaTargy ii in jatekos.Taska)
            {
                if (ii.Reszletek.ID == potion.ID)
                {
                    ii.Mennyiseg--;
                    break;
                }
            }

            // Display message
            rtbMessages.Text += "You drink a " + potion.Nev + Environment.NewLine;

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer = VeletlenSzam.NumberBetween(0, ellenfel.MaxSebzes);

            // Display message
            rtbMessages.Text += "The " + ellenfel.Nev + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

            // Subtract damage from player
            jatekos.AktualisHP -= damageToPlayer;

            if (jatekos.AktualisHP <= 0)
            {
                // Display message
                rtbMessages.Text += "The " + ellenfel.Nev + " killed you." + Environment.NewLine;

                // Move player to "Home"
                Mozog(Vilag.HelyIDAlapjan(Vilag.LOCATION_ID_HOME));
            }

            // Refresh player data in UI
            lblHitPoints.Text = jatekos.AktualisHP.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }
    }
}
