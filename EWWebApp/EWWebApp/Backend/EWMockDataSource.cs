using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWWebApp.Backend
{
    /// <summary>
    /// Backend Mock DataSource for EW
    /// </summary>
    public class EWMockDataSource
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile EWMockDataSource instance;
        private static object syncRoot = new Object();

        private EWMockDataSource() { }

        public static EWMockDataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new EWMockDataSource();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        private List<EWBackend> ewList = new List<EWBackend>();

        public EWBackend Create(EWBackend encryptModel)
        {
            ewList.Add(encryptModel);
            return encryptModel;
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            // Create new
            Create(new EWBackend());
        }

        public void Reset()
        {
            ewList.Clear();
            Initialize();
        }
    }
}
