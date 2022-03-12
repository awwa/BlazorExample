# 環境の構築

- [Visual Studio Code](https://code.visualstudio.com/download)のインストール
- [.NET SDK 6.0](https://dotnet.microsoft.com/en-us/download)のインストール
- EntityFramework Coreツールのインストール
    ```
    $ dotnet tool install --global dotnet-ef
    ```
- OpenAPI関連ツールのインストール
    ```
    $ npm install nswag -g
    ```
- OpenAPIツールのインストール
    ```
    $ dotnet tool install -g Microsoft.dotnet-openapi
    ```
# ビルド手順
    1. git clone
    ```
    $ git clone https://github.com/awwa/blazor-example.git
    $ cd HogeBlazor
    ```
    2. Serverのビルド
    ```
    $ dotnet build ./Server/HogeBlazor.Server.csproj
    ```
    3. ServerのControllerからApiクライアントのビルド
    ```
    $ nswag run ./OpenApi/nswag.json
    ```
    4. ソリューション全体のビルド
    ```
    $ dotnet build
    ```
    5. データベースの構築
    ```
    $ docker-compose build
    $ docker-compose up -d mysql
    ```
    6. データベース起動確認
    ```
    $ docker-compose logs mysql
    hoge-blazor-mysql | 2022-03-12T01:11:30.952203Z 0 [System] [MY-010931] [Server] /usr/sbin/mysqld: ready for connections. Version: '8.0.28'  socket: '/var/run/mysqld/mysqld.sock'  port: 3306  MySQL Community Server - GPL.
    ```
    7. データベースの構築
    ```
    $ dotnet ef database update --project ./Server/HogeBlazor.Server.csproj 
    ```

# データベースの確認
- MySQL
    ```
    $ mysql -h 127.0.0.1 -uroot -p
    > show database;
    > use hoge_blazor;
    > show tables;
    > desc Users;
    ```

# デバッグ
Visual Studio Codeでプロジェクトを開きF5。

# 開発用インスタンスの実行
- Client
    ```
    $ cd HogeBlazor/Client
    $ dotnet run
    ```

- Server
    ```
    $ cd HogeBlazor/Server
    $ dotnet run
    ```
# DBマイグレーション

1. モデルの修正
    ./Shared/Models/*.cs を編集
2. マイグレーションの追加
    ```
    $ cd HogeBlazor/Server
    $ dotnet ef migrations add [マイグレーション名]
3. マイグレーションの実行
    ```
    $ cd HogeBlazor
    $ dotnet ef database update --project ./Server/HogeBlazor.Server.csproj 
    ```
# DBマイグレーションの初期化
開発を進めていて、マイグレーションをキレイにしたいときに実行する。
1. データベースの削除
    ```
    $ mysql -h 127.0.0.1 -uroot -p -e "drop database hoge_blazor;"
    ```

2. マイグレーションファイルの削除
    ```
    $ rm ./Servers/Migrations/*
    ```
3. マイグレーションの追加
    ```
    $ cd HogeBlazor/Server
    $ dotnet ef migrations add InitialCreate
4. マイグレーションの実行
    ```
    $ dotnet ef database update
    ```

# テスト実行

    ```
    $ cd ~/HogeBlazor
    $ dotnet test
    ```

    以下のようなログが出力されたらOK。

    ```
    成功!   -失敗:     0、合格:     1、スキップ:     0、合計:     1、期間: < 1 ms - /Users/wataru/github/blazor-example/HogeBlazor/Shared.Test/bin/Debug/net6.0/Shared.Test.dll (net6.0)

    成功!   -失敗:     0、合格:     4、スキップ:     0、合計:     4、期間: 15 ms - /Users/wataru/github/blazor-example/HogeBlazor/Client.Test/bin/Debug/net6.0/Client.Test.dll (net6.0)

    成功!   -失敗:     0、合格:     1、スキップ:     0、合計:     1、期間: < 1 ms - /Users/wataru/github/blazor-example/HogeBlazor/Server.Test/bin/Debug/net6.0/Server.Test.dll (net6.0)
    ```

# デプロイ手順
- Dockerビルド
    ```
    $ cd HogeBlazor
    $ docker-compose build
    ```
- 起動確認
    `--force-recreate`オプションを付けるとコンテナを再構築するため、DBに登録済みのデータが全初期化されるので開発環境で実行する際は要注意。
    ```
    $ docker-compose up -d --force-recreate
    # doneが出ても実際に起動完了するまでに少し時間がかかるのでlogsコマンドで起動確認
    $ docker-compose logs
    ```
    `http://localhost:5000`にアクセス
- 実行環境にコンテナをデプロイ
    TODO 書きかけ。実行環境ごとに異なる

docker build -t sample .
docker images
docker tag 7b1b30224e93 450190930314.dkr.ecr.ap-northeast-1.amazonaws.com/sample:latest
docker images
docker push 450190930314.dkr.ecr.ap-northeast-1.amazonaws.com/sample:latest

# プロジェクトの構築手順
ゼロからプロジェクトを構築する手順をまとめた。
リポジトリをクローンしたらこの手順は不要。

- HostedなBlazor WebAssemblyアプリとして基本的なプロジェクトを作成する
    ```
    $ dotnet new blazorwasm -o HogeBlazor --hosted
    ```
    オプションの説明：
    - --hosted
        - Blazor WebAssemblyをASP.NET Core上に最初からホスティングする前提でよく使われるプロジェクトセットを構築してくれる
    - --no-https
        - HTTPSを無効化する。最終的に公開する際はHTTPSをホスティングするゲートウェイの背後に配置することになるケースが多いので、最初からHTTPSを無効化しておく意図。
    自動生成されるプロジェクトセットの説明：
    - Client
        - Blazor WebAssemblyアプリServer上に静的なブラウザアプリとしてホスティングされ、ServerとはWebAPIを介して通信を行い動作する
    - Server
        - ASP.NET CoreベースのWebアプリ。とりあえず、WebAPIのみを実装する。
    - Shared
        - ClientとServerが共通で利用するライブラリ実装

- 最初の動作確認
    - Clientの動作確認
    ```
    $ cd ~/HogeBlazor/Client
    $ dotnet run
    ```
    コンソール上に表示されたhttp://localhost:{ポート番号}にブラウザからアクセスして「Hello, world!」が表示されたらOK。
    例：`http://localhost:5000/`
    - Serverの動作確認
    ```
    $ cd ~/HogeBlazor/Server
    $ dotnet run
    ```
    コンソール上に表示されたURLにControllerのパス付きでアクセスしてJSON配列が返ってきたらOK。
    例：`http://localhost:5000/WeatherForecast`

- .gitignoreの追加
    gitリポジトリで不要なファイルを管理しないよう.gitignoreを追加する。
    ```
    $ cd ~/HogeBlazor
    $ dotnet new gitignore
    ```

- テストプロジェクトの作成
    Server, Client, Sharedそれぞれ用のテストプロジェクトを追加してテスト対象プロジェクトと関連付ける。
    ```
    $ cd ~/HogeBlazor
    # テストプロジェクトの生成
    $ dotnet new bunit --framework xunit -o Client.Test # Client用
    $ dotnet new xunit -o Server.Test                   # Server用
    $ dotnet new xunit -o Shared.Test                   # Shared用
    # テスト対象プロジェクトに対する参照設定の追加
    $ dotnet add Client.Test/Client.Test.csproj reference Client/HogeBlazor.Client.csproj
    $ dotnet add Server.Test/Server.Test.csproj reference Server/HogeBlazor.Server.csproj
    $ dotnet add Shared.Test/Shared.Test.csproj reference Shared/HogeBlazor.Shared.csproj
    # slnファイルに追加したテストプロジェクトを登録
    $ dotnet sln add Client.Test/Client.Test.csproj 
    $ dotnet sln add Server.Test/Server.Test.csproj 
    $ dotnet sln add Shared.Test/Shared.Test.csproj 
    ```


# TODO
- openapiの導入
- マイグレーションと初期データ投入の実装
- PostgreSQLの導入
