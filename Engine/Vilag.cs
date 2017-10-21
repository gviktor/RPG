using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Vilag
    {
        public static readonly List<Targy> Targyak = new List<Targy>();
        public static readonly List<Ellenfel> Ellenfelek = new List<Ellenfel>();
        public static readonly List<Kuldetes> Kuldetesek = new List<Kuldetes>();
        public static readonly List<Hely> Helyek = new List<Hely>();
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        static Vilag()
        {
            TargyakLetrehozasa();
            EllenfelekLetrehozasa();
            KuldetesekLetrehozasa();
            HelyekLetrehozasa();
        }

        private static void TargyakLetrehozasa()
        {
            Targyak.Add(new Fegyver(ITEM_ID_RUSTY_SWORD, "Rusty sword", 0, 5));
            Targyak.Add(new Targy(ITEM_ID_RAT_TAIL, "Rat tail"));
            Targyak.Add(new Targy(ITEM_ID_PIECE_OF_FUR, "Piece of fur"));
            Targyak.Add(new Targy(ITEM_ID_SNAKE_FANG, "Snake fang"));
            Targyak.Add(new Targy(ITEM_ID_SNAKESKIN, "Snakeskin"));
            Targyak.Add(new Fegyver(ITEM_ID_CLUB, "Club", 3, 10));
            Targyak.Add(new Gyogyital(ITEM_ID_HEALING_POTION, "Healing potion", 5));
            Targyak.Add(new Targy(ITEM_ID_SPIDER_FANG, "Spider fang"));
            Targyak.Add(new Targy(ITEM_ID_SPIDER_SILK, "Spider silk"));
            Targyak.Add(new Targy(ITEM_ID_ADVENTURER_PASS, "Adventurer pass"));
        }

        private static void EllenfelekLetrehozasa()
        {
            Ellenfel rat = new Ellenfel(MONSTER_ID_RAT, "Rat", 5, 3, 10, 3, 3);
            rat.MiketDobhat.Add(new ZsakmanyTargy(TargyIDAlapjan(ITEM_ID_RAT_TAIL), 75, false));
            rat.MiketDobhat.Add(new ZsakmanyTargy(TargyIDAlapjan(ITEM_ID_PIECE_OF_FUR), 75, true));

            Ellenfel snake = new Ellenfel(MONSTER_ID_SNAKE, "Snake", 5, 3, 10, 3, 3);
            snake.MiketDobhat.Add(new ZsakmanyTargy(TargyIDAlapjan(ITEM_ID_SNAKE_FANG), 75, false));
            snake.MiketDobhat.Add(new ZsakmanyTargy(TargyIDAlapjan(ITEM_ID_SNAKESKIN), 75, true));

            Ellenfel giantSpider = new Ellenfel(MONSTER_ID_GIANT_SPIDER, "Giant spider", 20, 5, 40, 10, 10);
            giantSpider.MiketDobhat.Add(new ZsakmanyTargy(TargyIDAlapjan(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.MiketDobhat.Add(new ZsakmanyTargy(TargyIDAlapjan(ITEM_ID_SPIDER_SILK), 25, false));

            Ellenfelek.Add(rat);
            Ellenfelek.Add(snake);
            Ellenfelek.Add(giantSpider);
        }

        private static void KuldetesekLetrehozasa()
        {
            Kuldetes clearAlchemistGarden =
                new Kuldetes(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.KuldeteshezSzuksegesTargyak.Add(new KuldeteshezTargy(TargyIDAlapjan(ITEM_ID_RAT_TAIL), 3));

            clearAlchemistGarden.ErtekItem = TargyIDAlapjan(ITEM_ID_HEALING_POTION);

            Kuldetes clearFarmersField =
                new Kuldetes(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.KuldeteshezSzuksegesTargyak.Add(new KuldeteshezTargy(TargyIDAlapjan(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.ErtekItem = TargyIDAlapjan(ITEM_ID_ADVENTURER_PASS);

            Kuldetesek.Add(clearAlchemistGarden);
            Kuldetesek.Add(clearFarmersField);
        }

        private static void HelyekLetrehozasa()
        {
            // Create each location
            Hely home = new Hely(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Hely townSquare = new Hely(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");

            Hely alchemistHut = new Hely(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.KuldetesVanItt = KuldetesIDAlapjan(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Hely alchemistsGarden = new Hely(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.EllenfelVanItt = EllenfelIDAlapjan(MONSTER_ID_RAT);

            Hely farmhouse = new Hely(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.KuldetesVanItt = KuldetesIDAlapjan(QUEST_ID_CLEAR_FARMERS_FIELD);

            Hely farmersField = new Hely(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.EllenfelVanItt = EllenfelIDAlapjan(MONSTER_ID_SNAKE);

            Hely guardPost = new Hely(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", TargyIDAlapjan(ITEM_ID_ADVENTURER_PASS));

            Hely bridge = new Hely(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");

            Hely spiderField = new Hely(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.EllenfelVanItt = EllenfelIDAlapjan(MONSTER_ID_GIANT_SPIDER);

            // Link the locations together
            home.HelyEszakra = townSquare;

            townSquare.HelyEszakra = alchemistHut;
            townSquare.HelyDelre = home;
            townSquare.HelyKeletre = guardPost;
            townSquare.HelyNyugatra = farmhouse;

            farmhouse.HelyKeletre = townSquare;
            farmhouse.HelyNyugatra = farmersField;

            farmersField.HelyKeletre = farmhouse;

            alchemistHut.HelyDelre = townSquare;
            alchemistHut.HelyEszakra = alchemistsGarden;

            alchemistsGarden.HelyDelre = alchemistHut;

            guardPost.HelyKeletre = bridge;
            guardPost.HelyNyugatra = townSquare;

            bridge.HelyNyugatra = guardPost;
            bridge.HelyKeletre = spiderField;

            spiderField.HelyNyugatra = bridge;

            // Add the locations to the static list
            Helyek.Add(home);
            Helyek.Add(townSquare);
            Helyek.Add(guardPost);
            Helyek.Add(alchemistHut);
            Helyek.Add(alchemistsGarden);
            Helyek.Add(farmhouse);
            Helyek.Add(farmersField);
            Helyek.Add(bridge);
            Helyek.Add(spiderField);
        }

        public static Targy TargyIDAlapjan(int id)
        {
            foreach (Targy item in Targyak)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Ellenfel EllenfelIDAlapjan(int id)
        {
            foreach (Ellenfel monster in Ellenfelek)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Kuldetes KuldetesIDAlapjan(int id)
        {
            foreach (Kuldetes quest in Kuldetesek)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Hely HelyIDAlapjan(int id)
        {
            foreach (Hely location in Helyek)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}