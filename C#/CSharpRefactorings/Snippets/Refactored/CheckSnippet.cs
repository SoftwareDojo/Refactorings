using System;

namespace CSharpRefactorings.Snippets.Refactored
{
    public class CheckSnippet
    {
        private string m_User;
        private string m_Url;
        private string m_UrlPath;
        private bool m_IsAddNamespaceReservationOption;
        private Validator validator;
        private int m_Port;
        private Config m_Conf;

        private bool CheckAddNamespaceReservationParamters()
        {
            if (string.IsNullOrEmpty(m_User)) return false;
            if (string.IsNullOrEmpty(m_Url)) return false;
            if (string.IsNullOrEmpty(m_UrlPath)) return false;
            if (!m_IsAddNamespaceReservationOption) return false;

            if (validator.ValidateUrl(m_Url) && validator.ValidateUser(m_User) &&
                validator.ValidateUrlPath(m_UrlPath) && validator.ValidatePort(m_Port))
            {
                m_Conf.Option = ExecutionOption.AddNamespace;
                m_Conf.User = m_User;
                m_Conf.Url = m_Url;
                m_Conf.Port = m_Port;
                m_Conf.UrlPath = m_UrlPath.Trim(Convert.ToChar("'"));
                return true;
            }

            return false;
        }
    }

    #region Sample classes
    public class Validator
    {
        public bool ValidateUrl(string url)
        {
            return true;
        }

        public bool ValidateUser(string user)
        {
            return true;
        }

        public bool ValidateUrlPath(string urlPath)
        {
            return true;
        }

        public bool ValidatePort(int port)
        {
            return true;
        }
    }

    public class Config
    {
        public string User { get; set; }
        public string Url { get; set; }
        public string UrlPath { get; set; }
        public int Port { get; set; }
        public ExecutionOption Option { get; set; }
    }

    public enum ExecutionOption
    {
        AddNamespace
    }
    #endregion
}
