using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillTreeButtons : MonoBehaviour
{
    GameObject saveManager;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
    }

    public void MaxHealth()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().maxHPUpgrade < 5)
        {
            saveManager.GetComponent<SaveManager>().maxHealth = saveManager.GetComponent<SaveManager>().maxHealth + 10;
            saveManager.GetComponent<SaveManager>().maxHPUpgrade++;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void HealthMinusSpeed()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().maxHPMinusSpeedUpgrade < 5 && saveManager.GetComponent<SaveManager>().maxHPUpgrade > 1)
        {
            saveManager.GetComponent<SaveManager>().maxHealth = saveManager.GetComponent<SaveManager>().maxHealth + 30;
            saveManager.GetComponent<SaveManager>().speed = saveManager.GetComponent<SaveManager>().speed - .5f;
            if (saveManager.GetComponent<SaveManager>().speed < .1f)
            {
                saveManager.GetComponent<SaveManager>().speed = .1f;
            }
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
            saveManager.GetComponent<SaveManager>().maxHPMinusSpeedUpgrade++;
        }
    }
    public void Defense()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().defense < 5 && saveManager.GetComponent<SaveManager>().maxHPUpgrade > 1)
        {
            saveManager.GetComponent<SaveManager>().defense = saveManager.GetComponent<SaveManager>().defense + 1;
            saveManager.GetComponent<SaveManager>().speed = saveManager.GetComponent<SaveManager>().speed - .5f;
            if (saveManager.GetComponent<SaveManager>().speed < .1f)
            {
                saveManager.GetComponent<SaveManager>().speed = .1f;
            }
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void HealthRegen()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().healthRegenUpgrade < 5)
        {
            saveManager.GetComponent<SaveManager>().healthRegen = saveManager.GetComponent<SaveManager>().healthRegen + 10;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
            saveManager.GetComponent<SaveManager>().healthRegenUpgrade++;
        }
    }
    public void RegenMinusHP()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().healthRegenMinusHPUpgrade < 5 && saveManager.GetComponent<SaveManager>().healthRegen > 0)
        {
            saveManager.GetComponent<SaveManager>().healthRegen = saveManager.GetComponent<SaveManager>().healthRegen + 30;
            saveManager.GetComponent<SaveManager>().maxHealth = saveManager.GetComponent<SaveManager>().maxHealth - 10;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
            saveManager.GetComponent<SaveManager>().healthRegenMinusHPUpgrade++;
        }
    }
    public void RegenMinusSpeed()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().healthRegenMinusSpeedUpgrade < 5 && saveManager.GetComponent<SaveManager>().healthRegen > 0)
        {
            saveManager.GetComponent<SaveManager>().healthRegen = saveManager.GetComponent<SaveManager>().healthRegen + 30;
            saveManager.GetComponent<SaveManager>().speed = saveManager.GetComponent<SaveManager>().speed - .5f;
            if (saveManager.GetComponent<SaveManager>().speed < .1f)
            {
                saveManager.GetComponent<SaveManager>().speed = .1f;
            }
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
            saveManager.GetComponent<SaveManager>().healthRegenMinusSpeedUpgrade++;
        }
    }
    public void Damage()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().damage < 10)
        {
            saveManager.GetComponent<SaveManager>().damage = saveManager.GetComponent<SaveManager>().damage + 1;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void CritChance()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().critChance < 60 && saveManager.GetComponent<SaveManager>().damage > 5)
        {
            saveManager.GetComponent<SaveManager>().critChance = saveManager.GetComponent<SaveManager>().critChance + 10;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void CritDamage()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().critDamage < 7 && saveManager.GetComponent<SaveManager>().damage > 5)
        {
            saveManager.GetComponent<SaveManager>().critDamage = saveManager.GetComponent<SaveManager>().critDamage + 1;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void SwingSpeed()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().swingSpeed > 1.35)
        {
            saveManager.GetComponent<SaveManager>().swingSpeed = saveManager.GetComponent<SaveManager>().swingSpeed - .33f;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void SwingSpeedByHealth()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().fullHealthSwing == false && saveManager.GetComponent<SaveManager>().notFullHealthSwing == false && saveManager.GetComponent<SaveManager>().swingSpeed < 3)
        {
            saveManager.GetComponent<SaveManager>().fullHealthSwing = true;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void SwingSpeedByMissingHealth()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().fullHealthSwing == false && saveManager.GetComponent<SaveManager>().notFullHealthSwing == false && saveManager.GetComponent<SaveManager>().swingSpeed < 3)
        {
            saveManager.GetComponent<SaveManager>().notFullHealthSwing = true;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void EnemyTriggerDistance()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().enemyTriggerDistance > 2.5f)
        {
            saveManager.GetComponent<SaveManager>().enemyTriggerDistance = saveManager.GetComponent<SaveManager>().enemyTriggerDistance - .5f;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void StartleDamage()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().startleDamage < 5 && saveManager.GetComponent<SaveManager>().enemyTriggerDistance < 5)
        {
            saveManager.GetComponent<SaveManager>().startleDamage = saveManager.GetComponent<SaveManager>().startleDamage + 1;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void StartleCrit()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().startleCritDamage < 5 && saveManager.GetComponent<SaveManager>().enemyTriggerDistance < 5)
        {
            saveManager.GetComponent<SaveManager>().startleCritDamage = saveManager.GetComponent<SaveManager>().startleDamage + 1;
            saveManager.GetComponent<SaveManager>().startleCritChance = saveManager.GetComponent<SaveManager>().startleCritChance + 10;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void MoveSpeed()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().speedUpgrade < 5)
        {
            saveManager.GetComponent<SaveManager>().speed = saveManager.GetComponent<SaveManager>().speed + .5f;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void MoveSpeedByHealth()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().speedByHealth == false && saveManager.GetComponent<SaveManager>().speedByMissingHealth == false && saveManager.GetComponent<SaveManager>().speed > 3)
        {
            saveManager.GetComponent<SaveManager>().speedByHealth = true;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
    public void MoveSpeedByMissingHealth()
    {
        if (saveManager.GetComponent<SaveManager>().exp >= saveManager.GetComponent<SaveManager>().expNeeded && saveManager.GetComponent<SaveManager>().speedByHealth == false && saveManager.GetComponent<SaveManager>().speedByMissingHealth == false && saveManager.GetComponent<SaveManager>().speed > 3)
        {
            saveManager.GetComponent<SaveManager>().speedByMissingHealth = true;
            saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp - saveManager.GetComponent<SaveManager>().expNeeded;
            saveManager.GetComponent<SaveManager>().expNeeded = Mathf.RoundToInt(saveManager.GetComponent<SaveManager>().expNeeded * 1.1f);
        }
    }
}
