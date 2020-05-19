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
    public int damage = 0;
    public int maxHealth;
    public int healthRegen;
    public float speed;
    public int defense;
    public int critChance;
    public int critDamage;
    public float swingSpeed;
    public float enemyTriggerDistance;
    public int startleDamage;
    public int startleCritDamage;
    public int startleCritChance;
    public int exp;
    public int expNeeded;
    public bool fullHealthSwing;
    public bool notFullHealthSwing;
    public bool speedByHealth;
    public bool speedByMissingHealth;

    public int maxHPUpgrade;
    public int maxHPMinusSpeedUpgrade;
    public int healthRegenUpgrade;
    public int healthRegenMinusHPUpgrade;
    public int healthRegenMinusSpeedUpgrade;
    public int speedUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        string saveFile = "save.txt";
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
        if (damage == 0)
        {
            if (!File.Exists(fullname))
            {
                SaveVars saveVars = new SaveVars
                {
                    Damage = 5,
                    MaxHealth = 100,
                    HealthRegen = 0,
                    Speed = 3,
                    Defense = 0,
                    CritChance = 10,
                    CritDamage = 2,
                    SwingSpeed = 3,
                    EnemyTriggerDistance = 5,
                    StartleDamage = 0,
                    StartleCritDamage = 0,
                    StartleCritChance = 0,
                    EXP = 0,
                    EXPNeeded = 10,
                    FullHealthSwing = false,
                    NotFullHealthSwing = false,
                    SpeedByHealth = false,
                    SpeedByMissingHealth = false,

                    MaxHPUpgrade = 0,
                    MaxHPMinusSpeedUpgrade = 0,
                    HealthRegenUpgrade = 0,
                    HealthRegenMinusHPUpgrade = 0,
                    HealthRegenMinusSpeedUpgrade = 0,
                    SpeedUpgrade = 0,
                };
                damage = saveVars.Damage;
                maxHealth = saveVars.MaxHealth;
                healthRegen = saveVars.HealthRegen;
                speed = saveVars.Speed;
                defense = saveVars.Defense;
                critChance = saveVars.CritChance;
                critDamage = saveVars.CritDamage;
                swingSpeed = saveVars.SwingSpeed;
                enemyTriggerDistance = saveVars.EnemyTriggerDistance;
                startleDamage = saveVars.StartleDamage;
                startleCritDamage = saveVars.StartleCritDamage;
                startleCritChance = saveVars.StartleCritChance;
                exp = saveVars.EXP;
                expNeeded = saveVars.EXPNeeded;
                fullHealthSwing = saveVars.FullHealthSwing;
                notFullHealthSwing = saveVars.NotFullHealthSwing;
                speedByHealth = saveVars.SpeedByHealth;
                speedByMissingHealth = saveVars.SpeedByMissingHealth;

                maxHPUpgrade = saveVars.MaxHPUpgrade;
                maxHPMinusSpeedUpgrade = saveVars.MaxHPMinusSpeedUpgrade;
                healthRegenUpgrade = saveVars.HealthRegenUpgrade;
                healthRegenMinusHPUpgrade = saveVars.HealthRegenMinusHPUpgrade;
                healthRegenMinusSpeedUpgrade = saveVars.HealthRegenMinusSpeedUpgrade;
                speedUpgrade = saveVars.SpeedUpgrade;

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
                defense = jsonJson.Defense;
                critChance = jsonJson.CritChance;
                critDamage = jsonJson.CritDamage;
                swingSpeed = jsonJson.SwingSpeed;
                enemyTriggerDistance = jsonJson.EnemyTriggerDistance;
                startleDamage = jsonJson.StartleDamage;
                startleCritDamage = jsonJson.StartleCritDamage;
                startleCritChance = jsonJson.StartleCritChance;
                exp = jsonJson.EXP;
                expNeeded = jsonJson.EXPNeeded;
                fullHealthSwing = jsonJson.FullHealthSwing;
                notFullHealthSwing = jsonJson.NotFullHealthSwing;
                speedByHealth = jsonJson.SpeedByHealth;
                speedByMissingHealth = jsonJson.SpeedByMissingHealth;

                maxHPUpgrade = jsonJson.MaxHPUpgrade;
                maxHPMinusSpeedUpgrade = jsonJson.MaxHPMinusSpeedUpgrade;
                healthRegenUpgrade = jsonJson.HealthRegenUpgrade;
                healthRegenMinusHPUpgrade = jsonJson.HealthRegenMinusHPUpgrade;
                healthRegenMinusSpeedUpgrade = jsonJson.HealthRegenMinusSpeedUpgrade;
                speedUpgrade = jsonJson.SpeedUpgrade;
            }
        }
    }

    public void ToJson()
    {
        SaveVars newSave = new SaveVars
        {
            Damage = damage,
            MaxHealth = maxHealth,
            HealthRegen = healthRegen,
            Speed = speed,
            Defense = defense,
            CritChance = critChance,
            CritDamage = critDamage,
            SwingSpeed = swingSpeed,
            EnemyTriggerDistance = enemyTriggerDistance,
            StartleDamage = startleDamage,
            StartleCritDamage = startleCritDamage,
            StartleCritChance = startleCritChance,
            EXP = exp,
            EXPNeeded = expNeeded,
            FullHealthSwing = fullHealthSwing,
            NotFullHealthSwing = notFullHealthSwing,
            SpeedByHealth = speedByHealth,
            SpeedByMissingHealth = speedByMissingHealth,

            MaxHPUpgrade = maxHPUpgrade,
            MaxHPMinusSpeedUpgrade = maxHPMinusSpeedUpgrade,
            HealthRegenUpgrade = healthRegenUpgrade,
            HealthRegenMinusHPUpgrade = healthRegenMinusHPUpgrade,
            HealthRegenMinusSpeedUpgrade = healthRegenMinusSpeedUpgrade,
            SpeedUpgrade = speedUpgrade,
        };
        string saveFile = "save.txt";
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
        string json = JsonUtility.ToJson(newSave);
        File.Delete(fullname);
        File.WriteAllText(fullname, json);
    }
}

[Serializable]
public class SaveVars
{
    public int Damage;
    public int MaxHealth;
    public int HealthRegen;
    public float Speed;
    public int Defense;
    public int CritChance;
    public int CritDamage;
    public float SwingSpeed;
    public float EnemyTriggerDistance;
    public int StartleDamage;
    public int StartleCritDamage;
    public int StartleCritChance;
    public int EXP;
    public int EXPNeeded;
    public bool FullHealthSwing;
    public bool NotFullHealthSwing;
    public bool SpeedByHealth;
    public bool SpeedByMissingHealth;

    public int MaxHPUpgrade;
    public int MaxHPMinusSpeedUpgrade;
    public int HealthRegenUpgrade;
    public int HealthRegenMinusHPUpgrade;
    public int HealthRegenMinusSpeedUpgrade;
    public int SpeedUpgrade;
}
