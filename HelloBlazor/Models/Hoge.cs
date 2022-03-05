using CommonLib.Helpers;

namespace HelloBlazor.Models;
public class Hoge {
    public string Name {get; set;} = default!;

    public bool Validate(string hoge) {
        Fuga.Hello();
        return true;
    }
}