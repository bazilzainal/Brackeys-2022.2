using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool IsKeyDown(GameKey action)
    {
        switch (action)
        {
            case GameKey.Action:
                return Input.GetKey(KeyCode.Space);
        }

        throw new Exception("invalid key");
    }
}