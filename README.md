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
最初はなるべくシンプルなフォルダ構成にするが、DRY原則に従って開発が進むに従って構造化する。

### Client
コードビハインド(*.razor.cs)やCSS(*.razor.css)の構成計画は未定。

|  フォルダ  |  説明  |
| ---- | ---- |
|  Helpers  |  カテゴライズしていない共通処理  |
|  Pages  |  独立した画面の実装  |
|  Properties  |  VSCode用の起動設定(現状設定はしてあるが期待通り動いていないはず)  |
|  Repositories  |  主に画面とAPIアクセスの間を取り持つクラス群。画面はRepositoryクラスを介してAPIにアクセスする。データアクセスの提供をメイン機能に持つものをRepositoryと呼称。  |
|  Services  |  主に画面とAPIアクセスの間を取り持つクラス群。構造はRepositoryと同じ。機能提供をメインにしたものをServiceと呼称。  |
|  Shared  |  画面内の共通部品およびレイアウト  |
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
|  Db  |  DB関連実装。DbContext、EntityFrameworkが自動生成するMigrations、Seed(Configurations)を含む。  |
|  Helpers  |  コントローラに依存しない共通処理、DBアクセス実装など  |
|  Models  |  Serverでのみ参照するモデルファイルを格納  |
|  Pages  |  テンプレートを元にプロジェクト作成時に存在したフォルダ。精査して不要であれば削除を検討  |
|  Properties  |  VSCode用の起動設定(Clientプロジェクト配下の設定と違ってこちらは期待通り動くはず)  |
|  Repositories  |  DbContext経由でDBにアクセスする機能を提供するクラス群。ControllerはRepositoryクラス経由でDBにアクセスする  |
|  Settings  |  構成ごとの設定ファイル  |

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
    - Node.js(npm)
        - nvmの利用を推奨

## 開発環境の構築
1. [Visual Studio Code](https://code.visualstudio.com/download)のインストール
    - 拡張機能のインストール
        - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
        - [Docker](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker)
    - 推奨設定
        - タブサイズ(Tab size: 4)
        - 改行コード(EoL: \n)
        - 空白文字の表示(Render Whitespace: boundary)
        - ファイル保存時のフォーマット(Editor: Format On Save: true)
2. [.NET SDK 6.0](https://dotnet.microsoft.com/en-us/download)のインストール
3. EntityFramework Coreツールのインストール  
    dotnetコマンドでEFCoreを利用するために必要。
    ```
    $ dotnet tool install --global dotnet-ef
    ```
4. OpenAPI関連ツールのインストール  
    `ApiClient.cs`生成のために必要。
    ```
    $ npm install nswag -g
    ```
5. OpenAPIツールのインストール  
    TODO インストール理由を記載する。
    ```
    $ dotnet tool install --global Microsoft.dotnet-openapi
    ```
6. Amazon.Lambda.Templatesのインストール  
    Lambdaプロジェクトを作成する場合インストールを推奨。
    ```
    $ dotnet new -i Amazon.Lambda.Templates
    ```
7. [Docker本体](https://docs.docker.com/get-docker/)のインストール  
    環境構築にDockerを利用する場合に必要。各コンポーネント(dbやwebappなど)をOS上で直接実行する場合は不要。Docker Desktopのライセンスに注意。
8. [pgAdmin](https://www.pgadmin.org/)   
    UI経由でDBにアクセスする場合インストール。

## ビルド手順
1. git clone  
    開発環境上にソースコードを取得する。
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
    このコマンドを実行することで、以下のファイルを最新の状態に更新する。
    - `~/Client/Helpers/ApiClient.cs`
    - `~/OpenApi/openapi.json`
4. ソリューション全体のビルド
    ```
    $ dotnet build
    ```
5. データベースの構築と起動
    `up` することで`Docker/init/init-user-db.sh`スクリプトが実行され、DBの初期設定が完了する。
    ```
    $ docker compose build postgres
    $ docker compose up -d postgres
    ```
6. データベース起動確認
    DBの初期設定完了まで少し時間がかかるので、起動を確認する。
    ```
    $ docker compose logs postgres
    :
    サーバは停止しました
    PostgreSQL init process complete; ready for start up.
    2022-05-05 16:02:29.291 UTC [1] LOG: PostgreSQL 13.6 (Debian 13.6-1.pgdg110+1) on x86_64-pc-linux-gnu, compiled by gcc (Debian 10.2.1-6) 10.2.1 20210110, 64-bit を起動しています
    2022-05-05 16:02:29.292 UTC [1] LOG: IPv4アドレス"0.0.0.0"、ポート5432で待ち受けています
    2022-05-05 16:02:29.292 UTC [1] LOG: IPv6アドレス"::"、ポート5432で待ち受けています
    2022-05-05 16:02:29.304 UTC [1] LOG: Unixソケット"/var/run/postgresql/.s.PGSQL.5432"で待ち受けています
    2022-05-05 16:02:29.351 UTC [96] LOG: データベースシステムは 2022-05-05 16:02:29 UTC にシャットダウンしました
    2022-05-05 16:02:29.399 UTC [1] LOG: データベースシステムの接続受け付け準備が整いました
    ```
7. データベースの構築
    マイグレーションを実行する。これにより`hoge_blazor`DBが作成され、アプリケーション起動の準備が完了する。
    ```
    $ dotnet ef database update --project ./Server/HogeBlazor.Server.csproj
    ```

## デバッグ
### データベース接続
必要に応じてDBに接続する。
- postgres
    ```
    $ docker compose exec postgres bash
    # psql -U postgres
    postgres=# \l
    postgres=# \c hoge_blazor
    postgres=# \d
    postgres=# \d "Products"
    ```

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
    $ dotnet ef migrations add [マイグレーション名] -o ./Db/Migrations
3. マイグレーションの実行
    ```
    $ dotnet ef database update
    ```
## DBマイグレーションのリセット
開発を進めていて、マイグレーションをイチからやり直したいときに実行する。
1. データベースの削除
    ```
    $ docker compose exec postgres bash
    # psql -U postgres -c 'drop database hoge_blazor'
    ```

2. マイグレーションファイルの削除
    ```
    $ rm ./Server/Db/Migrations/*
    ```
3. マイグレーションの追加
    ```
    $ cd ./Server
    $ dotnet ef migrations add InitialCreate -o ./Db/Migrations
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

## TODO
- 認証機能を入れたことにより、Client.Testが通らなくなっているので修正したい
- `Client/Helpers/ApiClient.cs`や`OpenApi/openapi.json`などの自動生成されるファイルはGit管理から外しておきたい（ビルド時に確実に更新されるのであれば外さなくても良いが）