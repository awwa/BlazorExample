# 環境の構築

- [Visual Studio Code](https://code.visualstudio.com/download)のインストール
    - 拡張機能のインストール
        - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
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
- Amazon.Lambda.Templatesのインストール
    ```
    $ dotnet new -i Amazon.Lambda.Templates
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
    ```
    $ cd HogeBlazor/Server
    ./Shared/Models/*.cs を編集
    ```
2. マイグレーションの追加
    ```
    $ dotnet ef migrations add [マイグレーション名]
3. マイグレーションの実行
    ```
    $ dotnet ef database update
    ```
# DBマイグレーションのリセット
開発を進めていて、マイグレーションをキレイにしたいときに実行する。
1. データベースの削除
    ```
    $ cd HogeBlazor/Server
    $ mysql -h 127.0.0.1 -uroot -p -e "drop database hoge_blazor;"
    ```

2. マイグレーションファイルの削除
    ```
    $ rm ./Migrations/*
    ```
3. マイグレーションの追加
    ```
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

    個別のテストプロジェクトフォルダ配下でテストを実行すると、テスト対象プロジェクトを絞り込める。

    ```
    $ cd ~/Server.Test
    $ dotnet test
    ```

    さらに、`--filter`オプションでテスト対象関数やクラスを絞り込める。

    ```
    $ dotnet test --filter ClaimsToUserReturnsValidValue
    ```

# デプロイ手順
mainブランチを更新。
あとは`.github/workflows/deploy_ecs_aws.yml`に従ってAmazon ECSにデプロイが実行される。
（余分な料金がかからないよう、普段はECSを削除してある）

- 参考
    - [Amazon Elastic Container Serviceへのデプロイ](https://docs.github.com/ja/actions/deployment/deploying-to-your-cloud-provider/deploying-to-amazon-elastic-container-service)
    - [GitHub ActionsからECSとECRへのCI/CDを最小権限で実行したい](https://dev.classmethod.jp/articles/github-actions-ecs-ecr-minimum-iam-policy/)

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
- AWS Lambda向けプロジェクトの作成
    ```
    $ dotnet new lambda.EmptyFunction --name HogeFunction
    $ dotnet sln add HogeFunction/src/HogeFunction/HogeFunction.csproj
    $ dotnet sln add HogeFunction/test/HogeFunction.Tests/HogeFunction.Tests.csproj
    ```