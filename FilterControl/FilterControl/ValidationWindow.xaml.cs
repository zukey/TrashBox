using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Diagnostics;


namespace FilterControl
{
    /// <summary>
    /// ValidationWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ValidationWindow : Window
    {
        public ValidationWindow()
        {
            InitializeComponent();
            layoutRoot.BindingGroup.BeginEdit();
        }

        public ValidationWindowViewModel ViewModel
        {
            get { return this.Resources["vm"] as ValidationWindowViewModel; }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            text1.Text = text1.Text;
            date1.SelectedDate = date1.SelectedDate;
            if (!layoutRoot.BindingGroup.CommitEdit())
            {
                Debug.WriteLine("CommitEdit False");
            }
            if (layoutRoot.BindingGroup.HasValidationError || layoutRoot.BindingGroup.IsDirty)
            {
                Debug.WriteLine("汚い豚め！！！");
            }
            layoutRoot.BindingGroup.BeginEdit();
        }
    }


    public class ValidationWindowViewModel
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public DateTime? Date1 { get; set; }

        public ValidationWindowViewModel()
        {

        }
    }


    public class IntInputTextValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int iValue;
            if (!(value is int))
            {
                string s = value as string;
                if (string.IsNullOrEmpty(s))
                {
                    if (Required) { return new ValidationResult(false, "必須項目です"); }
                    else { return ValidationResult.ValidResult; }
                }

                if (!int.TryParse(s, out iValue))
                {
                    return new ValidationResult(false, "数値入れろ");
                }
            }
            else
            {
                iValue = (int)value;
            }

            if (MinValue.HasValue)
            {
                if (iValue < MinValue.Value) { return new ValidationResult(false, "ちっさすぎ"); }
            }
            if (MaxValue.HasValue)
            {
                if (iValue > MaxValue.Value) { return new ValidationResult(false, "でかすぎ"); }
            }

            return ValidationResult.ValidResult;
        }

        public bool Required { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

    }

    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            DateTime d;
            if (value is DateTime)
            {
                d = (DateTime)value;
            }
            else
            {
                var s = value as string;
                if (string.IsNullOrEmpty(s))
                {
                    if (Required) { return new ValidationResult(false, "必須項目です"); }
                    else { return ValidationResult.ValidResult; }
                }

                if (!DateTime.TryParse(s ,out d))
                {
                    return new ValidationResult(false, "日付入れろ");
                }
            }

            return ValidationResult.ValidResult;
        }

        public bool Required { get; set; }
    }

    public class GroupValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            return ValidationResult.ValidResult;
        }
    }
}
