using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32.SafeHandles;

namespace BusinessRespository.Utility
{
    public class FileUploadcls
    {
        private bool _disposed = false;
        private bool _created = false;
        private SafeFileHandle _safeHandle;
        public void fileUpload(IFormFile file, string path1, string filepathname)
        {
            var path = Path.Combine(
                            Directory.GetCurrentDirectory(), path1,
                           filepathname);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                //await file.CopyToAsync(stream);
                file.CopyTo(stream);
                
         
            }

            //using (var stream = File.Open(path, FileMode.Append, FileAccess.Write))
            //{
            //    await file.CopyToAsync(stream);
            //}

        }

        public void  fileDeleted(string path1, string filepathname)
        {
            
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), path1,
                           filepathname);

                File.Delete(path);

            
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            // Release any managed resources here.
            if (disposing)
            {
                // Dispose managed state (managed objects).
                _safeHandle?.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;

            // Call the base class implementation.
            
        }




    }
}
