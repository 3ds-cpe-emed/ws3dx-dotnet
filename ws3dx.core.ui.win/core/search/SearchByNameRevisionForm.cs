
using System.Reflection;
using ws3dx.core.service;
using ws3dx.utils.search;

namespace ws3dx.core.ui.win.search
{
    public partial class SearchByNameRevisionForm : Form
    {
        private BindingSource m_bindingSource = new BindingSource();

        List<Tuple<string, string>> m_columnPropName = new List<Tuple<string, string>>();

        public SearchService SearchService { get; private set; }

        public string ReturnCollectionPropName { get; private set; }

        public string SearchNameCriteria { get; private set; }
        public string SearchRevisionCriteria { get; private set; }

        public Type SearchMaskType { get; private set; }

        public dynamic? SelectedItem
        {
            get
            {
                if ((m_searchResultsGridView.SelectedRows == null) || (m_searchResultsGridView.SelectedRows.Count == 0))
                {
                    return null;
                }
                else
                {
                    return m_searchResultsGridView.SelectedRows[0].DataBoundItem;
                }
            }
        }

        private void InitializeColumnAndPropertyNames(ref List<Tuple<string, string>> _columnPropName)
        {
            _columnPropName.Add(new Tuple<string, string>("id", "Physical Id"));
            _columnPropName.Add(new Tuple<string, string>("name", "Name"));
            _columnPropName.Add(new Tuple<string, string>("title", "Title"));
            _columnPropName.Add(new Tuple<string, string>("revision", "Revision"));
            _columnPropName.Add(new Tuple<string, string>("collabspace", "Collab.Space"));
            _columnPropName.Add(new Tuple<string, string>("owner", "Owner"));
            _columnPropName.Add(new Tuple<string, string>("state", "State"));
            _columnPropName.Add(new Tuple<string, string>("created", "Created"));
            _columnPropName.Add(new Tuple<string, string>("modified", "Modified"));
        }

        private void InitializeGridColumns(DataGridView _datagridView, List<Tuple<string, string>> _columnPropNameList)
        {
            foreach (Tuple<string, string> columnPropName in _columnPropNameList)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = columnPropName.Item1;
                column.Name = columnPropName.Item2;
                _datagridView.Columns.Add(column);
            }
        }

        public SearchByNameRevisionForm(SearchService _searchService, Type _searchMaskType, string _nameSearchCriteria = "", string _revSearchCriteria = "*", string _returnCollectionPropName = "member")
        {
            InitializeComponent();

            m_searchResultsGridView.AutoGenerateColumns = false;
            m_searchResultsGridView.DataSource = m_bindingSource;

            InitializeColumnAndPropertyNames(ref m_columnPropName);

            m_bindingSource.AllowNew = false;
            InitializeGridColumns(m_searchResultsGridView, m_columnPropName);

            SearchService = _searchService;

            ReturnCollectionPropName = _returnCollectionPropName;

            SearchNameCriteria = _nameSearchCriteria;
            SearchRevisionCriteria = _revSearchCriteria;

            m_nameTextBox.Text = SearchNameCriteria;
            m_revisionTextBox.Text = SearchRevisionCriteria;

            SearchMaskType = _searchMaskType;
        }

        private async void m_searchButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                m_bindingSource.Clear();

                // Search Name Criteria

                string searchName = m_nameTextBox.Text;

                searchName = searchName.Trim();

                if (searchName.Length < 3)
                {
                    MessageBox.Show("Name criteria needs to be greater or equal to 3 characters");
                    return;
                }

                SearchNameCriteria = searchName;

                // Search Revision Criteria

                SearchRevisionCriteria = m_revisionTextBox.Text;

                SearchByNameRevision searchByNameRevision = new SearchByNameRevision(searchName, SearchRevisionCriteria);

                MethodInfo? searchMethod = SearchService.GetType()
                                 .GetMethod("SearchCollection",
                                             BindingFlags.Instance | BindingFlags.Public, [typeof(string), typeof(SearchQuery)]);

                if (searchMethod == null)
                {
                    throw new Exception("Cannot find SearchCollection method");
                }

                MethodInfo searchMethodGeneric = searchMethod.MakeGenericMethod(SearchMaskType);

                if (searchMethodGeneric == null)
                {
                    throw new Exception("SearchCollection method found is not generic");
                }

                dynamic searchInvokeReturn = searchMethodGeneric.Invoke(SearchService, [ReturnCollectionPropName, searchByNameRevision]);

                if (searchInvokeReturn == null)
                {
                    throw new Exception("SearchCollection method invoke failed");
                }

                await searchInvokeReturn;

                dynamic searchInvokeResult = searchInvokeReturn.GetAwaiter().GetResult();

                if ((searchInvokeResult == null) || (searchInvokeResult.Count == 0))
                {
                    MessageBox.Show("No results found.", "Search Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var item in searchInvokeResult)
                {
                    m_bindingSource.Add(item);
                }
            }
            catch (Exception _ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(_ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void m_searchResultsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_searchResultsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_searchResultsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
