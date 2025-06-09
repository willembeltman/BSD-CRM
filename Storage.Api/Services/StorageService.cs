using Storage.Data;
using Storage.Data.Entities;
using Storage.Shared.Requests;
using Storage.Shared.Responses;
using System.Security.Cryptography;

namespace Storage.Api.Services;

public class StorageService
{
    const string BaseFolder = "Content";
    static readonly DirectoryInfo Directory = new DirectoryInfo("Files");
    private readonly ApplicationDbContext db;

    public StorageService(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task<SaveResponse> SaveAsync(SaveRequest model, Stream inputStream)
    {
        if (!Directory.Exists) Directory.Create();

        var fileName = $"{model.Id}{model.FileName}";
        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            System.IO.Directory.CreateDirectory(directoryFullName);
        var fullName = Path.Combine(directoryFullName, fileName);

        var length = 0L;
        var sha256 = string.Empty;

        using (inputStream)
        using (var outputStream = File.Open(fullName, FileMode.OpenOrCreate))
        using (var hasher = SHA256.Create())
        {
            var buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                outputStream.Write(buffer, 0, bytesRead);
                length += bytesRead;
            }

            hasher.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
            var hashBytes = hasher.Hash!;
            sha256 = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        var dirty = false;
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
        {
            storageFolder = new StorageFolder()
            {
                Name = model.TypeName,
            };
            db.StorageFolders.Add(storageFolder);
            dirty = true;
        }

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityFileName == fileName);
        if (storageFile != null)
        {
            db.StorageFiles.Remove(storageFile);
            dirty = true;
        }

        if (storageFile == null)
        {
            storageFile = new StorageFile()
            {
                EntityId = model.Id,
                EntityFileName = model.FileName,
                FileName = fileName,
                Length = length,
                MimeType = model.MimeType,
                Sha256 = sha256
            };
            storageFolder.StorageFiles.Add(storageFile);
            dirty = true;
        }

        if (dirty)
        {
            await db.SaveChangesAsync();
        }

        var externalUrlRequest = new GetUrlRequest()
        {
            Id = model.Id,
            TypeName = model.TypeName
        };
        var externalUrlResponse = await GetUrlAsync(externalUrlRequest);

        return new SaveResponse()
        {
            Success = true,
            Url = externalUrlResponse.Url,
            StorageFileId = storageFile.Id,
            EntityId = storageFile.EntityId,
            EntityFileName = storageFile.EntityFileName,
            FileName = storageFile.FileName,
            Length = storageFile.Length,
            MimeType = storageFile.MimeType,
            Sha256 = storageFile.Sha256
        };
    }
    public SaveResponse Save(SaveRequest model, Stream inputStream)
    {
        if (!Directory.Exists) Directory.Create();

        var fileName = $"{model.Id}{model.FileName}";
        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        var fullName = Path.Combine(directoryFullName, fileName);

        var length = 0L;
        var sha256 = string.Empty;

        using (inputStream)
        using (var outputStream = File.Open(fullName, FileMode.OpenOrCreate))
        using (var hasher = SHA256.Create())
        {
            var buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                outputStream.Write(buffer, 0, bytesRead);
                length += bytesRead;
            }

            hasher.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
            var hashBytes = hasher.Hash!;
            sha256 = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        var dirty = false;
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
        {
            storageFolder = new StorageFolder()
            {
                Name = model.TypeName,
            };
            db.StorageFolders.Add(storageFolder);
            dirty = true;
        }

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityFileName == fileName);
        if (storageFile != null)
        {
            db.StorageFiles.Remove(storageFile);
            dirty = true;
        }

        if (storageFile == null)
        {
            storageFile = new StorageFile()
            {
                EntityId = model.Id,
                EntityFileName = model.FileName,
                FileName = fileName,
                Length = length,
                MimeType = model.MimeType,
                Sha256 = sha256
            };
            storageFolder.StorageFiles.Add(storageFile);
            dirty = true;
        }

        if (dirty)
        {
            db.SaveChanges();
        }

        var externalUrlRequest = new GetUrlRequest()
        {
            Id = model.Id,
            TypeName = model.TypeName
        };
        var externalUrlResponse = GetUrl(externalUrlRequest);

