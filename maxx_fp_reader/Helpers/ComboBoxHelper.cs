using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace maxx_pos.Helpers
{
    public static class ComboBoxHelper
    {
        public static void Populate(ComboBox comboBox, List<string> items, string defaultValue = "")
        {
            comboBox.Items.Clear();

            if (items == null || items.Count == 0)
            {
                comboBox.Enabled = false;
                return;
            }

            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }

            comboBox.Enabled = true;

            if (!string.IsNullOrEmpty(defaultValue) && items.Contains(defaultValue))
                comboBox.SelectedItem = defaultValue;
            else if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        public static void PopulateWithYears(ComboBox comboBox, int startYear, int endYear, int? defaultYear = null)
        {
            comboBox.Items.Clear();
            for (int y = startYear; y <= endYear; y++)
            {
                comboBox.Items.Add(y);
            }

            int yearToSelect = defaultYear ?? DateTime.Now.Year;
            if (comboBox.Items.Contains(yearToSelect))
                comboBox.SelectedItem = yearToSelect;
            else
                comboBox.SelectedIndex = 0;
        }

        public static void PopulateWithMonths(ComboBox comboBox, int? defaultMonth = null)
        {
            comboBox.Items.Clear();
            for (int m = 1; m <= 12; m++)
            {
                comboBox.Items.Add(m);
            }

            int monthToSelect = defaultMonth ?? DateTime.Now.Month;
            comboBox.SelectedItem = monthToSelect;
        }

        public static void PopulateWithPrinters(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBox.Items.Add(printer);
            }

            string defaultPrinter = new PrinterSettings().PrinterName;
            comboBox.SelectedItem = defaultPrinter;
        }
    }
}