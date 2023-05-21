using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediChart
{
    internal class ClassWord
    {
        private readonly FileInfo _fileInfo;

        public ClassWord(string fileName)
        {

            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("Файл не найден");
            }
        }

        internal void Process(Dictionary<string, string> items)
        {
            Microsoft.Office.Interop.Word.Application app = null;
      
            app = new Microsoft.Office.Interop.Word.Application();

                object file = _fileInfo.FullName;

                object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (KeyValuePair<string, string> item in items)
                {

                    Microsoft.Office.Interop.Word.Find find = app.Selection.Find;

                    find.Text = item.Key;

                    find.Replacement.Text = item.Value;

                    object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;

                    object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace);
                }

                object newFileName = Path.Combine("C:/Documents/Справки", DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss ") + _fileInfo.Name);

                app.ActiveDocument.SaveAs2(newFileName);

                app.ActiveDocument.Close();

            MessageBox.Show("Успешное создание файла.","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
