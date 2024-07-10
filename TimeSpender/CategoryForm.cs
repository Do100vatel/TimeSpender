using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class CategoryForm : Form
    {
        public event EventHandler CategoryListChanged;
        private List<string> categories;

        public CategoryForm(List<string> existingCategories)
        {
            InitializeComponent();
            categories = new List<string>(existingCategories);
            UpdateCategoryListBox();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var newCategory = txtNewCategory.Text.Trim();
            if (!string.IsNullOrEmpty(newCategory) && !categories.Contains(newCategory))
            {
                categories.Add(newCategory);
                UpdateCategoryListBox();
                CategoryListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem != null)
            {
                categories.Remove(lstCategories.SelectedItem.ToString());
                UpdateCategoryListBox();
                CategoryListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UpdateCategoryListBox()
        {
            lstCategories.Items.Clear();
            lstCategories.Items.AddRange(categories.ToArray());
        }
    }
}
