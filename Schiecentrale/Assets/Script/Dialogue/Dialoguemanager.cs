using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class Dialoguemanager : MonoBehaviour
{
    private static Dialoguemanager instance;
    [SerializeField] private float typingspeed = 0.04f;
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TextMeshProUGUI dialoguetext;
    [SerializeField] private TextMeshProUGUI dialoguenametext;
    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;
    [SerializeField] private Chatlog Chatlog;
    private int NPCid;

    private bool dialogueisplaying;

    private Story currentStory;

    private Coroutine displayLineCoroutine;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicestext;
    private string currentchat;

    private GameObject triggerobject;

    [SerializeField] Inventory Inventory;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("meer dan 1 dialogue manager");
        }
        instance = this;
    }

    private void Start()
    {
        dialogueisplaying = false;
        dialoguepanel.SetActive(false);

        layoutAnimator = dialoguepanel.GetComponent<Animator>();

        choicestext = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (var choice in choices)
        {
            choicestext[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueisplaying)
        {
            return;
        }
        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public static Dialoguemanager Getinstance()
    {
        return instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON, int nieuweNPCid, GameObject newtriggerobject)
    {
        triggerobject = newtriggerobject;
        Inventory.canopen = false;
        NPCid = nieuweNPCid;
        currentchat = "";
        currentStory = new Story(inkJSON.text);
        dialogueisplaying = true;
        dialoguepanel.SetActive(true);

        dialoguenametext.text = "???";
        portraitAnimator.Play("default");
        layoutAnimator.Play("right");

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        Chatlog.allemenseninfo[NPCid].inkJSON.Add(currentchat);
        Chatlog.Updateinfo(NPCid);
        Inventory.canopen = true;
        if(triggerobject != null)
        {
            triggerobject.SetActive(true);
        }
        dialogueisplaying = false;
        dialoguepanel.SetActive(false);
        dialoguetext.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        currentchat += line;
        dialoguetext.text = "";
        HideChoices();
        foreach (var word in line.Split(' '))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                dialoguetext.text = line;
                break;
            }
            dialoguetext.text += word + " ";
            yield return new WaitForSeconds(typingspeed);
        }
        DisplayChoices();
    }

    private void HideChoices()
    {
        foreach (var choicesbutton in choices)
        {
            choicesbutton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (var tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length!= 2)
            {
                Debug.LogWarning("te veel tags");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    dialoguenametext.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("iets ging fout");
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicestext[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

    }

    public void MakeChoice(int choiceIndex)
    {
        currentchat += choicestext[choiceIndex].text + "\n";
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
