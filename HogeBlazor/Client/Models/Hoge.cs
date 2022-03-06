using Shared.Helpers;

namespace HogeBlazor.Client.Models;
public class Hoge {
    public string Name {get; set;} = default!;

    public bool Validate(string hoge) {
        Fuga.Hello();
        return true;
    }
}