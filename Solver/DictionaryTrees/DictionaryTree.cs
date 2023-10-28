using ClassLibrary.Properties;

namespace ClassLibrary.DictionaryTrees;

/// <summary>
/// Builds the dictionary into a tree
/// </summary>
public class DictionaryTree : ISquardleDictionary
{
    private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    // A root node for the dictionary to attach the children for each character of the alphabet
    private DictionaryNode Root { get; } = new(' ');

    public DictionaryTree()
    {
        // Builds the initial 26 character children
        foreach (var character in ALPHABET)
        {
            Root.AddChild(new DictionaryNode(character));
        }

        // Parses the words out of the dictionary and adds them to the tree
        var words = Resources.dictionary.Split('\n');

        foreach (var word in words)
        {
            AddWord(word);
        }
    }

    /// <summary>
    /// Validates a word is in the dictionary
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public bool IsWord(string word)
    {
        // The word is reversed before going in to:
        //  - Be able to just use the .Last() command to get the last value
        //  - Easily remove the last value by creating a substring excluding it, which prevents
        //    having to check (if it was in the right order) if the first letter could be removed safely
        return HasWordRecursively(ReverseWord(word.ToUpper()), Root, false);
    }

    private bool HasWordRecursively(string word, DictionaryNode currentNode, bool isSequenceMatch)
    {
        // End case
        // The word has been exhausted, so is the current node (which is the last letter) a word?
        if (word.Length == 0)
        {
            if (isSequenceMatch)
            {
                return currentNode.IsWord || currentNode.Children.Any();
            }
            else
            {
                return currentNode.IsWord;
            }

        }

        // Check to see if the current node has a child that matches the next letter of the word 
        foreach (var child in currentNode.Children)
        {
            if (child.Value == word.Last())
            {
                return HasWordRecursively(RemoveLast(word), child, isSequenceMatch);
            }
        }

        // No child node found, its not a word
        return false;
    }
    
    private void AddWord(string word)
    {
        // This also reverses the order of a word for the same reasons above
        AddWordRecursively(ReverseWord(word), Root);
    }

    private string ReverseWord(string word)
    {
        return string.Join(string.Empty, word!.ToCharArray().Reverse());
    }

    private void AddWordRecursively(string word, DictionaryNode currentNode)
    {
        bool foundNode = false;

        // End recursion if nothing left to add
        if (word.Length == 0)
        {
            return;
        }

        // Check for existing node first and use that one as the next node
        foreach (var node in currentNode.Children)
        {
            if (node.Value == word.Last())
            {
                AddWordRecursively(RemoveLast(word), node);

                foundNode = true;

                break;
            }
        }

        // If no node was found, add all applicable nodes below immediately 
        if (!foundNode)
        {
            AddNodeTree(word, currentNode);
        }
    }

    private void AddNodeTree(string word, DictionaryNode startNode)
    {
        AddNodeTreeRecursively(word, startNode);
    }

    private void AddNodeTreeRecursively(string word, DictionaryNode currentNode)
    {
        // End case, the word has been exhausted and the current node (the final letter) is set as a word
        if (word.Length == 0)
        {
            currentNode.SetAsWord();

            return;
        }
        else
        {
            var newChild = new DictionaryNode(word.Last());

            AddNodeTreeRecursively(RemoveLast(word), newChild);

            currentNode.AddChild(newChild);
        }
    }

    private string RemoveLast(string word)
    {
        return word[..^1];
    }

    // The exact same thing as HasWord, but can validate if its also a valid sequence
    public bool IsValidSequence(string sequence)
    {
        return HasWordRecursively(ReverseWord(sequence.ToUpper()), Root, true);
    }
}
