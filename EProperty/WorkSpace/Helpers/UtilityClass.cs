using EProperty.WorkSpace.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace EProperty.WorkSpace.Helpers
{
    public class UtilityClass
    {
        public static ResGeneric GetResponse(string Status, string Message, string Id)
        {
            ResGeneric ResGeneric = new ResGeneric
            {
                status = Status,
                message = Message,
                id = Id
            };
            return ResGeneric;
        }

        public static bool IsNull(string val)
        {
            if (val == null || val.Trim() == "" || val.Trim() == "null")
                return true;
            else return false;
        }

        public static string GetTime(DateTime time)
        {
            try
            {
                TimeSpan remainder = DateTime.UtcNow - time;
                var days = remainder.Days;
                var hours = remainder.Hours;
                var minutes = remainder.Minutes;
                var seconds = remainder.TotalMilliseconds;
                if (seconds > 0)
                    return seconds.ToString();

            }
            catch (Exception e) { Logger.Log("", "UtilityClass", "GetTime", e.Message); }
            return "";
        }

        public static string StreamToImage(Stream image, string path)
        {
            var uploadFolder = "/uploadFolder/" + path;
            try
            {
                String virtualPath = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
                String serveMapPath = System.Web.Hosting.HostingEnvironment.MapPath(virtualPath + uploadFolder);
                var strFileName = Guid.NewGuid() + "i";
                var dbpath = uploadFolder + strFileName;
                var isExist = Directory.Exists(serveMapPath);
                if (!isExist)
                    Directory.CreateDirectory(serveMapPath);
                var filePath = Path.Combine(serveMapPath, strFileName + ".jpeg");
                // Convert Base64 String to byte[]

                byte[] data = ToByteArray(image);

                File.WriteAllBytes(filePath, data);
                ResizeImage(filePath);
                return dbpath;
            }
            catch (Exception e) { Logger.Log(path, "UtilityClass", "StreamToImage", e.Message); }

            return null;
        }

        public static byte[] ToByteArray(Stream stream)
        {

            byte[] buffer = new byte[99999999];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }

            }

        }

        private static void ResizeImage(string filename)
        {
            try
            {
                var image = Image.FromFile(filename);
                var encoder_params = new EncoderParameters(1);
                var image_codec_info =
                    GetEncoderInfo("image/jpeg");
                string extn = "jpeg";
                var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(filename);
                var fileDirectory = Path.GetDirectoryName(filename);
                var path = new StringBuilder();
                if (fileDirectory != null)
                {
                    if (fileNameWithOutExtension != null)
                    {
                        path.Append(fileDirectory + "\\" + fileNameWithOutExtension);

                    }
                }
                for (long compression = 10; compression <= 25; compression += 10)
                {
                    path.Append("x");
                    encoder_params.Param[0] = new EncoderParameter(
                        System.Drawing.Imaging.Encoder.Quality, compression);

                    var finalPath = path.ToString() + "." + extn;
                    image.Save(finalPath, image_codec_info, encoder_params);
                }
            }
            catch (Exception e)
            { Logger.Log("", "UtilityClass", "ResizeImage", e.Message); }
        }

        private static ImageCodecInfo GetEncoderInfo(string mime_type)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i <= encoders.Length; i++)
            {
                if (encoders[i].MimeType == mime_type) return encoders[i];
            }
            return null;
        }
    }
}