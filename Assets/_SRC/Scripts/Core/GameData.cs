using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {

    private static GameData _instance = new GameData();
    public Transform shipTr;
    public PlatformManager platformManager;
    public GameplayUI ui;

    private GameData() {

    }

    public static GameData instance {
        get { return _instance; }
    }
}
