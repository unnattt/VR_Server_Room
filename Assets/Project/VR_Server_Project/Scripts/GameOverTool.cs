using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTool : MonoBehaviour
{
    [SerializeField] private List<PlugController> plugs;
    [SerializeField] private Canvas playAgainCanvas;

    public void CheckAllPulgIsConnected()
    {
        bool allConnected = true;

        foreach (PlugController plug in plugs)
        {
            if (!plug.isConected)
            {
                allConnected = false;
                break; // No need to continue checking if one plug is not connected
            }
        }

        if (allConnected)
        {
            Invoke(nameof(GameOver), 2f);
        }
    }

    private void GameOver()
    {
        playAgainCanvas.GetComponent<ExitPopUp>().OnGameOver();
    }
}
