using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIButtons : MonoBehaviour
{
    string saveFile = "save.txt";
    GameObject saveManager;
    public Text exp;
    FileInfo fileInfo;
    string fullname;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
        fileInfo = new FileInfo(saveFile);
        fullname = fileInfo.FullName;
        if (this.gameObject.name == "Continue" && File.Exists(fullname))
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else if (this.gameObject.name == "Continue")
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    void Update()
    {
        if (this.gameObject.name == "MainMenu" && SceneManager.GetActiveScene().name == "SkillTree")
        {
            exp.text = saveManager.GetComponent<SaveManager>().exp + "/" + saveManager.GetComponent<SaveManager>().expNeeded;
        }
    }

    public void StartButton()
    {
        saveManager = GameObject.Find("GameMaster");
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
        if (this.gameObject.name == "NewGame" && File.Exists(fullname))
        {
            File.Delete(fullname);
        }
        if (SceneManager.GetActiveScene().name == "SkillTree")
        {
            saveManager.GetComponent<SaveManager>().ToJson();
        }
        SceneManager.LoadScene("TopDown");
    }

    public void MainMenu()
    {
        saveManager = GameObject.Find("GameMaster");
        saveManager.GetComponent<SaveManager>().ToJson();
        SceneManager.LoadScene("Title");
    }
    public void SkillTree()
    {
        SceneManager.LoadScene("SkillTree");
    }
}
