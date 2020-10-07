﻿using System;
using System.Windows.Forms;
using Diz.Core.model;
using Diz.Core.serialization;
using Diz.Core.util;

namespace DiztinGUIsh.window.dialog
{
    public partial class TestForm : Form
    {
        public ImportRomSettings settings = new ImportRomSettings()
        {
            ROMMapMode = Data.ROMMapMode.SuperFX
        };

        public TestForm()
        {
            InitializeComponent();

            // common for everything on the page
            project_ImportRomSettingsBindingSource.DataSource = settings;

            // specific to this combo. datasource is a static list of enum values
            var dataSource = Util.GetEnumDescriptions<Data.ROMMapMode>();
            rOMMapModeComboBox.DataSource = new BindingSource(dataSource, null);
            rOMMapModeComboBox.ValueMember = "Key";         // names of properties of each item on datasource.
            rOMMapModeComboBox.DisplayMember = "Value";

            // bind comboboxes "SelectedIndex" property to store its value in settings.ROMMapMode
            rOMMapModeComboBox.DataBindings.Add(new Binding("SelectedIndex", settings, "ROMMapMode", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void rOMMapModeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // force the control to flush the new value to the
            // datasource as soon as you click on it.
            Validate(true); 
        }
    }
}
