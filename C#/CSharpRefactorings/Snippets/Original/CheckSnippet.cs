using System;

namespace CSharpRefactorings.Snippets.Original
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
            var isUserParamSet = !IsNullOrEmpty(m_User);
            var isUrlParamSet = !IsNullOrEmpty(m_Url);
            var isUrlPathParamSet = !IsNullOrEmpty(m_UrlPath);
            if (m_IsAddNamespaceReservationOption)
            {
                if (isUrlParamSet && isUserParamSet && isUrlPathParamSet)
                {
                    var isValid = validator.ValidateUrl(m_Url) && validator.ValidateUser(m_User)
                        && validator.ValidateUrlPath(m_UrlPath) && validator.ValidatePort(m_Port);
                    if (isValid)
                    {
                        m_Conf.Option = ExecutionOption.AddNamespace;
                        m_Conf.User = m_User;
                        m_Conf.Url = m_Url;
                        m_Conf.Port = m_Port;
                        m_Conf.UrlPath = TrimApostrophes(m_UrlPath);
                    }
                    return isValid;
                }
            }
            return false;
        }

        private static string TrimApostrophes(string path)
        {
            return path.Trim(Convert.ToChar("'"));
        }

        private static bool IsNullOrEmpty(string s)
        {
            if (s == null)
            {
                return true;
            }

            if (s.Length > 0)
            {
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
