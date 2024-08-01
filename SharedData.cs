using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFD_Optical
{
    class SharedData
    {
        private static SharedData _instance;
        private static readonly object _lock = new object();

        public static SharedData Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SharedData();
                        }
                    }
                }
                return _instance;
            }
        }

        public string PartNumber { get; set; }

        private SharedData() { }
    }
}

