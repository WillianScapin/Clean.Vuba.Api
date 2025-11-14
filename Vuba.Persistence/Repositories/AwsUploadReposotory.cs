using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;

namespace Vuba.Persistence.Repositories
{
    public class AwsUploadReposotory : IAwsUploadReposotory
    {
        private readonly IAmazonS3 _s3Client;

        public AwsUploadReposotory(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<Upload> UploadFileAsync(IFormFile file)
        {
            var transferUtility = new TransferUtility(_s3Client);
            var result = file.FileName.Split(".");
            Guid guid = Guid.NewGuid();
            string fileKey = $"Medias/{guid}.{result[result.Length - 1]}";

            var uploadRequest = new TransferUtilityUploadRequest
            {
                BucketName = "vubavideo", //Environment.GetEnvironmentVariable("AWS-Bucket"),
                Key = fileKey,
                InputStream = file.OpenReadStream(),
                CannedACL = S3CannedACL.Private // Defina as permissões para o arquivo (público)
            };

            // Faz o upload do arquivo
            await transferUtility.UploadAsync(uploadRequest);

            return new Upload() 
            {
                FileKey = fileKey,
                Url = GetUrl(fileKey)
            };
        }

        private string GetUrl(string fileKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = "vubavideo",
                Key = fileKey,
                Expires = DateTime.UtcNow.AddHours(99999),
                Protocol = Protocol.HTTP
            };

            string url = _s3Client.GetPreSignedURL(request);
            return url;
        }
    }
}
