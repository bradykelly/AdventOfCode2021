using System.Collections;
// ReSharper disable InvalidXmlDocComment

namespace AdventOfCode.Graphs;

/// <summary>
/// The NodeList class represents a collection of nodes.  Internally, it uses a Hashtable instance to provide
/// fast lookup via a <typeparamref name="TNode"/> class's <b>Key</b> value.  The <see cref="Graph"/> class maintains its
/// list of nodes via this class.
/// </summary>
public class NodeList<TNode> : IEnumerable where TNode : INode<TNode>
{
    // private member variables
    private Hashtable data = new Hashtable();

    /// <summary>
    /// Adds a new Node to the NodeList.
    /// </summary>
    public virtual void Add(TNode n)
    {
        data.Add(n.Key!, n);
    }

    /// <summary>
    /// Removes a Node from the NodeList.
    /// </summary>
    public virtual void Remove(TNode n)
    {
        data.Remove(n.Key!);
    }

    /// <summary>
    /// Determines if a node with a specified <b>Key</b> value exists in the NodeList.
    /// </summary>
    /// <param name="key">The <b>Key</b> value to search for.</param>
    /// <returns><b>True</b> if a Node with the specified <b>Key</b> exists in the NodeList; <b>False</b> otherwise.</returns>
    public virtual bool ContainsKey(string? key)
    {
        return data.ContainsKey(key!);
    }

    /// <summary>
    /// Clears out all of the nodes from the NodeList.
    /// </summary>
    public virtual void Clear()
    {
        data.Clear();
    }

    /// <summary>
    /// Returns an enumerator that can be used to iterate through the Nodes.
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator()
    {
        return new NodeListEnumerator(data.GetEnumerator());
    }

    /// <summary>
    /// Returns a particular <typeparamref name="TNode"/> instance by index.
    /// </summary>
    public virtual TNode this[string? key] => (TNode)data[key!]!;

    /// <summary>
    /// Returns the number of nodes in the NodeList.
    /// </summary>
    public virtual int Count => data.Count;

    /// <summary>
    /// The NodeListEnumerator method is a custom enumerator for the NodeList object.  It essentially serves
    /// as an enumerator over the NodeList's Hashtable class, but rather than returning DictionaryEntry values,
    /// it returns just the Node object.
    /// <p />
    /// This allows for a developer using the Graph class to use a foreach to enumerate the Nodes in the graph.
    /// </summary>
    public class NodeListEnumerator : IEnumerator, IDisposable
    {
        private IDictionaryEnumerator _list;

        public NodeListEnumerator(IDictionaryEnumerator coll)
        {
            _list = coll;
        }

        public void Reset()
        {
            _list.Reset();
        }

        public bool MoveNext()
        {
            return _list.MoveNext();
        }

        public TNode Current => (TNode)((DictionaryEntry)_list.Current).Value!;

        // The current property on the IEnumerator interface:
        object IEnumerator.Current => (Current);

        public void Dispose()
        {
            _list = null!;
        }
    }
}