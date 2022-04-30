# HogeBlazor
.NET 6ベースのWebアプリケーションサンプルプロジェクト。

## ソリューション構成

|  フォルダ  |  説明  |
| ---- | ---- |
|  .aws  |  AWS関連設定を格納  |
|  .github  |  GitHub関連設定を格納  |
|  Client  |  Blazor WebAssemblyプロジェクト  |
|  Client.Test  |  Clientプロジェクトのテスト  |
|  Docker  |  Dockerおよび関連設定ファイルを格納  |
|  HogeFunction  |  AWS Lambdaプロジェクト  |
|  OpenApi  |  NSwagおよびOpenApi関連設定ファイルを格納  |
|  Server  |  ASP.NET Coreプロジェクト  |
|  Server.Test  |  Serverプロジェクトのテスト  |
|  Shared  |  共通ライブラリプロジェクト  |
|  Shared.Test  |  Sharedプロジェクトのテスト  |

## プロジェクト構成
最初はなるべくシンプルなフォルダ構成にするが、開発が進んで肥大化してきたら適当にフォルダを分ける。

### Client
コードビハインド(razor.cs)やCSSの構成は未定。プロジェクトの拡大を見越してある程度の構造化を検討する必要あり。

|  フォルダ  |  説明  |
| ---- | ---- |
|  Helpers  |  画面に依存しない共通処理  |
|  Pages  |  個別の画面実装  |
|  Properties  |  VSCode用の起動設定(現状設定はしてあるが期待通り動いていないはず)  |
|  Shared  |  画面が依存する共通部品、レイアウト  |
|  wwwroot  |  Web関連のリソース  |

### Client.Test
基本的にテスト対象プロジェクトと同じフォルダ構成にする。
Clientプロジェクトに実装を追加したタイミングでテストも実装する。

### HogeFunction
`Amazon.Lambda.Templates`で作成したテンプレートプロジェクトをベースにする。

|  フォルダ  |  説明  |
| ---- | ---- |
|  src/HogeFunction  |  機能実装  |
|  test/HogeFunction.Tests  |  HogeFunctionのテスト  |

### Server

|  フォルダ  |  説明  |
| ---- | ---- |
|  Controllers  |  コントローラ実装。APIを追加・変更する場合、このフォルダ配下のファイルを修正する。  |
|  Helpers  |  コントローラに依存しない共通処理、DBアクセス実装など  |
|  Migrations  |  マイグレーション関連ファイル。基本的にEntityFrameworkのマイグレーション機能により自動生成する。  |
|  Models  |  Serverでのみ参照するモデルファイルを格納  |
|  Pages  |  テンプレートを元にプロジェクト作成時に存在したフォルダ。精査して不要であれば削除を検討  |
|  Properties  |  VSCode用の起動設定(こちらは期待通り動くはず)  |

### Server.Test
基本的にテスト対象プロジェクトと同じフォルダ構成にする。
Serverプロジェクトに実装を追加したタイミングでテストも実装する。

### Shared

|  フォルダ  |  説明  |
| ---- | ---- |
|  Helpers  |  DBモデルクラス以外の雑多な実装(Dtoクラスはフォルダ分けしてもいいかもしれない)  |
|  Models  |  DBモデルクラス実装  |

### Shared.Test
基本的にテスト対象プロジェクトと同じフォルダ構成にする。
Sharedプロジェクトに実装を追加したタイミングでテストも実装する。

## 開発環境の前提条件
- OS
    - Linux or MacOS
        - （Windowsでの起動は未確認）

