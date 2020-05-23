using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillTreeButtonText : MonoBehaviour
{
    public Text text;
    GameObject saveManager;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameObject.name)
        {
            case "MoreHP":
                text.text = saveManager.GetComponent<SaveManager>().maxHPUpgrade.ToString() + "/5";
                break;
            case "Damage":
                text.text = (saveManager.GetComponent<SaveManager>().damage - 5).ToString() + "/5";
                break;
            case "HealthRegen":
                text.text = saveManager.GetComponent<SaveManager>().healthRegenUpgrade.ToString() + "/5";
                break;
            case "Defense":
                text.text = saveManager.GetComponent<SaveManager>().defense.ToString() + "/5";
                break;
            case "RegenMinusHealth":
                text.text = saveManager.GetComponent<SaveManager>().healthRegenMinusHPUpgrade.ToString() + "/5";
                break;
            case "RegenMinusSpeed":
                text.text = saveManager.GetComponent<SaveManager>().healthRegenMinusSpeedUpgrade.ToString() + "/5";
                break;
            case "HealthMinusSpeed":
                text.text = saveManager.GetComponent<SaveManager>().maxHPMinusSpeedUpgrade.ToString() + "/5";
                break;
            case "CritChance":
                text.text = ((saveManager.GetComponent<SaveManager>().critChance - 10) / 10).ToString() + "/5";
                break;
            case "CritDamage":
                text.text = (saveManager.GetComponent<SaveManager>().critDamage - 2).ToString() + "/5";
                break;
            case "SwingSpeed":
                text.text = Mathf.RoundToInt(((2f - saveManager.GetComponent<SaveManager>().swingSpeed) / .33f)) + "/5";
                break;
            case "EnemyTriggerDistance":
                text.text = ((5 - saveManager.GetComponent<SaveManager>().enemyTriggerDistance) / .5).ToString() + "/5";
                break;
            case "StartleDamage":
                text.text = saveManager.GetComponent<SaveManager>().startleDamage.ToString() + "/5";
                break;
            case "StartleCrit":
                text.text = saveManager.GetComponent<SaveManager>().startleCritDamage.ToString() + "/5";
                break;
            case "MoveSpeed":
                text.text = saveManager.GetComponent<SaveManager>().speedUpgrade.ToString() + "/5";
                break;
            case "SwingSpeedByHealth":
                if (saveManager.GetComponent<SaveManager>().fullHealthSwing)
                {
                    text.text = "1/1";
                }
                else
                {
                    text.text = "0/1";
                }
                break;
            case "SwingSpeedByMissingHealth":
                if (saveManager.GetComponent<SaveManager>().notFullHealthSwing)
                {
                    text.text = "1/1";
                }
                else
                {
                    text.text = "0/1";
                }
                break;
            case "MoveSpeedByHealth":
                if (saveManager.GetComponent<SaveManager>().speedByHealth)
                {
                    text.text = "1/1";
                }
                else
                {
                    text.text = "0/1";
                }
                break;
            case "MoveSpeedByMissingHealth":
                if (saveManager.GetComponent<SaveManager>().speedByMissingHealth)
                {
                    text.text = "1/1";
                }
                else
                {
                    text.text = "0/1";
                }
                break;
        }
    }
}
