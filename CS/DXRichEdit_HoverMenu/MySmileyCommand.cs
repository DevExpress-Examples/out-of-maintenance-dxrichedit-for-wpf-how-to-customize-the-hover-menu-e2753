#region #usingsincommands
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
#endregion #usingsincommands

namespace DXRichEdit_HoverMenu
{
    class MySmileyCommand : ICommand
    {
        private readonly IRichEditControl control;
        private readonly ImageSource glyph;
        private readonly Image smile;

        public MySmileyCommand(IRichEditControl control)
        {
            this.control = control;
            this.glyph = CreateImageSourceFromResx("smile.png");
            this.smile = CreateImageFromResx("smile.png");
        }


        public ImageSource Glyph
        {
            get { return glyph; }
        }


        private ImageSource CreateImageSourceFromResx(string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            BitmapImage bi = new BitmapImage();
            using (Stream stream = assembly.GetManifestResourceStream("DXRichEdit_HoverMenu.Images." + name))
            {
                bi.BeginInit();
                bi.StreamSource = stream;
                bi.EndInit();
            }
            return (ImageSource)bi;
        }

        private Image CreateImageFromResx(string name)
        {
            Image im;
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("DXRichEdit_HoverMenu.Images." + name))
            {
                im = Image.FromStream(stream);
            }
            return im;
        }

        protected internal IRichEditControl Control
        {
            get
            {
                return this.control;
            }
        }

        
        public bool CanExecute(object parameter) 
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
            }
            remove
            {
            }
        }
 
        public void Execute(object parameter)
        {
            #region #findall
    Document doc = Control.Document;
    DocumentRange range = doc.Selection;
    DocumentRange[] smileyRanges = doc.FindAll(":-)", SearchOptions.WholeWord, range);
    foreach (DocumentRange r in smileyRanges) {
        doc.Delete(r);
        doc.Images.Insert(r.Start, smile);
    }
            #endregion #findall
        }

    }
}
