#region #usings
using System.Windows;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Menu;
using DevExpress.Xpf.RichEdit.Menu;
#endregion #usings


namespace DXRichEdit_HoverMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            richEditControl1.Loaded += new RoutedEventHandler(richEditControl1_Loaded);
            richEditControl1.HoverMenuShowing += new HoverMenuShowingEventHandler(richEditControl1_HoverMenuShowing);
        }


        void richEditControl1_Loaded(object sender, RoutedEventArgs e)
        {
            richEditControl1.LoadDocument("sample_document.docx", DocumentFormat.OpenXml);
        }

        #region #hovermenushowing
        void richEditControl1_HoverMenuShowing(object sender, HoverMenuShowingEventArgs e)
        {
            // Remove DecreaseIndent and IncreaseIndent command menu items.
            for (int i = 0; i < e.Menu.ItemsCount; i++) {
                BarItemLink bLink = (BarItemLink)e.Menu.ItemLinks[i];
                RichEditUICommand cmd = (RichEditUICommand)bLink.Item.Command;
                if (cmd.CommandId == RichEditCommandId.DecreaseIndent 
|| cmd.CommandId == RichEditCommandId.IncreaseIndent)
                    e.Menu.ItemLinks.Remove(bLink); 
            }
            // Add a separator.
            BarItemLinkSeparator itemSep = new BarItemLinkSeparator();
            e.Menu.ItemLinks.Add(itemSep);
            // Create a new menu item and add it to the hover menu.
            RichEditMenuItem item1 = new RichEditMenuItem();
            item1.Content = "Replace Emoticon with Smiley";
            MySmileyCommand cmd_toAdd = new MySmileyCommand(richEditControl1);
            item1.Command = cmd_toAdd;
            item1.Glyph = cmd_toAdd.Glyph;
            e.Menu.ItemLinks.Add(item1);
        }
        #endregion #hovermenushowing
    }
    }
