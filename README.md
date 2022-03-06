## プロジェクトの追加
- プロジェクトの作成
    ```
    $ cd ~/blazor-example
    $ dotnet new classlib -o CommonLib
    ```
- プロジェクトをソリューションに追加
    ```
    $ dotnet sln add CommonLib/CommonLib.csproj
    ```
## テストプロジェクトの追加
- テストプロジェクトの作成
    ```
    $ cd ~/blazor-example
    $ dotnet new xunit -o CommonLib.Test
    ```
- テスト対象プロジェクトへの参照追加
    ```
    $ dotnet add CommonLib.Test/CommonLib.Test.csproj reference CommonLib/CommonLib.csproj
    ```
- テストプロジェクトをソリューションに追加
    ```
    $ dotnet sln add CommonLib.Test/CommonLib.Test.csproj
    ```
## 実行
```
$ dotnet run --project HelloBlazor/HelloBlazor.csproj
```
## テスト
```
$ dotnet test
```
