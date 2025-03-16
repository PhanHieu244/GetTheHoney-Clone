using System;
using _Game;
using _Game.ChuongScripts;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : Singleton<Player>
{ 
    [SerializeField] private Knife _knifePrefab;
    [SerializeField] private LoopMovement _loopMovement;
    [SerializeField] private Transform start, end;
    [SerializeField] private float timeThrow;
    private float x;
    private float leftPercent = 0.5f;
    private float rightPercent = 0.5f;
    private Knife currentKnife;
    private Knife recentKnife;
    private int count;
    private bool isLose = false;
    
    private void Start()
    {
        isLose = false;
        count = 7;
        var level = Data.Player.level;
        if(level > 2)
        {
            count = 6;
        }
        if(level > 4)
        {
            count = 5;
        }
        if(level > 8)
        {
            count = 5;
        }
        if(level > 12)
        {
            count = 4;
        }
        if(level > 22)
        {
            count = 3;
        }
        KnifeGroup.Instance.ShowKnife(count);
        Spawn();
        Fill.fill = GetPercent();
    }

    private void Spawn()
    {
        if (CheckWinLose())
        {
            return;
        }
        currentKnife = Instantiate(_knifePrefab);
        currentKnife.transform.position = start.position;
        _loopMovement.ChangeMover(currentKnife.transform);
        KnifeGroup.Instance.RemoveKnife();
        count--;
    }

    public void Throw()
    {
        if (currentKnife == null) return;
        x = currentKnife.transform.position.x;
        _loopMovement.StopLoop();
        _loopMovement.Movement.Move(currentKnife.transform, new Vector2(x, end.position.y), timeThrow);
        recentKnife = currentKnife;
        currentKnife = null;
        DOVirtual.DelayedCall(timeThrow, () =>
        {
            Cutting(x);
            Spawn();
            Destroy(recentKnife.gameObject);
        }).SetTarget(transform);
    }

    private bool CheckWinLose()
    {
        if (GetPercent() >= 1f)
        {
            ShowWin();
            return true;
        }

        if (count <= 0)
        {
            ShowLose();
            return true;
        }

        return false;
    }

    private void ShowWin()
    {
        transform.DOKill();
        Data.Player.level++;
        _loopMovement.StopLoop();
        Manager.ScreenManager.OpenScreen(ScreenType.Win);
    }

    public void ShowLose()
    {
        if (isLose) return;
        isLose = true;
        transform.DOKill();
        _loopMovement.StopLoop();
        Manager.ScreenManager.OpenScreen(ScreenType.Lose);
    }

    private float GetPercent()
    {
        return (1f - leftPercent - rightPercent) * 1.25f;
    }
    
    
    
    private void Cutting(float xPos)
    {
        Honey.Instance.slicing.GetPercent(xPos, out var left, out var right);
        if (left < leftPercent) leftPercent = left;
        if (right < rightPercent) rightPercent = right;
        Honey.Instance.slicing.Cutting(leftPercent, rightPercent);
        Fill.fill = GetPercent();
    }
}
