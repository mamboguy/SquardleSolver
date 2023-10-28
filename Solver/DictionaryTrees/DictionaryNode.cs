namespace ClassLibrary.DictionaryTrees;

/// <summary>
/// A node in the dictionary.  Children indicate that it is part of a longer word and it may be set as a word itself
/// </summary>
internal class DictionaryNode
{
    public char Value { get; init; }
    public bool IsWord { get; private set; } = false;
    public List<DictionaryNode> Children { get; private set; } = new();

    public DictionaryNode(char character)
    {
        Value = character.ToString().ToUpper()[0];
    }

    public void AddChild(DictionaryNode node)
    {
        Children.Add(node);
    }

    public void SetAsWord()
    {
        IsWord = true;
    }
}
