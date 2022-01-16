namespace XMLEditor.ViewModel
{
    internal class TreeComparisonViewModel : ViewModelBase
    {
        private string m_LeftTreeName;
        private string m_RightTreeName;

        public string LeftTreeName
        {
            get => m_LeftTreeName;
            set => SetField(ref m_LeftTreeName, value, () => LeftTreeName);
        }

        public string RightTreeName
        {
            get => m_RightTreeName;
            set => SetField(ref m_RightTreeName, value, () => RightTreeName);
        }

        public TreeComparisonViewModel()
        {
            Init();
        }

        public void Init()
        {
            m_LeftTreeName = "Tree 1";
            m_RightTreeName = "Tree 2";
        }
    }
}