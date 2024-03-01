using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    public checkpointManager c;
    public GameObject menu;

    public void respawnAtCheckpoint()
    {
        c.respawn();
        menu.SetActive(false);
    }
}
