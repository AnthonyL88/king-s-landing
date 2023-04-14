using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem Instance { get; set; }
    public string QuestLine = "";
    public string QuestTag = "";

    [SerializeField]
    public string npcName;

    public static bool CheckQuest;

    [SerializeField]
    public GameObject QuestPanel;
    
    Text QuestText, QuestTagText;

    public static string changetext = "";


    void Awake()
    {
        /*
        coutinueButton = dialoguePanel.transform.Find("Text2").GetComponent<Text>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        */
        QuestText = QuestPanel.transform.Find("questtext").GetComponent<Text>();
        QuestTagText = QuestPanel.transform.Find("questtagtext").GetComponent<Text>();
        QuestPanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (CheckQuest)
            QuestPanel.SetActive(false);
        QuestText.text = QuestLine + changetext;
    }

    public void AddNewQuest(string line, string questtag, string change)
    {
        QuestLine = line;
        QuestTag = questtag;
        changetext = $"{Goal.CurrentAmount}" + "/" + change;
        CreateQuest();
    }

    public void CreateQuest()
    {
        QuestText.text = QuestLine + changetext;
        QuestTagText.text = QuestTag;
        QuestPanel.SetActive(true);
        Debug.Log("quest created");
    }
}
