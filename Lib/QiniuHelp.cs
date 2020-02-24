using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Qiniu.Common;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.RS;
using Qiniu.RS.Model;
using Qiniu.Util;
//using HttpResult = Qiniu.Http.HttpResult;

namespace WebResourceHookWpf.Lib
{
    /// <summary>
    /// 七牛云帮助类
    /// </summary>
    public class QiniuHelp
    {
        /// <summary>
        /// 配置类
        /// </summary>
        public static class Settings
        {
            public static string AccessKey { get; set; }
            public static string SecretKey { get; set; }

            /// <summary>
            /// 域名
            /// </summary>
            public static string Domain { get; set; }
        }

       /// <summary>
       /// 返回数据实体类
       /// </summary>
       public class RestData
       {
          public string hash { get; set; }
          public string key { get; set; }
       }

       /// <summary>
       /// 上传文件-自动选择上传方式
       /// </summary>
       /// <param name="bucket">上传到的桶</param>
       /// <param name="uploadPath">上传到的目录包含文件名</param>
       /// <param name="localFile">要上传的文件路径</param>
        /// <returns>上传成功的地址</returns>
        public static async Task<string> UploadFileAsync(string bucket,string key ,string localFile)
        {
            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(Settings.AccessKey, Settings.SecretKey);
            //string bucket = "test";
            //string saveKey = bucket + uploadPath;
            //string localFile = "D:\\QFL\\1.png";

            Config.AutoZone(Settings.AccessKey, bucket, false);//自动配置机房区域

            // 上传策略，参见 
            // https://developer.qiniu.com/kodo/manual/put-policy
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            putPolicy.Scope = bucket;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
            //putPolicy.DeleteAfterDays = 1;
            // 生成上传凭证，参见
            // https://developer.qiniu.com/kodo/manual/upload-token            
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);

            UploadManager um = new UploadManager();
            //Qiniu.Http.HttpResult uploadFile = um.UploadFile(localFile, saveKey, token);
            HttpResult result = await um.UploadFileAsync(localFile, key, token);
            Console.WriteLine(result);
            if (result.Code == (int)HttpCode.OK)
            {
                RestData restData = JsonConvert.DeserializeObject<RestData>(result.Text);
                string restUrl = "http://" + Settings.Domain + "/" + restData.key;

                return restUrl;
            }
            throw new Exception("上传文件出错！！！");
            //return new Exception("");
        }

       /// <summary>
       /// 下载私有空间中的文件
       /// </summary>
       /// <param name="rawUrl">要下载的文件url</param>
       /// <param name="savePath">保存到的路径</param>       
        /// <returns>文件全路径</returns>
        public static async Task<string> DownloadPrivateFileAsync(string rawUrl,string savePath)
        {
            var s = savePath.Substring(savePath.Length-1, 1);
            if ("/".Equals(s)|| "\\".Equals(s))
            {
                savePath += Path.GetFileName(rawUrl);
            }
            else
            {
                savePath += "/" + Path.GetFileName(rawUrl);
            }

            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(Settings.AccessKey, Settings.SecretKey);
            /*string rawUrl = "http://your-bucket.bkt.clouddn.com/1.jpg";
            string savePath = "D:\\QFL\\saved-1.jpg";*/
            // 设置下载链接有效期3600秒
            int expireInSeconds = 3600;
            string accUrl = DownloadManager.CreateSignedUrl(mac, rawUrl, expireInSeconds);

            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }

            // 接下来可以使用accUrl来下载文件
            Qiniu.Http.HttpResult result =await DownloadManager.DownloadAsync(accUrl, savePath);

            Console.WriteLine(result);
            if (result.Code == (int)HttpCode.OK)
            {
                return savePath;
            }
            throw new Exception("下载文件出错！");
        }

       /// <summary>
       /// 删除 指定文件
       /// </summary>
       /// <param name="fileUri"></param>
       /// <returns></returns>
       public static bool DeletePrivateFile(string bucket, string fileName)
       {
           Mac mac = new Mac(Settings.AccessKey, Settings.SecretKey);
           string key = fileName;
           BucketManager bm = new BucketManager(mac);
           Qiniu.Http.HttpResult delete = bm.Delete(bucket, fileName);
           if (delete.Code == (int)HttpCode.OK)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}