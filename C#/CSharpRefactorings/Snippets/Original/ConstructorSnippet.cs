using System.Globalization;

namespace CSharpRefactorings.Snippets.Original
{
    public class ConstructorSnippet
    {
        private CompareInfo m_CompareInfo;
        private System.Globalization.CompareOptions m_CompareOptions;

        public ConstructorSnippet(CultureInfo current)
        {
            if (current != null)
            {
                this.m_CompareInfo = current.CompareInfo;
            }
            else
            {
                this.m_CompareInfo = CultureInfo.CurrentCulture.CompareInfo;
            }
            this.m_CompareOptions = System.Globalization.CompareOptions.IgnoreCase;
        }
    }
}
