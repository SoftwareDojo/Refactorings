using System.Globalization;

namespace CSharpRefactorings.Snippets.Refactored
{
    public class ConstructorSnippet
    {
        private readonly CompareInfo m_CompareInfo;
        private readonly CompareOptions m_CompareOptions;

        public ConstructorSnippet()
            : this(CultureInfo.CurrentCulture, CompareOptions.IgnoreCase)
        { }

        public ConstructorSnippet(CultureInfo info, CompareOptions options)
        {
            m_CompareInfo = info.CompareInfo;
            m_CompareOptions = options;
        }
    }
}
