using System;
using System.Collections.Generic;

public interface IState<T>
{
    void Enter();  // 状態に入ったときの処理
    void Update(); // 状態実行中の継続処理
    void Exit();   // 状態から抜けるときの処理
    bool IsEnd();

    public void GetValue(out T value);
}

public class StateMachine<T>
{
    // 登録された状態を保持する辞書
    private readonly Dictionary<string, IState<T>> _states = new();

    // 現在アクティブな状態
    public IState<T> CurrentState { get; private set; }
    public string CurrentStateKey { get; private set; } = string.Empty;

    // 状態を登録するメソッド
    public void RegisterState(string key, IState<T> state)
    {
        if (state == null) throw new ArgumentNullException(nameof(state));

        _states[key] = state;
    }

    // 状態を遷移させるメソッド
    public void TransitionTo(string key)
    {
        if (!_states.TryGetValue(key, out var nextState))
        {
            Console.WriteLine($"[エラー] 状態 '{key}' は登録されていません。");
            return;
        }

        // 現在の状態の終了処理を実行
        CurrentState?.Exit();

        // 新しい状態に切り替え
        CurrentState = nextState;
        CurrentStateKey = key;

        // 新しい状態の開始処理を実行
        CurrentState.Enter();
    }

    // 毎フレームやループで実行する更新処理
    public void Update()
    {
        CurrentState?.Update();
    }
}