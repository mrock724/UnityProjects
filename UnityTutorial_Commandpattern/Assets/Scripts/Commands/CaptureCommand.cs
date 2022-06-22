using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCommand : CommandManager.ICommand
{
    private Vector3Int mStart;
    private Vector3Int mEnd;

    private Unit mCaptured;
    private Unit mCapturing;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public CaptureCommand(Vector3Int start, Vector3Int end)
    {
        mStart = start;
        mEnd = end;
    }

    public void Execute()
    {
        mCaptured = Gameboard.Instance.GetUnit(mEnd);
        mCapturing = Gameboard.Instance.GetUnit(mStart);

        Gameboard.Instance.MoveUnit(mCapturing, mEnd);
        Gameboard.Instance.TakeOutUnit(mCaptured);
        Gameboard.Instance.SwitchTeam();
    }

    public void Undo()
    {
        Gameboard.Instance.MoveUnit(mCapturing, mStart);
        Gameboard.Instance.MoveUnit(mCaptured, mEnd);
        Gameboard.Instance.SwitchTeam();
    }
}
