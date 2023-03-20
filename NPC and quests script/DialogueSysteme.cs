using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public List<string> dialogueLines = new List<string>();
    public string npcName;
    public GameObject dialoguePanel;

    private Text coutinueButton;
    Text dialogueText, nameText;
    private int dialogueIndex;


    void Awake()
    {
        /*
        coutinueButton = dialoguePanel.transform.Find("Text2").GetComponent<Text>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        */
        coutinueButton = dialoguePanel.transform.Find("continue").GetComponent<Text>();
        dialogueText = dialoguePanel.transform.Find("dialogue").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetComponent<Text>();
        dialoguePanel.SetActive(false);

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
        if (Input.GetButtonDown("E"))
        {
            CountinueDialogue();
        }
    }

    public void AddNewDialogue(string[] lines, string npcNamee)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        npcName = npcNamee;
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void CountinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
