using System.Collections.Generic;
using System.Linq;

namespace M0r19un.LC_ChatMessages{
    public class Messaging{
        static int lastEnemyCount = 0;
        static HUDManager hudManager;
        static List<string> enemies = new List<string>{
            "Blob",
            "Crawler",
            "MouthDog",
            "SandWorm",
            "Centipede",
            "DressGirl",
            "Flowerman",
            "SpringMan",
            "HoarderBug",
            "SandSpider",
            "ForestGiant",
            "Jester",
            "JesterEnemy",
            "Puffer",
            "PufferEnemy",
            "BaboonHawk",
            "BaboonHawkEnemy",
            "Nutcracker",
            "NutcrackerEnemy",
            "Masked",
            "MaskedPlayerEnemy"
        };
        public static void Init()
        {
            On.HUDManager.Awake += HUDManager_Awake;
            On.RoundManager.Awake += RoundManager_Awake;
            On.RoundManager.Update += RoundManager_Update;
            lastEnemyCount = 0;

            LC_Lib.M0r19unLogger.Log("Messaging inited!");
        }

        private static void RoundManager_Update(On.RoundManager.orig_Update orig, RoundManager self)
        {
            orig(self);
            if (self.SpawnedEnemies.Count != lastEnemyCount)
            {
                lastEnemyCount = self.SpawnedEnemies.Count;
                if (enemies.Contains(self.SpawnedEnemies.Last().enemyType.name))
                {
                    var enemiesCount = self.SpawnedEnemies.Count(enemy => enemies.Contains(enemy.enemyType.name));
                    hudManager.AddTextToChatOnServer($"Spawned enemy! Current count:{enemiesCount}.");
                }
            }
        }

        private static void RoundManager_Awake(On.RoundManager.orig_Awake orig, RoundManager self)
        {
            M0r19un.LC_Lib.M0r19unLogger.Log("RoundManager_Awake");
            orig(self);
        }

        private static void HUDManager_Awake(On.HUDManager.orig_Awake orig, HUDManager self)
        {
            M0r19un.LC_Lib.M0r19unLogger.Log("HUDManager_Awake");
            orig(self);
            hudManager = self;
        }
    }
}