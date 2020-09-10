using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] float MaxProgress;
    [SerializeField] float CurrentProgress;

    bool firstUpdate = true;

    Level level;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstUpdate)
        {
            firstUpdate = false;
            CurrentProgress = level.GetEnemiesThisLevel();
            MaxProgress = CurrentProgress;
        }
        CurrentProgress = level.GetEnemies();
        transform.localScale = new Vector3(CurrentProgress / MaxProgress, 1.0f, 1.0f);

    }
}
