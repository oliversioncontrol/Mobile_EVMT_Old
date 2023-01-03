using OnLocationEVMT.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
//using Plugin.Media;
//using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Helpers
{
    /// <summary> 
    /// Initializes a new instance of the System.Collections.ObjectModel.PhotoCapture(Of T) class. 
    /// </summary> 
    class PhotoCapture
    {
        public bool SizeExceeded;
        public bool DeviceError;
        public GroupPostImage CapturedImage;
    }

    static class PhotoHelper
    {
        const int MB = 1024 * 1024;

        public static async Task<PhotoCapture> TakePhoto()
        {
            PhotoCapture photo = new PhotoCapture();

            GroupPostImage newImg = null;
            try
            {
                await CrossMedia.Current.Initialize();
                newImg = new GroupPostImage();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    photo.DeviceError = true;                    
                    return photo;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Rear
                });

                if (file.GetStream().Length > GroupSeed.AllowedImageSize * MB)
                {
                    file.Dispose();
                    //if (FileSizeExceededEvent != null)
                    //    FileSizeExceededEvent(GroupSeed.AllowedImageSize);
                    photo.SizeExceeded = true;
                    return photo;
                }

                //newImg = new GroupPostImage();

                //get file name
                var filePath = file.Path;
                filePath = filePath.Split('/').Last();
                newImg.Name = filePath;

                //get file data
                var stream = file.GetStream();
                using (MemoryStream ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    newImg.ImageData = ms.ToArray();
                }

                //Dispose file
                file.Dispose();

                newImg.Image = ImageSource.FromStream(() =>
                {
                    return new MemoryStream(newImg.ImageData);
                });

                photo.CapturedImage = newImg;

                //Images.Insert(0, newImg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.InnerException);
            }

            return photo;
        }

        public static async Task<PhotoCapture> ChoosePhoto()
        {
            PhotoCapture photo = new PhotoCapture();

            GroupPostImage newImg = null;
            try
            {
                await CrossMedia.Current.Initialize();
                newImg = new GroupPostImage();
                if (!CrossMedia.Current.IsTakePhotoSupported)
                {
                    photo.DeviceError = true;
                    return photo;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 50
                });

                //if (file.GetStream().Length > GroupSeed.AllowedImageSize * MB)
                //{
                //    photo.SizeExceeded = true;
                //    return photo;
                //}

                //newImg = new GroupPostImage();

                //get file name
                var filePath = file.Path;
                filePath = filePath.Split('/').Last();
                newImg.Name = filePath;

                //get file data
                var stream = file.GetStream();
                using (MemoryStream ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    newImg.ImageData = ms.ToArray();
                }

                //Dispose file
                file.Dispose();

                newImg.Image = ImageSource.FromStream(() =>
                {
                    return new MemoryStream(newImg.ImageData);
                });

                photo.CapturedImage = newImg;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.InnerException);
            }

            return photo;
        }

        public static async Task<int> UploadPhoto(GroupPostImage img)
        {
            int nFileId = 0;
            img.Uploading = true;
            //FileServiceProvider filProv = new FileServiceProvider();
            //nFileId = await filProv.UploadFile(img);
            nFileId = 1;
            img.Uploading = false;

            return nFileId;
        }

        //public static async Task<bool> DeleteFile(GroupPostImage img)
        //{
        //    bool bSuccess = false;
        //    img.Uploading = true;

        //    FileServiceProvider fileProv = new FileServiceProvider();
        //    bSuccess = await fileProv.DeleteFile(img.ImageId, GroupSeed.GroupId);
        //    if (bSuccess)
        //    {
        //        //Images.Remove(img);
        //        img.ImageData = null;
        //    }

        //    img.Uploading = false;

        //    return bSuccess;
        //}
    }
}
