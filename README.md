# 鏡子

第七組 Unity 遊戲專案。玩家在第一人稱視角中探索場景，透過旋轉鏡子改變雷射路徑、觸發機關、取得鑰匙並通過關卡。

## 專案資訊

- 引擎版本：Unity `6000.3.17f1`
- 渲染管線：Universal Render Pipeline，URP
- 專案資料夾：`鏡子!!!!!`
- 主要場景：
  - `Assets/關卡/MainMenu.unity`
  - `Assets/關卡/IntroScene.unity`
  - `Assets/關卡/GameScene.unity`

## 快速開始

1. 使用 Unity Hub 開啟 `鏡子!!!!!` 資料夾。
2. 確認 Unity 版本為 `6000.3.17f1`，或使用相容的 Unity 6 版本開啟。
3. 等待 Unity 匯入套件與資源。
4. 從 `Assets/關卡/MainMenu.unity` 開始執行。

Build Settings 內的場景順序已設定為：

1. `MainMenu`
2. `IntroScene`
3. `GameScene`

## 操作方式

- `WASD`：移動
- 滑鼠：控制視角
- `Left Shift`：奔跑
- `Space`：跳躍
- 滑鼠左鍵：
  - 對準鏡子時，按住並拖曳可旋轉鏡子
  - 對準鑰匙時，可拾取鑰匙並開門
- `Esc`：顯示離開遊戲提示
- 長按 `Esc` 3 秒：離開遊戲
- 提示出現時按 `F`：關閉離開提示

## 遊戲機制

- 玩家需要觀察場景中的雷射、鏡子、目標與門。
- 雷射碰到帶有 `Mirror` 標籤的物件時會反射。
- 雷射命中特定目標後會觸發關卡事件。
- 鑰匙可透過準心互動拾取，並用來開啟對應的門。
- 關卡有倒數計時，時間歸零時會顯示 Game Over 畫面。

## 專案結構

```text
鏡子!!!!!
├─ Assets/
│  ├─ 關卡/              # MainMenu、IntroScene、GameScene
│  ├─ 程式/
│  │  ├─ UI/             # 選單、教學、計時、結局與離開提示
│  │  ├─ 主角/           # 第一人稱移動與物件互動
│  │  ├─ 鏡頭/           # 鏡頭與影片結束流程
│  │  ├─ 鑰匙/           # 鑰匙生成、拾取與門控制
│  │  └─ 雷射/           # 雷射反射與目標觸發
│  ├─ Prefab/            # 遊戲物件預製件
│  ├─ Materials/         # 材質
│  ├─ 物品/              # 互動物件與道具
│  ├─ 貼圖/              # 貼圖資源
│  └─ AssetsStore/       # 外部美術資源
├─ Packages/             # Unity 套件設定
└─ ProjectSettings/      # Unity 專案設定
```

## 主要腳本

- `PlayerMove.cs`：第一人稱移動、跳躍、奔跑與視角控制。
- `ObjectControl.cs`：偵測準心目標，控制鏡子旋轉與互動提示顏色。
- `LaserReflect.cs`：使用 Raycast 計算雷射路徑與鏡面反射。
- `LaserTarget.cs` / `LaserTarget_Room2.cs`：雷射命中目標後觸發事件。
- `KeySpawner.cs` / `KeyPickup.cs` / `DoorController.cs`：鑰匙、拾取與開門流程。
- `GameTimer.cs`：關卡倒數與 Game Over 流程。
- `Menu.cs`：主選單開始遊戲流程。

## 開發注意事項

- 請不要提交 `Library/`、`Logs/`、`Temp/` 等 Unity 自動產生資料夾。
- 新增場景後，請同步檢查 Build Settings 的場景順序。
- 鏡子互動依賴 `Mirror` 標籤，鑰匙互動依賴 `Key` 標籤。
- 若調整雷射或鏡子物件，請確認 Collider、Line Renderer 與腳本參數仍正確。