        return new SaveResponse()
        {
            Success = true,
            Url = externalUrlResponse.Url,
            StorageFileId = storageFile.Id,
            EntityId = storageFile.EntityId,
            EntityFileName = storageFile.EntityFileName,
            FileName = storageFile.FileName,
            Length = storageFile.Length,
            MimeType = storageFile.MimeType,
            Sha256 = storageFile.Sha256
        };
    }

    public async Task<ExistsResponse> ExistsAsync(ExistsRequest model)
    {
        return await Task.Run(() => Exists(model));
    }
    public ExistsResponse Exists(ExistsRequest model)
    {
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
            return new ExistsResponse()
            {
                Success = true,
                Message = "Folder doesn't exists"
            };

        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            return new ExistsResponse()
            {
                Success = true,
                Message = "Folder doesn't exists on disk"
            };

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityId == model.Id);
        if (storageFile == null)
            return new ExistsResponse()
            {
                Success = true,
                Message = "File doesn't exists"
            };

        var fullName = Path.Combine(directoryFullName, storageFile.FileName);
        if (!System.IO.File.Exists(fullName))
            return new ExistsResponse()
            {
                Success = true,
                Message = "File doesn't exists on disk"
            };

        return new ExistsResponse()
        {
            Success = true,
            Exists = true
        };
    }

    public async Task<OpenResponse> OpenAsync(OpenRequest model)
    {
        return await Task.Run(() => Open(model));
    }
    public OpenResponse Open(OpenRequest model)
    {
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
            throw new Exception("Folder doesn't exists");

        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            throw new Exception("Folder doesn't exists on disk");

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityId == model.Id);
        if (storageFile == null)
            throw new Exception("File doesn't exists");

        var fullName = Path.Combine(directoryFullName, storageFile.FileName);
        if (!System.IO.File.Exists(fullName))
            throw new Exception("File doesn't exists on disk");

        var stream = System.IO.File.Open(fullName, FileMode.Open);
        return new OpenResponse(storageFile.MimeType, storageFile.FileName, stream);
    }

    public async Task<GetUrlResponse> GetUrlAsync(GetUrlRequest model)
    {
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
            return new GetUrlResponse()
            {
                Message = "Folder doesn't exists"
            };

        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            return new GetUrlResponse()
            {
                Message = "Folder doesn't exists on disk"
            };

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityId == model.Id);
        if (storageFile == null)
            return new GetUrlResponse()
            {
                Message = "File doesn't exists"
            };

        var fullName = Path.Combine(directoryFullName, storageFile.FileName);
        if (!System.IO.File.Exists(fullName))
            return new GetUrlResponse()
            {
                Message = "File doesn't exists on disk"
            };

        var token = new StorageFileToken()
        {
            StorageFileId = storageFile.Id
        };

        var removeList = db.StorageFileTokens
            .Where(a => a.DateTime < DateTime.Now.AddMinutes(-15))
            .ToArray();
        db.StorageFileTokens.RemoveRange(removeList);
        db.StorageFileTokens.Add(token);
        await db.SaveChangesAsync();

        return new GetUrlResponse()
        {
            Success = true,
            BaseFolder = BaseFolder,
            Folder = storageFolder.Name,
            FileName = storageFile.FileName,
            MimeType = storageFile.MimeType,
            Token = token.Token,
        };
    }
    public GetUrlResponse GetUrl(GetUrlRequest model)
    {
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
            return new GetUrlResponse()
            {
                Message = "Folder doesn't exists"
            };

        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            return new GetUrlResponse()
            {
                Message = "Folder doesn't exists on disk"
            };

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityId == model.Id);
        if (storageFile == null)
            return new GetUrlResponse()
            {
                Message = "File doesn't exists"
            };

        var fullName = Path.Combine(directoryFullName, storageFile.FileName);
        if (!System.IO.File.Exists(fullName))
            return new GetUrlResponse()
            {
                Message = "File doesn't exists on disk"
            };

        var token = new StorageFileToken()
        {
            StorageFileId = storageFile.Id
        };

        var removeList = db.StorageFileTokens
            .Where(a => a.DateTime < DateTime.Now.AddMinutes(-15))
            .ToArray();
        db.StorageFileTokens.RemoveRange(removeList);
        db.StorageFileTokens.Add(token);
        db.SaveChanges();

        return new GetUrlResponse()
        {
            Success = true,
            BaseFolder = BaseFolder,
            Folder = storageFolder.Name,
            FileName = storageFile.FileName,
            MimeType = storageFile.MimeType,
            Token = token.Token,
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteRequest model)
    {
        return await Task.Run(() => Delete(model));
    }
    public DeleteResponse Delete(DeleteRequest model)
    {
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
            return new DeleteResponse()
            {
                Message = "Folder doesn't exists"
            };

        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            return new DeleteResponse()
            {
                Message = "Folder doesn't exists on disk"
            };

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityId == model.Id);
        if (storageFile == null)
            return new DeleteResponse()
            {
                Message = "File doesn't exists"
            };

        var fullName = Path.Combine(directoryFullName, storageFile.FileName);
        if (!System.IO.File.Exists(fullName))
            return new DeleteResponse()
            {
                Message = "File doesn't exists on disk"
            };

        System.IO.File.Delete(fullName);

        return new DeleteResponse()
        {
            Success = true,
            Deleted = true
        };
    }

    public async Task<DownloadResponse> DownloadAsync(DownloadRequest model)
    {
        return await Task.Run(() => Download(model));
    }
    public DownloadResponse Download(DownloadRequest model)
    {
        var storageFolder = db.StorageFolders.FirstOrDefault(a => a.Name == model.TypeName);
        if (storageFolder == null)
            return new DownloadResponse()
            {
                Message = "Folder doesn't exists"
            };

        var directoryFullName = Path.Combine(Directory.FullName, model.TypeName);
        if (!System.IO.Directory.Exists(directoryFullName))
            return new DownloadResponse()
            {
                Message = "Folder doesn't exists on disk"
            };

        var storageFile = storageFolder.StorageFiles.FirstOrDefault(a => a.EntityId == model.Id);
        if (storageFile == null)
            return new DownloadResponse()
            {
                Message = "File doesn't exists"
            };

        var token = storageFile.StorageFileTokens.FirstOrDefault(b => b.Token == model.Token);
        if (token == null)
            return new DownloadResponse()
            {
                Message = "Token doesn't exists"
            };

        var fullName = Path.Combine(directoryFullName, storageFile.FileName);
        if (!System.IO.File.Exists(fullName))
            return new DownloadResponse()
            {
                Message = "File doesn't exists on disk"
            };

        var stream = System.IO.File.Open(fullName, FileMode.Open);
        return new DownloadResponse(storageFile.MimeType, storageFile.FileName, stream);
    }
}
