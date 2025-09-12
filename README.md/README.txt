# FitnessBooking

ASP.NET Core + Razor Pages + SQLite で作成した **パーソナルトレーニング予約システム** です。  
学習用に [FullCalendar](https://fullcalendar.io/) を組み込み、セッション予定をカレンダー表示できるようにしています。

## 主な機能（予定含む）

- カレンダーから予約の作成 / 編集 / 削除（CRUD）
- トレーナーごとに背景色を分けて表示
- 予約の重複チェック

## セットアップ方法

1. **ライブラリ復元**  
   ```bash
   libman restore

   2. **データベース作成 / マイグレーション**  
   初回セットアップ時、またはスキーマ変更後のみ実行してください。  
   ```bash
   dotnet ef database update

   3.アプリの起動
（開発を始めるときに毎回実行）
   ```bash
   dotnet run
   ```

   開発環境

Visual Studio 2022

.NET 8.0 (LTS)

SQLite (学習用の軽量 DB)

今後の拡張予定

認証機能（トレーナー / 顧客アカウント）

メール通知機能（SendGrid 無料枠を利用）

レスポンシブ対応 UI

