using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<RandomSpawner> levelSpawners;

    GameObject conversationCanvas;

    int levelIndex = -1;
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        conversationCanvas = GameObject.Find("Conv Canvas");
        StartNextLevel();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartNextLevel()
    {
        levelIndex++;

        StartCoroutine(StartLevelDialogue());

    }
    private IEnumerator StartLevelDialogue()
    {
        conversationCanvas.SetActive(true);
        GetComponent<NewDialogueButton>().NextDialogue();

        while (FindObjectOfType<DialogueManager>().finishedDialogue == false)
        {
            yield return null;
        }
        FindObjectOfType<DialogueManager>().finishedDialogue = false;
        conversationCanvas.SetActive(false);

        if (levelIndex == levelSpawners.Count)
        {
            Application.Quit();
        }
        LoadNextSpawners();

    }

    private void LoadNextSpawners()
    {
        Instantiate(levelSpawners[levelIndex]);

    }

}
