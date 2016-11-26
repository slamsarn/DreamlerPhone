using System;
using System.Net;

namespace DreamlerPhone {
    public class Proxy : IWebProxy {
        private Uri _proxyUri;

        public ICredentials Credentials { get; set; }

        public Proxy( string uri ) {
            _proxyUri = new Uri( uri );
        }

        public Proxy( Uri uri ) {
            _proxyUri = uri;
        }

        public Uri GetProxy( Uri destination ) {
            return _proxyUri;
        }

        public bool IsBypassed( Uri host ) {
            return false;
        }
    }
}