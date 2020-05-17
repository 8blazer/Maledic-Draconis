using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

public class SaveManager : MonoBehaviour
{
    public int damage;
    public int maxHealth;
    public int healthRegen;
    public float speed;
    public int critChance;
    public int critDamage;
    public float swingSpeed;
    public float enemyTriggerDistance;
    public int startleDamage;
    public int startleCritDamage;
    public int startleCritChance;
    public int exp;
    public bool fullHealthSwing;
    public bool notFullHealthSwing;
    public bool speedByHealth;
    public bool speedByMissingHealth;
    // Start is called before the first frame update
    void Start()
    {
        string saveFile = "save.txt";
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
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
            string json = JsonUtility.ToJson(saveVars);
            File.WriteAllText(fullname, json);
        }
        else
        {
            string jsonString = File.ReadLines(fullname).First();
            SaveVars jsonJson = JsonUtility.FromJson<SaveVars>(jsonString);
            damage = jsonJson.Damage;
            maxHealth = jsonJson.MaxHealth;
            healthRegen = jsonJson.HealthRegen;
            speed = jsonJson.Speed;
            critChance = jsonJson.CritChance;
            critDamage = jsonJson.CritDamage;
            swingSpeed = jsonJson.SwingSpeed;
            enemyTriggerDistance = jsonJson.EnemyTriggerDistance;
            startleDamage = jsonJson.StartleDamage;
            startleCritDamage = jsonJson.StartleCritDamage;
            startleCritChance = jsonJson.StartleCritChance;
            exp = jsonJson.EXP;
            fullHealthSwing = jsonJson.FullHealthSwing;
            notFullHealthSwing = jsonJson.NotFullHealthSwing;
            speedByHealth = jsonJson.SpeedByHealth;
            speedByMissingHealth = jsonJson.SpeedByMissingHealth;
        }
        Debug.Log(damage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[Serializable]
public class SaveVars
{
    public int Damage;
    public int MaxHealth;
    public int HealthRegen;
    public float Speed;
    public int CritChance;
    public int CritDamage;
    public float SwingSpeed;
    public float EnemyTriggerDistance;
    public int StartleDamage;
    public int StartleCritDamage;
    public int StartleCritChance;
    public int EXP;
    public bool FullHealthSwing;
    public bool NotFullHealthSwing;
    public bool SpeedByHealth;
    public bool SpeedByMissingHealth;
}
