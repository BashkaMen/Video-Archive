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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoArchive.App.Controls
{
    /// <summary>
    /// Логика взаимодействия для EditableTextBox.xaml
    /// </summary>
    public partial class EditableTextBox : UserControl
    {

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBox), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }
        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(EditableTextBox), new FrameworkPropertyMetadata(TextWrapping.NoWrap, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }
        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(EditableTextBox), new FrameworkPropertyMetadata(TextAlignment.Left, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public EditableTextBox()
        {
            InitializeComponent();

            textBox.Visibility = Visibility.Hidden;

            textBlock.MouseDown += (s, e) =>
            {
                if (e.ClickCount >= 2)
                {
                    textBlock.Visibility = Visibility.Hidden;
                    textBox.Visibility = Visibility.Visible;
                }
            };

            textBox.MouseDoubleClick += (s, e) =>
            {
                textBox.Visibility = Visibility.Hidden;
                textBlock.Visibility = Visibility.Visible;
            };

        }
    }
}
