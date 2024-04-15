# Athletic-Runner
## １.システムの概要
自作ゲーム **「Athletic Runner」** のUnityプロジェクトです。

## ２.ゲーム概要
①ゲーム名：Athletic Runner

②プラットフォーム：PC

③ゲームジャンル：3Dアクションアスレチック

④ゲームコンセプト：ジャンプやギミックを活かして、ゴールを目指す３Dアスレチックアクションゲーム
 
 　　　　　　　　　　です。ユニティちゃんと共に難解アスレチックに挑戦しよう！

⑤使用技術：Unity C#、VisualStadio2022

⑥製作期間：7日

## ３.ゲームルール
### ◎Level1
ジャンプとトランポリンを活かして、落下しないようにゴールを目指す。

落下した場合、スタートに戻される。

### ◎Level2
今回は、２つのコースがあり、それぞれのコースを落下しないように、クリアしてコインを集めることで、

ゴールへの扉が開く。

①テクニックコース

　テクニックコースでは、Level1の時と同様に、ジャンプとトランポリンを活かして、ゴールを目指し、

　コインをゲットする。落下した場合、スタートに戻される。
 
②ギミックコース

　ギミックコースでは、落下するボール、回転する棒、移動する床があり、これらを乗り越えて、

　ゴールを目指し、コインをゲットする。
 
　また、プレイヤーには、HPが設定されており、ボールや棒にぶつかることで、HPが減少する。
 
　落下したり、HPが０になった場合、スタートに戻され、入手したコインは、剥奪されてしまう。

## ４.操作方法
①前後左右

　W：前進、A：左、S：後退、D右
 
②ジャンプ

　SPASE
 
③走行

　SHIFT

④カメラ移動

　マウス

## ５.シーン構成
①Title_Scene：タイトル

②Level1_Scene：レベル１

③Level2_Scene：レベル２

## ６.スクリプト概要
①PlayerManager

　プレイヤーのキャラクター操作スクリプト

②DeadZoneManager

　デッドゾーンの制御スクリプト

③YellowTrampoline

　トランポリンの制御スクリプト

④WhiteGoal

　ゴールの制御スクリプト

⑤PanelManager

　ゲーム開始時に表示・非表示させるパネルの管理スクリプト

⑥Button_PanelManager

　ボタンを押された際に指定したパネルの表示切替を行うスクリプト

⑦CameraManager

　ゲーム開始時にON・OFFさせるカメラの管理スクリプト

⑧Button_CameraManager

　ボタンを押された際に指定されたカメラに切り替えるスクリプト

⑨Button_SceneManager

　ボタンを押した際にシーン移動をする関数を管理するスクリプト

⑩SoundManager

　BGMやSEの管理をするスクリプト

⑪WhiteReturn

　スタートに帰還するエリアの制御スクリプト

⑫BallManager

　ボールの生成を行うスクリプト

⑬YellowBall

　プレイヤーがボールに当たった際の制御スクリプト

⑭HPManager

　プレイヤーのHPを管理するスクリプト

⑮RodManager

　棒を回転させ続けるスクリプト

⑯YellowRod

　プレイヤーが棒に当たった際の制御スクリプト

⑰MoveManager

　床を往復させるスクリプト

⑱CoinManager

　コインの機能スクリプト

⑲DoorManager1

　プレイヤーから見て右のドアを開けるスクリプト

⑳DoorManager2

　プレイヤーから見て左のドアを開けるスクリプト

㉑DoorSensor

　ドアのセンサースクリプト

## ７.オブジェクト概要
### ◎Title_Scene
①Title_Panelタイトル画面

　・Stand：キャラクターが走る土台

　・Level1_Button：レベル1ボタン（Level1_Sceneに移動する）

　・Level2_Button：レベル1ボタン（Level2_Sceneに移動する）

　・Rule_Button：操作ボタン（Title_Panelを非表示にして、Rule_Panelを表示する）

　・Title_Logo：タイトルロゴ

②Rule_Panel：操作方法画面

　・W：Wキーの画像

　・A：Aキーの画像

　・S：Sキーの画像

　・D：Dキーの画像

　・Space：スペースキーの画像

　・Shift：シフトキーの画像

　・Mouse：マウスの画像

　・Rule：操作方法の文章

　・Return_Button：戻るボタン（Rule_Panelを非表示にして、Title_Panelを表示する）

③PanelManager：PanelManagerスクリプト用の空オブジェクト

④SoundManager：SoundManagerスクリプト用の空オブジェクト

### ◎Level1_Scene
①RuleCamera：ルール画面を移すカメラ

　・RuleCanvas：ルールキャンバス

　　→RulePanel：ルールパネル

　　　→Rule1～4：ルール

　　　→Start_Button：スタートボタン（ルール画面を非表示にしてゲーム開始）

②CameraManager：CameraManager用の空オブジェクト

③Main Camera：TPS視点を移すカメラ

④HP_Canvas：HPキャンバス

　・HP_Slider：HPバー

⑤Stage：ステージ

⑥DeadZone：デッドゾーン

⑦ClearCamera：クリア画面を移すカメラ

　・ClearCanvas：クリアキャンバス

