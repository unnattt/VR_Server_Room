using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<PlugController> plugs;
    [SerializeField] private Canvas playAgainCanvas;
    [SerializeField] private Transform _inServerRoomPos;
    [SerializeField] private Transform _outServerRoomPos;
    [SerializeField] private Transform _xrPlayer;

    private void Start()
    {
        
    }

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

    public void EnterServerRoom()
    {
        _xrPlayer.SetPositionAndRotation(_inServerRoomPos.position, _inServerRoomPos.rotation);
    }

    public void ExitServerRoom()
    {
        _xrPlayer.SetPositionAndRotation(_outServerRoomPos.position, _outServerRoomPos.rotation);
    }

    private void GameOver()
    {
        playAgainCanvas.GetComponent<ExitPopUp>().OnGameOver();
    }
}
