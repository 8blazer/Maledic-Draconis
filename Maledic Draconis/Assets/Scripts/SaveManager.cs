using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JsonExample
{
    public class SaveManager : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            string saveFile = "save.txt";
            FileInfo fileInfo = new FileInfo(saveFile);
            string fullname = fileInfo.FullName;
            Debug.Log(fullname);
            if (!File.Exists(fullname))
            {
                SaveVars saveVars = new SaveVars
                {
                    Damage = 5,
                    MaxHealth = 100,
                    HealthRegen = 0,
                    Speed = 3,
                    CritChance = 10,
                    CritDamage = 2,
                    SwingSpeed = 3,
                    EnemyTriggerDistance = 5,
                    StartleDamage = 0,
                    StartleCritDamage = 0,
                    StartleCritChance = 0,
                    EXP = 0,
                    FullHealthSwing = false,
                    NotFullHealthSwing = false,
                    SpeedByHealth = false,
                    SpeedByMissingHealth = false,
                };
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    public class SaveVars
    {
        public int Damage { get; set; }
        public int MaxHealth { get; set; }
        public int HealthRegen { get; set; }
        public float Speed { get; set; }
        public int CritChance { get; set; }
        public int CritDamage { get; set; }
        public float SwingSpeed { get; set; }
        public float EnemyTriggerDistance { get; set; }
        public int StartleDamage { get; set; }
        public int StartleCritDamage { get; set; }
        public int StartleCritChance { get; set; }
        public int EXP { get; set; }
        public bool FullHealthSwing { get; set; }
        public bool NotFullHealthSwing { get; set; }
        public bool SpeedByHealth { get; set; }
        public bool SpeedByMissingHealth { get; set; }
    }
}
