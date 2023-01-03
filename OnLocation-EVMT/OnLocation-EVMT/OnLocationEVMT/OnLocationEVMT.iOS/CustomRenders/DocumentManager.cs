using System;
using System.IO;
using Foundation;
using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.iOS.CustomRenders;
using QuickLook;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentManager))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class DocumentManager:IDocumentManager
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="sFileName"></param>
        public void SaveFile(byte[] rawData, string strFileName)
        {
            try
            {
                string directoryIos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string file = Path.Combine(directoryIos, strFileName);
                File.WriteAllBytes(file, rawData);

                if (File.Exists(file))
                {
                    Console.Write("Exist");
                }

                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                QLPreviewItemBundle prevItem = new QLPreviewItemBundle(strFileName, directoryIos);
                QLPreviewController previewController = new QLPreviewController();
                previewController.DataSource = new PreviewControllerDS(prevItem);

                UIWindow oUIWindow = UIApplication.SharedApplication.KeyWindow;
                UIViewController oUIViewController = oUIWindow.RootViewController;

                while (oUIViewController.PresentedViewController != null)
                {
                    oUIViewController = oUIViewController.PresentedViewController;
                }

                oUIViewController.PresentViewController(previewController, true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        #region implemented abstract members of QLPreviewControllerDataSource

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return _item;
        }

        #endregion

        private QLPreviewItem _item;

        public PreviewControllerDS(QLPreviewItem item)
        {
            _item = item;
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }

        public QLPreviewItem GetPreviewItem(QLPreviewController controller, int index)
        {
            return _item;
        }
    }
    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        string _fileName, _filePath;

        public QLPreviewItemFileSystem(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl ItemUrl
        {
            get
            {
                return NSUrl.FromFilename(_filePath);
            }
        }
    }

    public class QLPreviewItemBundle : QLPreviewItem
    {
        string _fileName, _filePath;
        public QLPreviewItemBundle(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }

        public override NSUrl ItemUrl
        {
            get
            {
                String sFilePath = Path.Combine(_filePath, _fileName);
                return NSUrl.FromFilename(sFilePath);

            }
        }
    }
}

