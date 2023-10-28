using ClassLibrary.DictionaryTrees;

namespace ClassLibrary.Solvers;

internal class StandardSolver : BaseSquardleSolver
{
    public StandardSolver(string? values, ISquardleDictionary dictionary) : base(values, dictionary)
    {
    }

    protected override int GetGridSize() => 4;       
}