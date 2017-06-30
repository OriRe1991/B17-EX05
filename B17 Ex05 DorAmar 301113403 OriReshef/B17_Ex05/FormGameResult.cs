using System;
using System.Windows.Forms;

namespace B17_Ex05
{
    public class FormGameResult : Form
    {
        private TextBox m_ResultLabel;

        public FormGameResult()
        {
            ResultLabel = new TextBox();
        }

        public TextBox ResultLabel { get => m_ResultLabel; set => m_ResultLabel = value; }
    }
}