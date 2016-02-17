using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toolbox.Common.Components
{

    // Inherit from this class if you have a class that must implement IDisposable.
    // In the inherited class you can implement the dispose logic by overriding the methods DisposeManagedResources and DisposeUnmanagedResources.
    public class DisposableObject
    {
        /// <summary>
        /// To have more then one call to Dispose.
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Returns true if the object is already disposed. 
        /// </summary>
        /// <remarks>Can be used in descendants to see if the object is disposed.</remarks>
        protected bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// Releases all resources that have been claimed by the object.
        /// </summary>
        /// <remarks>
        /// Calls the Dispose method with argument True so it knows that the call came from code.
        /// Then informs GC that garbage collection for this object is no longer needed.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources an object is claiming.
        /// </summary>
        /// <param name="disposing">
        /// If the argument is True, the call was from managed code so the objects still exist.
        /// If the argument is False, it is possible that the managed objects are already released by the GC.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    DisposeManagedResources();
                DisposeUnmanagedResources();
            }
            _isDisposed = true;
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~DisposableObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// To implement in the inherited class if dispose of managed resources is needed.
        /// </summary>
        protected virtual void DisposeManagedResources()
        {
            // Dispose the managed resources in the decendant here.
        }

        /// <summary>
        /// To implement in the inherited class if dispose of unmanaged resources is needed.
        /// </summary>
        protected virtual void DisposeUnmanagedResources()
        {
            // Dispose the unmanaged resources in the decendant here.
        }

        /// <summary>
        /// Raises an exception if the object is already disposed.
        /// </summary>
        /// <remarks>
        /// This method can be used in the inherited class to check if the object is disposed before 
        /// executing another action that is not allowed on a disposed object.
        /// </remarks>
        protected void CheckDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().Name, "This object has been disposed and can no longer be used.");
        }
    }
}