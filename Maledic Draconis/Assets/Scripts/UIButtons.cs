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
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
        if (this.gameObject.name == "Continue" && File.Exists(fullname))
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else if (this.gameObject.name == "Continue")
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
    
    public void StartButton()
    {
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
        saveManager.GetComponent<SaveManager>().ToJson();
        SceneManager.LoadScene("Title");
    }
    public void SkillTree()
    {
        SceneManager.LoadScene("SkillTree");
    }
}
