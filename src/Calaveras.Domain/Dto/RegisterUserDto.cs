using System;
using System.Collections.Generic;
using System.Text;

namespace Calaveras.Domain.Dto
{
    public class RegisterUserDto: IDisposable
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public string cellphone { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string apto { get; set; }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
