﻿using System.Windows.Controls;

namespace FrozenSoftware
{
    /// <summary>
    /// Interaction logic for Country.xaml
    /// </summary>
    public partial class CountryTab : TabItem
    {
        public CountryTab()
        {
            InitializeComponent();
        }

        public string ParetViewName { get; set; } = nameof(HomeRibbonTabItem);
    }
}
