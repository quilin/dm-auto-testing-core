namespace Core.Elements.Searchers
{
    public interface ISearchable
    {
        IElementGetter Get { get; }
        IElementFinder Find { get; }
    }
}