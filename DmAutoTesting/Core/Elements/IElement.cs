namespace Core.Elements
{
    public interface IElement
    {
        bool Exists { get; }

        string TagName { get; }
        bool Visible { get; }
        int Height { get; }
        int Width { get; }
        string Text { get; }

        void Click();
        void ScrollTo();
        void HoverMouse();
        void HoverClick();
        string GetAttribute(string name);
        bool HasAttribute(string name);
    }
}