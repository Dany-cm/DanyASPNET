namespace DanyTCG.Models;

public interface ICanValidate
{
    Dictionary<string, string> ModelErrors { get; }
    bool Validate();
}