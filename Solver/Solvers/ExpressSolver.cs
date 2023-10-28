using ClassLibrary.DictionaryTrees;

namespace ClassLibrary.Solvers;

internal class ExpressSolver : BaseSquardleSolver
{
    public ExpressSolver(string? values, ISquardleDictionary dictionary) : base(values, dictionary)
    {
    }

    protected override int GetGridSize() => 3;        
}