using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<RandomSpawner> levelSpawners;

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
        GetComponent<NewDialogueButton>().NextDialogue();

        while (FindObjectOfType<DialogueManager>().finishedDialogue == false)
        {
            yield return null;
        }
        LoadNextSpawners();

    }

    private void LoadNextSpawners()
    {
        if (levelIndex == levelSpawners.Count)
        {
            Debug.Log("End Game");
            return;
        }
        Instantiate(levelSpawners[levelIndex]);

    }

}