　　→ClearPanel：クリアパネル

　　　→Clear_Logo：クリアロゴ

　　　→Title_Button：タイトルボタン（Title_Sceneに移動する）

⑧SoundManager：SoundManagerスクリプト用の空オブジェクト

### ◎Level2_Scene
①RuleCamera：ルール画面を移すカメラ

　・RuleCanvas：ルールキャンバス

　　→RulePanel1：ルールパネル１

　　　→Rule1～4：ルール

　　　→Next_Button：次へボタン（ルール画面１を非表示にしてルール画面２を表示する。）

　　→RulePanel2：ルールパネル２

　　　→Rule1～2：ルール

　　　→Start_Button：スタートボタン（ルール画面を非表示にしてゲーム開始）

②CameraManager：CameraManager用の空オブジェクト

③Main Camera：TPS視点を移すカメラ

④HP_Canvas：HPキャンバス

　・HP_Slider：HPバー

⑤Stage：ステージ

⑥DeadZone：デッドゾーン

⑦ClearCamera：クリア画面を移すカメラ

　・ClearCanvas：クリアキャンバス

　　→ClearPanel：クリアパネル

　　　→Clear_Logo：クリアロゴ

　　　→Title_Button：タイトルボタン（Title_Sceneに移動する）

⑧Signboard：コース案内

⑨Coin：コイン

⑩DoorSensor：ドアセンサー

⑪DoorManager1：DoorManager1スクリプト用の空オブジェクト

⑫DoorManager2：DoorManager2スクリプト用の空オブジェクト

⑬SoundManager：SoundManagerスクリプト用の空オブジェクト

⑭PanelManager：PanelManagerスクリプト用の空オブジェクト

⑮BallManager：BallManager用の空オブジェクト

## ８.使い方
一部画像、３Dモデル、BGM、SEなど設定されていないため、下記の手順で必要素材を挿入してください。

## ◎Title_Scene
①下記の８個に画像を挿入する。

　・W：Wキーの画像

　・A：Aキーの画像

　・S：Sキーの画像

　・D：Dキーの画像

　・Space：スペースキーの画像

　・Shift：シフトキーの画像

　・Mouse：マウスの画像

　・Return_Button：戻るボタン

②SoundManagerにBGMを挿入する。（計２個）

　・Title_BGM：Title_Sceneで流れるBGM

　・Game_BGM：Level1とLevel2で流れるBGM

③SoundManagerにSEを挿入する。（計６個）

　・Button：ボタンを押したときに流れるSE

　・Clear：ゲームクリア時に流れるSE

　・Jump：キャラクターのジャンプSE

　・Trampoline：トランポリンで跳ねた時のSE

　・Damage：ボールや棒に当たり、ダメージを受けた時のSE

　・Coin：コインを書くときした時のSE

## ◎Level1_Scene
①Rule１～４に背景画像を挿入する。

②Start_Buttonにボタン画像を挿入する。

③Title_Buttonにボタン画像を挿入する。

④Coinに３Dモデルを挿入する。

⑤SoundManagerにBGMを挿入する。（計２個）

　・Title_BGM：Title_Sceneで流れるBGM

　・Game_BGM：Level1とLevel2で流れるBGM

⑥SoundManagerにSEを挿入する。（計６個）

　・Button：ボタンを押したときに流れるSE

　・Clear：ゲームクリア時に流れるSE

　・Jump：キャラクターのジャンプSE

　・Trampoline：トランポリンで跳ねた時のSE

　・Damage：ボールや棒に当たり、ダメージを受けた時のSE

　・Coin：コインを書くときした時のSE

### ◎Level2_Scene
①Rule１～６に背景画像を挿入する。

②Next_Buttonにボタン画像を挿入する。

③Start_Buttonにボタン画像を挿入する。

④Title_Buttonにボタン画像を挿入する。

⑤下記の２個に３Dモデルを挿入する。

　・Coin1

　・Coin2

⑥SoundManagerにBGMを挿入する。（計２個）

　・Title_BGM：Title_Sceneで流れるBGM

　・Game_BGM：Level1とLevel2で流れるBGM

⑦SoundManagerにSEを挿入する。（計６個）

　・Button：ボタンを押したときに流れるSE

　・Clear：ゲームクリア時に流れるSE

　・Jump：キャラクターのジャンプSE

　・Trampoline：トランポリンで跳ねた時のSE

　・Damage：ボールや棒に当たり、ダメージを受けた時のSE

　・Coin：コインを書くときした時のSE

### ◎その他
・日本語対応のフォントインストール

　ボタンのテキスト、操作方法、ギミック説明など、日本語文字を使用できるフォント

　をダウンロードしてください。

## ９.ライセンス
<div><img src="https://unity-chan.com/images/imageLicenseLogo.png" alt="ユニティちゃんライセンス"><p>
 
このアセットは、『<a href="https://unity-chan.com/contents/license_jp/" target="_blank">ユニティちゃんライセンス</a>』で提供されています。

このアセットをご利用される場合は、『<a href="https://unity-chan.com/contents/guideline/" target="_blank">キャラクター利用のガイドライン</a>』も併せてご確認ください。</p></div>
