private System.Windows.Forms.ListBox lstCategories;
private System.Windows.Forms.TextBox txtNewCategory;
private System.Windows.Forms.Button btnAddCategory;
private System.Windows.Forms.Button btnRemoveCategory;

private void InitializeComponent()
{
    this.lstCategories = new System.Windows.Forms.ListBox();
    this.txtNewCategory = new System.Windows.Forms.TextBox();
    this.btnAddCategory = new System.Windows.Forms.Button();
    this.btnRemoveCategory = new System.Windows.Forms.Button();
    this.SuspendLayout();

    // 
    // lstCategories
    // 
    this.lstCategories.FormattingEnabled = true;
    this.lstCategories.Location = new System.Drawing.Point(12, 12);
    this.lstCategories.Name = "lstCategories";
    this.lstCategories.Size = new System.Drawing.Size(200, 160);
    this.lstCategories.TabIndex = 0;

    // 
    // txtNewCategory
    // 
    this.txtNewCategory.Location = new System.Drawing.Point(12, 190);
    this.txtNewCategory.Name = "txtNewCategory";
    this.txtNewCategory.Size = new System.Drawing.Size(200, 20);
    this.txtNewCategory.TabIndex = 1;

    // 
    // btnAddCategory
    // 
    this.btnAddCategory.Location = new System.Drawing.Point(12, 220);
    this.btnAddCategory.Name = "btnAddCategory";
    this.btnAddCategory.Size = new System.Drawing.Size(75, 23);
    this.btnAddCategory.TabIndex = 2;
    this.btnAddCategory.Text = "Add";
    this.btnAddCategory.UseVisualStyleBackColor = true;
    this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);

    // 
    // btnRemoveCategory
    // 
    this.btnRemoveCategory.Location = new System.Drawing.Point(137, 220);
    this.btnRemoveCategory.Name = "btnRemoveCategory";
    this.btnRemoveCategory.Size = new System.Drawing.Size(75, 23);
    this.btnRemoveCategory.TabIndex = 3;
    this.btnRemoveCategory.Text = "Remove";
    this.btnRemoveCategory.UseVisualStyleBackColor = true;
    this.btnRemoveCategory.Click += new System.EventHandler(this.btnRemoveCategory_Click);

    // 
    // CategoryForm
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(224, 261);
    this.Controls.Add(this.btnRemoveCategory);
    this.Controls.Add(this.btnAddCategory);
    this.Controls.Add(this.txtNewCategory);
    this.Controls.Add(this.lstCategories);
    this.Name = "CategoryForm";
    this.Text = "Category Settings";
    this.ResumeLayout(false);
    this.PerformLayout();
}
