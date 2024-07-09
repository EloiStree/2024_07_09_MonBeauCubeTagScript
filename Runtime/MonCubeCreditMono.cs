using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCubeCreditMono : MonoBehaviour
{
    public string m_firstName = "";
    public string m_lastName = "";
    public string m_portfolioUrl;
    public string m_githubUrl;
    public string m_linkedinUrl;

    [ContextMenu("Open Portfolio")]
    public void OpenPortfolio()
    {
        Application.OpenURL(m_portfolioUrl);
    }
    [ContextMenu("Open Github")]
    public void OpenGithub()
    {
        Application.OpenURL(m_githubUrl);
    }
    [ContextMenu("Open Linkedin")]
    public void OpenLinkedin()
    {
        Application.OpenURL(m_linkedinUrl);
    }
    [ContextMenu("Open Google Search")]
    public void OpenGoogleSearch()
    {
        Application.OpenURL("https://www.google.com/search?q=" + m_firstName + "+" + m_lastName);
    }
    [ContextMenu("Open All")]
    public void OpenAll()
    {
        OpenPortfolio();
        OpenGithub();
        OpenLinkedin();
        OpenGoogleSearch();
    }
}
