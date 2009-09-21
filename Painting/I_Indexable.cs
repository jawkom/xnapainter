using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painting
{
    class I_Indexable
    {
        private static int globalIndex_;
        
        public int Index { get { return index_; } }
        private int index_;

        public I_Indexable()
        {
            index_ = globalIndex_;
            globalIndex_++;
        }
    }
}