## 開発環境の構築
- [Visual Studio Code](https://code.visualstudio.com/download)のインストール
    - 拡張機能のインストール
        - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
        - [Docker](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker)
    - 推奨設定
        - タブサイズ(Tab size: 4)
        - 改行コード(EoL: \n)
        - 空白文字の表示(Render Whitespace: boundary)
        - ファイル保存時のフォーマット(Editor: Format On Save: true)
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
    Lambdaプロジェクトを作成する場合推奨
    ```
    $ dotnet new -i Amazon.Lambda.Templates
    ```
- [Docker本体](https://docs.docker.com/get-docker/)のインストール

## ビルド手順
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
    以下のコマンドを実行することで`~/Client/Helpers/ApiClient.cs`を最新の状態に更新する。
    ```
    $ nswag run ./OpenApi/nswag.json
    ```
    4. ソリューション全体のビルド
    ```
    $ dotnet build
    ```
    5. データベースの構築
    ```
    $ docker compose build
    $ docker compose up -d mysql
    ```
    6. データベース起動確認
    mysqlの起動を確認する。
    ```
    $ docker compose logs mysql
    hoge-blazor-mysql | 2022-03-12T01:11:30.952203Z 0 [System] [MY-010931] [Server] /usr/sbin/mysqld: ready for connections. Version: '8.0.28'  socket: '/var/run/mysqld/mysqld.sock'  port: 3306  MySQL Community Server - GPL.
    ```
    7. データベースの構築
    ```
    $ dotnet ef database update --project ./Server/HogeBlazor.Server.csproj
    ```

## データベースの確認
- MySQL
    ```
    $ mysql -h 127.0.0.1 -uroot -p
    > show database;
    > use hoge_blazor;
    > show tables;
    > desc Users;
    ```

## デバッグ実行
### VSCode上でのデバッグ実行
VSCodeでプロジェクトを開きF5。

### コマンドラインで開発用インスタンスの実行
- Client
    ```
    $ cd ./Client
    $ dotnet run
    ```

- Server
    ```
    $ cd ./Server
    $ dotnet run
    ```
## DBマイグレーション

1. モデルの修正
    ./Shared/Models/*.cs を編集
2. マイグレーションの追加
    ```
    $ cd ./Server
    $ dotnet ef migrations add [マイグレーション名]
3. マイグレーションの実行
    ```
    $ dotnet ef database update
    ```
## DBマイグレーションのリセット
開発を進めていて、マイグレーションをキレイにしたいときに実行する。
1. データベースの削除
    ```
    $ mysql -h 127.0.0.1 -uroot -p -e "drop database hoge_blazor;"
    ```

2. マイグレーションファイルの削除
    ```
    $ rm ./Server/Migrations/*
    ```
3. マイグレーションの追加
    ```
    $ cd ./Server
    $ dotnet ef migrations add InitialCreate
4. マイグレーションの実行
    ```
    $ dotnet ef database update
    ```

## テスト実行
    ```
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
    $ cd ./Server.Test
    $ dotnet test
    ```

    さらに、`--filter`オプションでテスト対象関数やクラスを絞り込める。

    ```
    $ dotnet test --filter ClaimsToUserReturnsValidValue
    ```

## デプロイ手順
mainブランチを更新。
あとは`.github/workflows/deploy_ecs_aws.yml`に従ってAmazon ECSにデプロイが実行される。
（余分な料金がかからないよう、普段はECSを削除してある）

- 参考
    - [Amazon Elastic Container Serviceへのデプロイ](https://docs.github.com/ja/actions/deployment/deploying-to-your-cloud-provider/deploying-to-amazon-elastic-container-service)
    - [GitHub ActionsからECSとECRへのCI/CDを最小権限で実行したい](https://dev.classmethod.jp/articles/github-actions-ecs-ecr-minimum-iam-policy/)

## 環境の説明
- ローカル開発環境
    - WebApp
        - ホスト名：localhost
        - 待受ポート：5000
    - Database
        - ホスト名：localhost
        - 待受ポート：3306
- GitHub Actionsテスト環境
    - WebApp
        - ホスト名：localhost
        - 待受ポート：80
    - Database
        - ホスト名：mysql
        - 待受ポート：3306
- Amazon ECR
    - WebApp
        - ホスト名：aws.ecr.amazon.com
        - 待受ポート：80
    - Database
        - ホスト名：aws.rds.amazon.com
        - 待受ポート：3306
- Amazon EC2
    - WebApp
        - ホスト名：aws.ec2.amazon.com
        - 待受ポート：5000
    - Database
        - ホスト名：aws.rds.amazon.com
        - 待受ポート：3306

## プロジェクトの構築手順
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
    $ cd ./HogeBlazor/Client
    $ dotnet run
    ```
    コンソール上に表示されたhttp://localhost:{ポート番号}にブラウザからアクセスして「Hello, world!」が表示されたらOK。
    例：`http://localhost:5000/`
    - Serverの動作確認
    ```
    $ cd ./HogeBlazor/Server
    $ dotnet run
    ```
    コンソール上に表示されたURLにControllerのパス付きでアクセスしてJSON配列が返ってきたらOK。
    例：`http://localhost:5000/WeatherForecast`

- .gitignoreの追加
    gitリポジトリで不要なファイルを管理しないよう.gitignoreを追加する。
    ```
    $ cd ./HogeBlazor
    $ dotnet new gitignore
    ```

- テストプロジェクトの作成
    Server, Client, Sharedそれぞれ用のテストプロジェクトを追加してテスト対象プロジェクトと関連付ける。
    ```
    $ cd ./HogeBlazor
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

## 参考情報
- [AuthenticationStateProvider in Blazor WebAssembly](https://code-maze.com/authenticationstateprovider-blazor-webassembly/)
- [Blazor WebAssembly Registration Functionality with ASP.NET Core Identity](https://code-maze.com/blazor-webassembly-registration-aspnetcore-identity/)
- [Blazor WebAssembly Authentication with ASP.NET Core Identity](https://code-maze.com/blazor-webassembly-authentication-aspnetcore-identity/)
- [Role-Based Authorization with Blazor WebAssembly](https://code-maze.com/blazor-webassembly-role-based-authorization/)
- [Refresh Token with Blazor WebAssembly and ASP.NET Core Web API](https://code-maze.com/refresh-token-with-blazor-webassembly-and-asp-net-core-web-api/)